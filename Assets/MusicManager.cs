using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get { return instance; }
    }


    [Header("Background music")]
    public AudioClip backgroundMusic;
    public float backgroundMusicVolume = 0.5f;
    public AudioSource backgroundMusicSource;

    [Header("Projectile Sound")]
    public AudioClip projectileSound;
    public float projectileSoundVolume = 0.5f;

    [Header("Melee sound")]
    public AudioClip meleeSound;
    

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);


        // Setup background music
        backgroundMusicSource = gameObject.AddComponent<AudioSource>();
        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.volume = backgroundMusicVolume;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.playOnAwake = true;
        backgroundMusicSource.Play();
    }

    public void StopAndDestroy()
    {
        if (backgroundMusicSource != null)
        {
            backgroundMusicSource.Stop();
        }
        Destroy(this.gameObject);
        instance = null;
    }

    public void PlayProjectileSound()
    {
        GameObject soundObject = new GameObject("ProjectileSound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = projectileSound;
        audioSource.volume = projectileSoundVolume;
        audioSource.Play();
        Destroy(soundObject,projectileSound.length);
    }

    public void PlayMeleeSound()
    {
        GameObject soundObject = new GameObject("MeleeSound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = meleeSound;
        audioSource.volume = projectileSoundVolume;
        audioSource.Play();
        Destroy(soundObject, meleeSound.length);
    }

    public void AbilitySound(AudioClip soundClip)
    {
        GameObject soundObject = new GameObject("AbilitySound");
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = soundClip;
        audioSource.volume = 0.5f;
        audioSource.Play();
        Destroy(soundObject,soundClip.length);
    }
}
