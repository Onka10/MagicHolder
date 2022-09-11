using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource _SESource;
    [SerializeField] AudioSource _BGMSource;
    [SerializeField] AudioClip[] SEClips = new AudioClip[5]; 

    [SerializeField] AudioClip[] BGMClips = new AudioClip[2];

    void Start(){
        u1w.PhaseManager.I.State
        .Where(s => s==PhaseState.PlayerAttack || s== PhaseState.Ready)
        .Subscribe(_ => ChangeBGM())
        .AddTo(this);
    }

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

    public void PlayMagic()
    {
        _SESource.volume = 1f;
        _SESource.PlayOneShot(SEClips[4]);
    }

    public void StopBGM(){
        _BGMSource.Stop();
    }

    void ChangeBGM(){
        if(_BGMSource.clip == BGMClips[0])  _BGMSource.clip = BGMClips[1];
        else _BGMSource.clip = BGMClips[0];
        _BGMSource.Play();
    }
}

