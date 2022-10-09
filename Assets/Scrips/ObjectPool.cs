using UnityEngine;
using UnityEngine.Pool;

public class ObjectPool : MonoBehaviour
{
    #region 定義
    [SerializeField,Header("物件")]
    private GameObject goTarget;
    [SerializeField,Header("物件池最大數量")]
    private int countMax = 50;
    #endregion


    #region 方法
    private int index;
    private ObjectPool<GameObject> objectPool;


    private GameObject CreateObject()
    {
        GameObject tempObject = Instantiate(goTarget);
        index++;
        tempObject.name = goTarget.name + index;
        return tempObject;
    }

    private void getObject(GameObject objectInPool) 
    {
        objectInPool.SetActive(true);
    }

    private void releaseObject(GameObject objectInPool)
    {
        objectInPool.SetActive(false);
    }

    private void destoryObject(GameObject objectInPool)
    {
        Destroy(objectInPool);
    }

    private void Test()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            GetPoolObject();
        }
    }
    #endregion

    #region 事件
    private void Awake()
    {
        objectPool = new ObjectPool<GameObject>(CreateObject, getObject, releaseObject, destoryObject, maxSize: countMax);
    }

    private void Update()
    {
        Test();
    }
    #endregion

    #region 公開方法
    public GameObject GetPoolObject() 
    {
        return objectPool.Get();
    }

    public void releasePoolObject(GameObject objectToRelease)
    {
        objectPool.Release(objectToRelease);
    }
    #endregion

}
