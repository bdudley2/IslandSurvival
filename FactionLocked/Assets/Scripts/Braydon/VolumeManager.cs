using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

// Manages Volume (mainly just lowers/raises/mutes the looped music)
public class VolumeManager : MonoBehaviour
{
    public AudioSource loopMusic;
    public GameObject muteText = null;

    private TMP_Text tmproMuted;
    private float savedAudioVol;

    // Start is called before the first frame update
    void Start()
    {
        tmproMuted = muteText.GetComponent<TMP_Text>();
        tmproMuted.enabled = false;
        loopMusic.volume = 0.4f;
        savedAudioVol = loopMusic.volume;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) {
            tmproMuted.enabled = !tmproMuted.enabled;
            if (tmproMuted.enabled) 
            {
                savedAudioVol = loopMusic.volume;
                loopMusic.volume = 0f;
            } else 
            {
                loopMusic.volume = savedAudioVol;
            }
        }
        if (Input.GetKeyDown(KeyCode.J) && !tmproMuted.enabled) {
            if (loopMusic.volume >= 0.1f) 
            {
                loopMusic.volume -= 0.1f;
                savedAudioVol = loopMusic.volume;
            }
        } else if (Input.GetKeyDown(KeyCode.L) && !tmproMuted.enabled) {
            if (loopMusic.volume <= 0.9f) 
            {
                loopMusic.volume += 0.1f; 
                savedAudioVol = loopMusic.volume;
            }
        }
    }
}
