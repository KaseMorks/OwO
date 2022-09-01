using UnityEngine;
using Cinemachine;

public class CamerControl : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera Vcamera;
    [SerializeField] float OnTime, OffTime;
    void Start()
    {
        Invoke("VcamOn", OnTime);
        
    }
    
    private void VcamOn()
    {
        Vcamera.gameObject.SetActive(true);
        Debug.Log("VCamOn");
        Invoke("VcamOff", OffTime);
    }
    
    private void VcamOff()
    {
        Vcamera.gameObject.SetActive(false);
        Debug.Log("VCamOff");
    }

}
