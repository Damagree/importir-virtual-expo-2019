using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(DownloadFile))]
public class OpenNewtab : MonoBehaviour
{

    [SerializeField] bool isChangeable = false;

    [Header("Changeable"), Space(5)]
    [SerializeField, TextArea(3, 4)] string csvUrl;
    [SerializeField] List<LinkFromCsv> listOfLink;
    [SerializeField] Button[] buttons;
    [SerializeField] DownloadFile downloadFile;


    [Header("Not Changeable"), Space(5)]
    [SerializeField] string url = "";

    private void Awake()
    {
        if (isChangeable)
        {
            downloadFile = GetComponent<DownloadFile>();

            downloadFile.Get(csvUrl, (string error) =>
            {
                Debug.Log("ERROR: " + error);
            }, (string text) =>
            {
                Debug.Log("Received: " + text);
                CsvToUrl(text);
                for (int i = 0; i < listOfLink.Count; i++)
                {
                    int i2 = i;
                    for (int j = 0; j < buttons.Length; j++)
                    {
                        int j2 = j;
                        if (buttons[j2].gameObject.name == listOfLink[i2].id)
                        {
                            buttons[j2].onClick.AddListener(delegate { OpenDefaultNewtab(listOfLink[i2].url); });
                            Debug.Log("url: " + url + " | to button: " + buttons[j2].gameObject.name);
                        }
                    }
                }
            });
        }
        
    }

    public void OpenDefaultNewtab(string url)
    {
#if !UNITY_EDITOR
		OpenNewTab(url);
#endif
#if UNITY_EDITOR
        Debug.Log("Opening new tab: " + url);
#endif
    }

    public void CsvToUrl(string csvText)
    {
        string[] lines = csvText.Split('\n');
        for (int i = 0; i < lines.Length; i++)
        {
            if (i + 1 < lines.Length)
            {
                LinkFromCsv newLink = new LinkFromCsv();
                string[] data = lines[i + 1].Split(',');
                newLink.id = data[0];
                newLink.url = data[1];
                listOfLink.Add(newLink);
            }
        }
    }

    [DllImport("__Internal")]
    private static extern void OpenNewTab(string url);
}
