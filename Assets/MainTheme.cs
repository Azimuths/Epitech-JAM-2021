using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTheme : MonoBehaviour
{
    public AudioSource audioSource;
    public bool isPlay;

    void Start()
    {
        isPlay = true;
    }

    void Update()
    {
        if (audioSource.time >= 57.6f)
        {
            audioSource.time = 13.8f;
        } else if (isPlay == true && audioSource.isPlaying == false) {
            audioSource.Play();
            audioSource.time = 13.8f;
        }

        if (isPlay == true && PauseMenu.GameIsPause == true)
        {
            isPlay = false;
            audioSource.Pause();
        } else if (isPlay == false && PauseMenu.GameIsPause == false)
        {
            isPlay = true;
            audioSource.UnPause();
        }
    }
}
