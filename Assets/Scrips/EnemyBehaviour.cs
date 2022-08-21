using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float t = 255;
    float HitPoints;
    public float MaxHitPoints;
    public Animator Animator;
    public HealthBehaviour Healthbar;
    public CapsuleCollider2D Collider2D;
    public Rigidbody2D Rigidbody;
    public SpriteRenderer SpriteRenderer;
    void Start()
    {
        HitPoints = MaxHitPoints;
        //Healthbar.SetHealthBar(HitPoints, MaxHitPoints);
    }
    
    public void TakeHit(float damage) 
    {
        HitPoints -= damage;
        Animator.SetTrigger("Enemy_Hurt");
        if (HitPoints <= 0)
        {
            Animator.SetBool("Death",true);
            Collider2D.enabled = false;
            Rigidbody.bodyType = RigidbodyType2D.Static;
            
            InvokeRepeating("Death", 1, 0.1f);
            Destroy(gameObject, 5);
            
        }
    }
    void Death() 
    {
        SpriteRenderer.color -= new Color(0, 0, 0, 0.1f);
        
        if (SpriteRenderer.color.a <= 0) 
        {
            CancelInvoke();
        }
        
    }
}
