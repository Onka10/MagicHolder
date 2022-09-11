using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource _SESource;
    [SerializeField] AudioSource _BGMSource;
    [SerializeField] AudioClip[] SEClips = new AudioClip[4]; 

    //SEの再生
    public void PlayStyle()
    {
        _SESource.volume = 1f;
        _SESource.PlayOneShot(SEClips[0]);
    }

    public void PlayPlayerAttack()
    {
        _SESource.volume = 1f;
        _SESource.PlayOneShot(SEClips[1]);
    }

    public void PlayRockAttack()
    {
        _SESource.volume = 0.8f;
        _SESource.PlayOneShot(SEClips[2]);
    }

    public void PlayerMove()
    {
        _SESource.volume = 0.8f;
        _SESource.PlayOneShot(SEClips[3]);
    }

    public void StopBGM(){
        _BGMSource.Stop();
    }
}

