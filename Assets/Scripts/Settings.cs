using UnityEngine;

/*
 * My attempt to make a settings system, probably a complete fail
 */

public class Settings : MonoBehaviour
{
    public static Settings Instance;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Volume = defaultVolume;
    }

    [SerializeField] private float defaultVolume;
    public float Volume { get; set; }
}
