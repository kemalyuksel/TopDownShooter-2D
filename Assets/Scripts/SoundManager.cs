using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public AudioSource soundSource;
    public AudioSource weaponSoundSource;

    public void PlaySound(AudioClip clip, float volume)
    {
        soundSource.volume = volume;
        soundSource.PlayOneShot(clip, volume);
    }

     public void PlayWeaponEffect(AudioClip clip, float volume)
    {
        weaponSoundSource.volume = volume;
        weaponSoundSource.PlayOneShot(clip, volume);
    }


}
