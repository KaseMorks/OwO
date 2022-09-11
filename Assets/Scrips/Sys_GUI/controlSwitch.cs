using UnityEngine;

public class controlSwitch : MonoBehaviour
{

   [SerializeField]GameObject targetPlayer;

    public void inputSwitch(bool allowMove)
    {
        if(allowMove == true)
        {
            targetPlayer.GetComponent<PlayerMovment>().enabled = true;
        }
        else if(allowMove == false)
        {
            targetPlayer.GetComponent<PlayerMovment>().enabled = false;
        }
    }
}
