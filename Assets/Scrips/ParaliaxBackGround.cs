using UnityEngine;

public class ParaliaxBackGround : MonoBehaviour
{
    private float length;
    private float StartPostion;
    private GameObject CameraObj;
    [SerializeField] private float parallaxEffect;

    private void Start()
    {
        CameraObj = GameObject.Find("VCam");
        StartPostion = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }



    private void Update()
    {
        float temp = (CameraObj.transform.position.x * (1 - parallaxEffect));
        float distance = (CameraObj.transform.position.x * parallaxEffect);

        transform.position = new Vector3(StartPostion + distance,transform.position.y,transform.position.z);

        if(temp > StartPostion + length)
        {
            StartPostion += length;
        }
        else if (temp < StartPostion - length)
        {
            StartPostion -= length;
        }
    }
}
