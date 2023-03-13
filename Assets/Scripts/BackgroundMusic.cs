using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float defaultVolume = 0.5f;
    
    private void Awake()
    {
        audioSource.volume = PlayerPrefs.GetFloat("Volume", defaultVolume);
    }
}
