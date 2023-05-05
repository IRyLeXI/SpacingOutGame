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

    private AudioSource sfxGoliathLaser, sfxTimeStop, sfxSmallLaser, sfxTeleportSource, sfxDeathSound, sfxButtonClick;

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
        sfxSmallLaser = gameObject.AddComponent<AudioSource>();
        sfxTeleportSource = gameObject.AddComponent<AudioSource>();
        sfxButtonClick = gameObject.AddComponent<AudioSource>();

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
        sfxShotSource.clip = playerShootSound;
        sfxShotSource.volume = effectsVolume;
        sfxShotSource.Play();

    }

    public void PlayerDeathSound()
    {
        sfxDestroyPlayer.clip = playerDeathSound;
        sfxDestroyPlayer.volume = effectsVolume;
        sfxDestroyPlayer.Play();
    }

    public void EnemyDeathSound()
    {
        sfxDestroyEnemySource.clip = enemyDeathSound;
        sfxDestroyEnemySource.volume = effectsVolume;
        sfxDestroyEnemySource.Play();
    }

    public void EnemyShotSound()
    {
        for (int i = 0; i < sfxEnemyShot.Length; i++)
        {
            if (!sfxEnemyShot[i].isPlaying)
            {
                sfxEnemyShot[i].clip = enemyShotSound;
                sfxEnemyShot[i].volume = effectsVolume;
                sfxEnemyShot[i].Play();
                break;
            }
        }
    }

    public void HitSound()
    {
        sfxHitSource.clip = hitSound;
        sfxHitSource.volume = effectsVolume;
        sfxHitSource.Play();
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
        sfxGoliathLaser.clip = goliathLaserSound;
        sfxGoliathLaser.volume = effectsVolume;
        sfxGoliathLaser.Play();
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
        sfxTimeStop.clip = timeStopSound;
        sfxTimeStop.volume = effectsVolume;
        sfxTimeStop.Play();
    }

    public void SmallLaser()
    {
        sfxSmallLaser.clip = smallLaserSound;
        sfxSmallLaser.volume = effectsVolume;
        sfxSmallLaser.Play();
    }

    public void TeleportSound()
    {
        sfxTeleportSource.clip = teleportSound;
        sfxTeleportSource.volume = effectsVolume;
        sfxTeleportSource.Play();
    }

    public void DeathSound()
    {
        musicSource.clip = deathSound;
        musicSource.volume = musicVolume;
        musicSource.Play();
    }

    public void ButtonClick()
    {
        sfxButtonClick.clip = buttonClick;
        sfxButtonClick.volume = effectsVolume;
        sfxButtonClick.Play();
    }

    public void MenuMusic()
    {
        //Debug.Log(musicSource);
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


}
