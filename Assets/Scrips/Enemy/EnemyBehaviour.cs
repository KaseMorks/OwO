using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float HitPoints;
    [SerializeField] private float MaxHitPoints;
    [SerializeField] private Animator Animator;
    [SerializeField] private HealthbarBehaviour Healthbar;
    [SerializeField] private BoxCollider2D Collider2D;
    [SerializeField] private Rigidbody2D Rigidbody;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    private EnemyPatrol enemyPatrol;

    void Start()
    {
        HitPoints = MaxHitPoints;
        Healthbar.SetHealthBar(HitPoints, MaxHitPoints);
    }
    
    public void TakeHit(float damage) 
    {
        HitPoints -= damage;
        Healthbar.SetHealthBar(HitPoints, MaxHitPoints);
        Animator.SetTrigger("Enemy_Hurt");
        if (HitPoints <= 0)
        {
            Animator.SetBool("Death",true);
            Collider2D.enabled = false;
            Rigidbody.bodyType = RigidbodyType2D.Static;
            
            InvokeRepeating("Death", 1, 0.1f);
            Destroy(gameObject, 2);
            
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
