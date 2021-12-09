using System.Runtime.InteropServices;
using UnityEngine;

public class LinkNewTab : MonoBehaviour
{

    public void Link(string url)
    {
#if !UNITY_EDITOR && UNITY_WEBGL
		OpenNewTab(url);
#endif
    }

    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);
}
