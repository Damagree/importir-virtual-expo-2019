using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private float startVolume = 1f;
    [SerializeField] private AudioSource[] audioSource;

    private void Start()
    {
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = startVolume;
        }
        
        slider.value = startVolume;
    }

    public void SetVolume()
    {
        for (int i = 0; i < audioSource.Length; i++)
        {
            audioSource[i].volume = slider.value;
        }
    }
}
