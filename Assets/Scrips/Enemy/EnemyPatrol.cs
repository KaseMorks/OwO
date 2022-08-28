
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("巡邏點設定")]
    [SerializeField] private Transform RightEdge;
    [SerializeField] private Transform LeftEdge;

    [Header("敵人設置")]
    [SerializeField] private Transform enemy;
    [SerializeField] private float Speed;
    [SerializeField] private Animator EnemyAnimator;
    [SerializeField] private float idleDuration;
    private float idleTimer;
    private Vector3 InitScale;
    private bool IsMovingRight = true;

    private void Awake()
    {
        InitScale = enemy.localScale;
    }

    private void Update()
    {

        if (enemy != null && !EnemyAnimator.GetBool("Death"))
        {
            if (IsMovingRight)
            {
                if (enemy.position.x <= RightEdge.position.x)
                {
                    MoveInDirection(1);
                }

                else
                {
                    DirectionChange();
                }
            }
            else
            {
                if (enemy.position.x >= LeftEdge.position.x)
                {
                    MoveInDirection(-1);
                }
                else
                {
                    DirectionChange();
                }
            }
        }

        
    }

    private void DirectionChange()
    {
        EnemyAnimator.SetBool("Enemy_Move", false);

        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            IsMovingRight = !IsMovingRight;
        }

    }

    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;
        EnemyAnimator.SetBool("Enemy_Move", true);
        enemy.localScale = new Vector3(Mathf.Abs(InitScale.x) * _direction, InitScale.y, InitScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * Speed, enemy.position.y, enemy.position.z);
    }
}
