using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    public float musicVolume;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip menuMusic;

    [SerializeField]
    private AudioClip gameMusic;

    [SerializeField]
    private AudioClip bossMusic;

    private AudioSource musicSource;

    void Start()
    {
        if(musicSource == null)
        {
            CreateSource();
        }     
    }



    public void PlayGameMusic()
    {
        // if(musicSource == null)
        //     musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = gameMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    } 

    public void BossMusic()
    {
        if(musicSource == null)
        {
            CreateSource();
        }
        musicSource.clip = bossMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void DeathSound()
    {
        if(musicSource == null)
        {
            CreateSource();
        }
        musicSource.clip = deathSound;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void MenuMusic()
    {
        if(musicSource == null)
        {
            CreateSource();
        }
        musicSource.clip = menuMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void ChangeMusicVolume(float value)
    {
        if(musicSource == null)
        {
            CreateSource();
        }
        musicVolume = value;
        musicSource.volume = value;
    }

    private void CreateSource()
    {
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
    }

}
