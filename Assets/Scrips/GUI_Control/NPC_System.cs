using UnityEngine;
using TMPro;

public class NPC_System : MonoBehaviour
{
    private bool isInRange;
    private bool isDiloagy = false;
    private CanvasGroup groupTip;
    private CanvasGroup groupChat;
    private byte _content;
    [SerializeField] TextMeshProUGUI ChatName;
    [SerializeField] TextMeshProUGUI ChatText;
    [SerializeField] ScripableData[] ChatContent;

    [SerializeField]private string nameCanvas;
    private void Awake()
    {
        groupTip = GameObject.Find(nameCanvas).GetComponent<CanvasGroup>();
        groupChat = GameObject.Find("Chat_GUI").GetComponent<CanvasGroup>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
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
    public void changeContent(byte _Con)
    {
        _content = _Con;
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
                ChatName.text = ChatContent[_content].NPC_Name;
                ChatText.text = ChatContent[_content].Content[0];
                isDiloagy = true;
            }
        }
        
    }
}
