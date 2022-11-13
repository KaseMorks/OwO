using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    [SerializeField] float ProjectDamage = 1f;
    private void Start()
    {
        Destroy(gameObject, 10);
    }
    private float Projectile_speed = 10f;
    private void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Projectile_speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(ProjectDamage);
        }
        
        Destroy(gameObject);
    }
}    
