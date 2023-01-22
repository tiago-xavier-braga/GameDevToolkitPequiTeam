using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip music;
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip jumping;
    //[SerializeField] AudioClip running;

    public AudioSource stepAudioSource;
    public AudioSource sfxAudioSource;

    public void PlaySfx(AudioClip clip, float value)
    {
        if (sfxAudioSource != null)
        {

            sfxAudioSource.PlayOneShot(clip, value);
        }
    }
    public void CoinSound()
    {
        PlaySfx(coin, 0.5f);
    }
    public void JumpingSound()
    {
        PlaySfx(jumping, 0.5f);
    }

    public void RunningSound()
    {
        //PlaySfx(running, 0.5f);
    }
}
