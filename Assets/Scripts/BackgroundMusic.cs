using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    //public static BackgroundMusic Instance;

    //private void Awake()
    //{
    //    // start of new code
    //    if (Instance != null)
    //    {
    //        Destroy(gameObject);
    //        return;
    //    }
    //    // end of new code

    //    Instance = this;
    //    DontDestroyOnLoad(gameObject);
    //}

    // supposed to save volume and load it throughout scenes but i don't think it really works

    private void Awake()
    {
        GetComponent<AudioSource>().volume = Settings.Instance.Volume;
    }
}
