using System.Collections;
using System.Collections.Generic;
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

    // loads the volume according to settings

    private void Awake()
    {
        GetComponent<AudioSource>().volume = Settings.Instance.volume;
    }
}
