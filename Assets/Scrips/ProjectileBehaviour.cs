
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
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
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }
}    
