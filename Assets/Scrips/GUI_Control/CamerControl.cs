using UnityEngine;
using Cinemachine;


public class CamerControl : MonoBehaviour
{
    public controlSwitch m_Com; //¨¤¦â±±¨î¾¹
    [SerializeField] private CinemachineVirtualCamera Vcamera;
    [SerializeField] float OnTime, OffTime;
    
    void Start()
    {
        Invoke("VcamOn", OnTime);       
    }
    
    private void VcamOn()
    {
        m_Com.inputSwitch(false);
        Vcamera.gameObject.SetActive(true);
        Debug.Log("VCamOn");
        Invoke("VcamOff", OffTime);
    }
    
    private void VcamOff()
    {
        m_Com.inputSwitch(true);
        Vcamera.gameObject.SetActive(false);
        Debug.Log("VCamOff");
    }

}
