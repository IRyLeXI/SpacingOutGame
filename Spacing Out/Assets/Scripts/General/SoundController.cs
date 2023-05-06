using UnityEngine;
using UnityEngine.Events;
public class SoundController : MonoBehaviour
{

    public float effectsVolume, musicVolume;

    [SerializeField]
    private AudioClip playerShootSound;

    [SerializeField]
    private AudioClip enemyDeathSound;

    [SerializeField]
    private AudioClip playerDeathSound;

    [SerializeField]
    private AudioClip hitSound;

    [SerializeField]
    private AudioClip goliathLaserSound;
    
    [SerializeField]
    private AudioClip enemyShotSound;

    [SerializeField]
    private AudioClip timeStopSound;

    [SerializeField]
    private AudioClip smallLaserSound;

    [SerializeField]
    private AudioClip teleportSound;

    [SerializeField]
    private AudioClip strongShotSound;

    [SerializeField]
    private AudioClip deathSound;

    [SerializeField]
    private AudioClip buttonClick;

    [SerializeField]
    private AudioClip menuMusic;

    [SerializeField]
    private AudioClip gameMusic;

    [SerializeField]
    private AudioClip bossMusic;

    private AudioSource sfxShotSource, musicSource, sfxDestroyEnemySource, sfxDestroyPlayer, sfxHitSource;

    private AudioSource sfxGoliathLaser, sfxTimeStop, sfxTeleportSource, sfxSmallLaser, sfxDeathSound, sfxButtonClick;

    private AudioSource[] sfxEnemyShot;

    private bool isLaserPaused = false;

    void Start()
    {
        sfxShotSource = gameObject.AddComponent<AudioSource>();
        sfxDestroyEnemySource = gameObject.AddComponent<AudioSource>();
        sfxDestroyPlayer = gameObject.AddComponent<AudioSource>();
        sfxHitSource = gameObject.AddComponent<AudioSource>();
        sfxGoliathLaser = gameObject.AddComponent<AudioSource>();
        sfxTimeStop = gameObject.AddComponent<AudioSource>();
        sfxTeleportSource = gameObject.AddComponent<AudioSource>();
        sfxButtonClick = gameObject.AddComponent<AudioSource>();
        sfxSmallLaser = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;

        sfxEnemyShot = new AudioSource[10];
        for (int i = 0; i < 10; i++)
        {
            sfxEnemyShot[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayerShotSound()
    {
        PlaySound(sfxShotSource, playerShootSound);

    }

    public void PlayerDeathSound()
    {
        PlaySound(sfxDestroyPlayer, playerDeathSound);
    }

    public void EnemyDeathSound()
    {
        PlaySound(sfxDestroyEnemySource, enemyDeathSound);
    }

    public void EnemyShotSound()
    {
        for (int i = 0; i < sfxEnemyShot.Length; i++)
        {
            if (!sfxEnemyShot[i].isPlaying)
            {
                PlaySound(sfxEnemyShot[i], enemyShotSound);
                break;
            }
        }
    }

    public void HitSound()
    {
        PlaySound(sfxHitSource, hitSound);
    }

    public void PlayGameMusic()
    {
        if(musicSource == null)
            musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = gameMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void GoliathLaserSound()
    {
        PlaySound(sfxGoliathLaser, goliathLaserSound);
    }

    public void PauseLaser()
    {
        if(sfxGoliathLaser.isPlaying)
        {
            sfxGoliathLaser.Pause();
            isLaserPaused = true;
        }

    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void UnPauseLaser()
    {
        if(isLaserPaused)
        {
            sfxGoliathLaser.UnPause();
            isLaserPaused = false;
        }
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    } 

    public void BossMusic()
    {
        musicSource.clip = bossMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void TimeStop()
    {
        PlaySound(sfxTimeStop, timeStopSound);
    }

    public void SmallLaser()
    {
        PlaySound(sfxSmallLaser, smallLaserSound);
    }

    public void StopSmallLaser()
    {
        if(sfxSmallLaser.isPlaying && sfxSmallLaser != null)
        {
            sfxSmallLaser.Stop();
        }
    }

    public void TeleportSound()
    {
        PlaySound(sfxTeleportSource, teleportSound);
    }
    public void DeathSound()
    {
        musicSource.clip = deathSound;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void StrongShot()
    {
        PlaySound(sfxTeleportSource, strongShotSound);
    }

    public void ButtonClick()
    {
        PlaySound(sfxButtonClick, buttonClick);
    }

    public void MenuMusic()
    {
        if(musicSource == null)
            musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.clip = menuMusic;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void ChangeMusicVolume(float value)
    {
        if(musicSource == null)
            musicSource = gameObject.AddComponent<AudioSource>();
        musicVolume = value;
        musicSource.volume = musicVolume;
    }

    public void ChangeEffectsVolume(float value)
    {
        effectsVolume = value;
    }

    private void PlaySound(AudioSource source, AudioClip cl)
    {
        if(source == null)
            source = gameObject.AddComponent<AudioSource>();
        source.clip = cl;
        source.volume = effectsVolume;
        source.Play();
    }

}
