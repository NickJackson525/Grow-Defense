using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    #region Variables

    public AudioSource backgroundMusicSource;
    public AudioSource effectSoundSource;
    public AudioClip plantInGound1;
    public AudioClip plantInGound2;
    public AudioClip plantInGound3;
    public AudioClip plantInGound4;
    public AudioClip button;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static Sound_Manager instance;

    // create GameManager
    private Sound_Manager()
    {

    }

    // Property for Singleton
    public static Sound_Manager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new Sound_Manager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    private void Awake()
    {
        DontDestroyOnLoad(this);

        // add audio source
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        effectSoundSource = gameObject.AddComponent<AudioSource>();

        //load sound files
        plantInGound1 = Resources.Load<AudioClip>("Sounds/plantInGround1");
        plantInGound2 = Resources.Load<AudioClip>("Sounds/plantInGround2");
        plantInGound3 = Resources.Load<AudioClip>("Sounds/plantInGround3");
        plantInGound4 = Resources.Load<AudioClip>("Sounds/plantInGround4");
        button = Resources.Load<AudioClip>("Sounds/ButtonClick");
    }

    private void Start()
    {
        
    }

    public void PlayButtonSound()
    {
        effectSoundSource.PlayOneShot(button, .7f);
    }
}
