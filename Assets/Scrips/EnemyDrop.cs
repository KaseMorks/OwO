using UnityEngine;

public class EnemyDrop : ObjectPool
{
    public static EnemyDrop instance;
     
    void Start()
    {
        instance = this;
    }

   
}
