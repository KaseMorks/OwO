using UnityEngine;
using Cinemachine;

public class CamerControl : MonoBehaviour
{
    [SerializeField] private GameObject playerControl;
    [SerializeField] private CinemachineVirtualCamera Vcamera;
    [SerializeField] float OnTime, OffTime;
    
    void Start()
    {
        Invoke("VcamOn", OnTime);       
    }
    
    private void VcamOn()
    {
        playerControl.GetComponent<PlayerMovment>().enabled = false;
        Vcamera.gameObject.SetActive(true);
        Debug.Log("VCamOn");
        Invoke("VcamOff", OffTime);
    }
    
    private void VcamOff()
    {
        playerControl.GetComponent<PlayerMovment>().enabled = true;
        Vcamera.gameObject.SetActive(false);
        Debug.Log("VCamOff");
    }

}
