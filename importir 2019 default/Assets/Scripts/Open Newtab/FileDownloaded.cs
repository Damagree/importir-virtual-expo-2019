using UnityEngine;

[CreateAssetMenu(menuName = "Type Downloaded File")]
public class FileDownloaded : ScriptableObject
{
    [TextArea(3, 5)] public string textReceived = "";
}
