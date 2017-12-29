using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeLevel : MonoBehaviour
{
    public enum AudioType { MUSIC, EFFECTS}
    public Audio_Manager audioManager;
    public AudioType thisType;

    // Use this for initialization
    void Start ()
    {
        audioManager = GameObject.Find("Audio Manager").GetComponent<Audio_Manager>();

        switch (thisType)
        {
            case AudioType.MUSIC:
                GetComponent<Slider>().value = audioManager.musicVolume;
                break;
            case AudioType.EFFECTS:
                GetComponent<Slider>().value = audioManager.effectVolume;
                break;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch (thisType)
        {
            case AudioType.MUSIC:
                audioManager.musicVolume = GetComponent<Slider>().value;
                break;
            case AudioType.EFFECTS:
                audioManager.effectVolume = GetComponent<Slider>().value;
                break;
        }
    }
}
