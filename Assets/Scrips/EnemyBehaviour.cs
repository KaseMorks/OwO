using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    float HitPoints;
    public float MaxHitPoints;
    public Animator Animator;
    public HealthBehaviour Healthbar;
    public CapsuleCollider2D Collider2D;
    public Rigidbody2D Rigidbody;
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
            Death();
            //Destroy(gameObject);
        }
    }
    void Death() 
    {
        Collider2D.enabled = false;
        Rigidbody.bodyType = RigidbodyType2D.Static;

    }
}
