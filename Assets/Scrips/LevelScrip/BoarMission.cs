using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoarMission : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Finish")
        {
            Debug.Log("已還給豬仔南瓜");
        }
            
    }
}
