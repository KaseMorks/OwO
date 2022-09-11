using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    [SerializeField] private float AttackCooldown;
    [SerializeField] private int Damage;
    [SerializeField] private float Range;
    [SerializeField] private float ColliderDistance;
    [SerializeField] private BoxCollider2D BoxCollider;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private Animator EnemyAnimator;
    private float CoolDownTimer = Mathf.Infinity;
    private EnemyPatrol enemyPatrol;
    private PlayerCombat PlayerOnhit;


    private void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        CoolDownTimer += Time.deltaTime;
        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
        if (PlayerInSight()) //只會攻擊視野範圍內玩家
        {
            if (CoolDownTimer >= AttackCooldown) 
            {
                CoolDownTimer = 0;
                EnemyAnimator.SetTrigger("Enemy_Attack");
            }
        }
        
    }

        

    private bool PlayerInSight()
    {
        RaycastHit2D Hit = Physics2D.BoxCast(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance, new Vector3(BoxCollider.bounds.size.x * Range,BoxCollider.bounds.size.y,BoxCollider.bounds.size.z),0,Vector2.left,0,PlayerLayer);
        
        
        if (Hit.collider != null)
        {
            PlayerOnhit = Hit.transform.GetComponent<PlayerCombat>();
        }
        return Hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(BoxCollider.bounds.center + transform.right * Range * transform.localScale.x * ColliderDistance, new Vector3(BoxCollider.bounds.size.x * Range, BoxCollider.bounds.size.y, BoxCollider.bounds.size.z));
    }

    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            PlayerOnhit.PlayerTakeHit(Damage);
        }
    }
}

