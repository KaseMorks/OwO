using UnityEngine;
using TMPro;

public class NPC_System : MonoBehaviour
{
    private bool isInRange;
    private bool isDiloagy = false;
    private CanvasGroup groupTip;
    private CanvasGroup groupChat;
    [SerializeField]TextMeshProUGUI ChatText;
    [SerializeField] ScripableData ChatContent;

    [SerializeField]private string nameCanvas;
    private void Awake()
    {
        groupTip = GameObject.Find(nameCanvas).GetComponent<CanvasGroup>();
        groupChat = GameObject.Find("Chat_GUI").GetComponent<CanvasGroup>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        Debug.Log("§A¼²¨ì¤F"+ collision.gameObject);
        groupTip.alpha = 1;
        isInRange = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
            groupTip.alpha = 0;
            groupChat.alpha = 0;
            isInRange = false;
            isDiloagy = false;
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&& isInRange)
        {

            if (isDiloagy)
            {
                groupTip.alpha = 1;
                groupChat.alpha = 0;
                isDiloagy = false;
            }
            else
            {
                groupTip.alpha = 0;
                groupChat.alpha = 1;
                ChatText.text = ChatContent.Content[0];
                isDiloagy = true;
            }
        }
        
    }
}
