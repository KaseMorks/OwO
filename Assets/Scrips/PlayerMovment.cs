using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [Header("水平移動動作")] //移動控制、速度
    public float moveSpeed = 10f;
    public Vector2 direction;
    private bool facingLeft = true;

    [Header("垂直移動動作")] //跳躍控制、強度
    public float jumpSpeed = 15f;
    public float jumpDelay = 0.25f;
    private float jumpTimer;

    [Header("組件")] //拉程式需使用組件
    public Rigidbody2D rb;
    public Animator animator;

    internal void SetActive(bool v)
    {
        throw new NotImplementedException();
    }

    public LayerMask groundLayer;
    public GameObject characterHolder;

    [Header("物理特性")] //物理特性
    [Tooltip("角色最高速度")]
    public float maxSpeed = 7f;
    [Tooltip("速度減益")]
    public float linearDrag = 4f;
    [Tooltip("重力")]
    public float gravity = 1f;
    [Tooltip("墜落加速度")]
    public float fallMultiplier = 5f;

    [Header("碰撞")] //觸地偵測
    public bool onGround = false;
    public Vector3 colliderOffset;
    [SerializeField] Vector2 AreaShape;

    [Header("攻擊射彈")]
    public ProjectileBehaviour ProjectilePrefab;
    public Transform DragonMouth;
    public float FireRate = 1.0f;
    private float NextFire = 0.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time > NextFire) 
        {
            NextFire = Time.time + FireRate;
            Instantiate(ProjectilePrefab, DragonMouth.position, transform.rotation);
            animator.SetTrigger("Attack_Flame");
        }

        bool wasOnGround = onGround;
        onGround = Physics2D.BoxCast(transform.position - colliderOffset, new Vector3(AreaShape.x, AreaShape.y,1),0,Vector2.zero,0, groundLayer);

        if (!wasOnGround && onGround)
        {
            //StartCoroutine(JumpSqueeze(1.25f, 0.8f, 0.05f));
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpTimer = Time.time + jumpDelay;
        }
        animator.SetBool("onGround", onGround);
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void FixedUpdate()
    {
        moveCharacter(direction.x);
        if (jumpTimer > Time.time && onGround)
        {
            Jump();
        }

        modifyPhysics();
    }
    void moveCharacter(float horizontal)
    {
        rb.AddForce(Vector2.right * horizontal * moveSpeed);

        if ((horizontal < 0 && !facingLeft) || (horizontal > 0 && facingLeft))
        {
            Flip();
        }
        if (Mathf.Abs(rb.velocity.x) > maxSpeed)
        {
            rb.velocity = new Vector2(Mathf.Sign(rb.velocity.x) * maxSpeed, rb.velocity.y);
        }
        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("JumpSpeed", rb.velocity.y);
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        jumpTimer = 0;
        //StartCoroutine(JumpSqueeze(0.5f, 1.2f, 0.1f));
    }
    void modifyPhysics()
    {
        bool changingDirections = (direction.x > 0 && rb.velocity.x < 0) || (direction.x < 0 && rb.velocity.x > 0);

        if (onGround)
        {
            if (Mathf.Abs(direction.x) < 0.4f || changingDirections)
            {
                rb.drag = linearDrag;
            }
            else
            {
                rb.drag = 0f;
            }
            rb.gravityScale = 0;
        }
        else
        {
            rb.gravityScale = gravity;
            rb.drag = linearDrag * 0.15f;
            if (rb.velocity.y < 0)
            {
                rb.gravityScale = gravity * fallMultiplier;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.gravityScale = gravity * (fallMultiplier / 2);
            }
        }
    }
    /// <summary>
    /// 進行角色面朝方向的設定、人物跳躍著地小變形
    /// </summary>
    void Flip()
    {
        facingLeft = !facingLeft;
        transform.rotation = Quaternion.Euler(0, facingLeft ? 0 : 180, 0);
    }
   /*IEnumerator JumpSqueeze(float xSqueeze, float ySqueeze, float seconds)
    {
        Vector3 originalSize = Vector3.one;
        Vector3 newSize = new Vector3(xSqueeze, ySqueeze, originalSize.z);
        float t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(originalSize, newSize, t);
            yield return null;
        }
        t = 0f;
        while (t <= 1.0)
        {
            t += Time.deltaTime / seconds;
            characterHolder.transform.localScale = Vector3.Lerp(newSize, originalSize, t);
            yield return null;
        }

    }*/
/// <summary>
/// 繪製可視化偵測線
/// </summary>
private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawLine(transform.position + colliderOffset, transform.position + colliderOffset + Vector3.down * groundLength);
        //Gizmos.DrawLine(transform.position - colliderOffset, transform.position - colliderOffset + Vector3.down * groundLength);
        Gizmos.DrawCube(transform.position - colliderOffset, new Vector3(AreaShape.x,AreaShape.y, 1));
    }
}