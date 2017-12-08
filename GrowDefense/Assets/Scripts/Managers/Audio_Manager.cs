using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Audio_Manager : MonoBehaviour
{
    #region Variables

    public AudioSource backgroundMusicSource;
    public AudioSource effectSoundSource;
    public AudioClip backroundMusic1;
    public AudioClip backroundMusic2;
    public AudioClip backroundMusic3;
    public AudioClip plantInGound1;
    public AudioClip plantInGound2;
    public AudioClip plantInGound3;
    public AudioClip plantInGound4;
    public AudioClip button;
    public AudioClip plantShoot;
    public AudioClip sell;
    public float musicVolume = 1;
    public float effectVolume = 1;

    #endregion

    #region Singleton

    // create variable for storing singleton that any script can access
    private static Audio_Manager instance;

    // create AudioManager
    private Audio_Manager()
    {

    }

    // Property for Singleton
    public static Audio_Manager Instance
    {
        get
        {
            // If the singleton does not exist
            if (instance == null)
            {
                // create and return it
                instance = new Audio_Manager();
            }

            // otherwise, just return it
            return instance;
        }
    }

    #endregion

    #region Awake

    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("AudioManager").Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        //add audio source
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        effectSoundSource = gameObject.AddComponent<AudioSource>();

        //load sound files
        backroundMusic1 = Resources.Load<AudioClip>("Sounds/Background1");
        backroundMusic2 = Resources.Load<AudioClip>("Sounds/Background2");
        backroundMusic3 = Resources.Load<AudioClip>("Sounds/Background3");
        plantInGound1 = Resources.Load<AudioClip>("Sounds/plantInGround1");
        plantInGound2 = Resources.Load<AudioClip>("Sounds/plantInGround2");
        plantInGound3 = Resources.Load<AudioClip>("Sounds/plantInGround3");
        plantInGound4 = Resources.Load<AudioClip>("Sounds/plantInGround4");
        button = Resources.Load<AudioClip>("Sounds/ButtonClick");
        plantShoot = Resources.Load<AudioClip>("Sounds/plantShoot");
        sell = Resources.Load<AudioClip>("Sounds/SellPlant");

        PlayBackgroundMusic();
    }

    #endregion

    #region Update

    private void Update()
    {
        if(!backgroundMusicSource.isPlaying)
        {
            PlayBackgroundMusic();
        }

        backgroundMusicSource.volume = .3f * musicVolume;
    }

    #endregion

    #region Play Sounds

    public void PlayButtonSound()
    {
        effectSoundSource.PlayOneShot(button, .6f * effectVolume);
    }

    public void PlayPlantShoot()
    {
        effectSoundSource.PlayOneShot(plantShoot, .2f * effectVolume);
    }

    public void PlayMoneySound()
    {
        effectSoundSource.PlayOneShot(sell, .2f * effectVolume);
    }

    public void PlayPlantingSound()
    {
        int rand = UnityEngine.Random.Range(0, 4);

        switch (rand)
        {
            case 1:
                effectSoundSource.PlayOneShot(plantInGound1, .5f * effectVolume);
                break;
            case 2:
                effectSoundSource.PlayOneShot(plantInGound2, .5f * effectVolume);
                break;
            case 3:
                effectSoundSource.PlayOneShot(plantInGound3, .5f * effectVolume);
                break;
            case 4:
                effectSoundSource.PlayOneShot(plantInGound4, .5f * effectVolume);
                break;
            default:
                effectSoundSource.PlayOneShot(plantInGound1, .5f * effectVolume);
                break;
        }
    }

    public void PlayBackgroundMusic()
    {
        backgroundMusicSource.Stop();
        int rand = UnityEngine.Random.Range(0, 3);

        switch (rand)
        {
            case 0:
                backgroundMusicSource.PlayOneShot(backroundMusic1, .3f * musicVolume);
                backgroundMusicSource.volume = .3f * musicVolume;
                break;
            case 1:
                backgroundMusicSource.PlayOneShot(backroundMusic2, .3f * musicVolume);
                backgroundMusicSource.volume = .3f * musicVolume;
                break;
            case 2:
                backgroundMusicSource.PlayOneShot(backroundMusic3, .3f * musicVolume);
                backgroundMusicSource.volume = .3f * musicVolume;
                break;
            default:
                backgroundMusicSource.PlayOneShot(backroundMusic1, .3f * musicVolume);
                backgroundMusicSource.volume = .3f * musicVolume;
                break;
        }
    }

    #endregion
}