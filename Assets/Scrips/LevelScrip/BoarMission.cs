using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarMission : MonoBehaviour
{
    [SerializeField]private GameObject Happy;
    private GameObject targetEnemy;
    private NPC_System missionReport;
    private bool _mission1, _mission2;
    private void Awake()
    {
        
        targetEnemy = GameObject.Find("Enemy_Skeleton");
        missionReport = GameObject.Find("Cute_Boar").GetComponent<NPC_System>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Debug.Log("已還給豬仔南瓜");
            _mission1 = true;
        }        
    }
    private void Update()
    {
        if (targetEnemy == null)
            _mission2 = true;
        if (_mission1 == true && _mission2 == true)
        {
            missionReport.changeContent(1);
            Happy.gameObject.SetActive(true);
        }
        else if (_mission1 == true && _mission2 == false)
        {
            missionReport.changeContent(2);
            
        }
        else if (_mission1 == false && _mission2 == true)
        {
            missionReport.changeContent(3);
            
        }

    }


}
