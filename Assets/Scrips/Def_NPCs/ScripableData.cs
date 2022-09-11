using UnityEngine;

[CreateAssetMenu(menuName ="NPC_Data")]
public class ScripableData : ScriptableObject
{
    [Header("NPC名字")]
    public string NPC_Name;
    [Header("對話內容")]
    public string[] Content;
}
