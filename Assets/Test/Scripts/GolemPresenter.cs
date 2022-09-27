using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GolemPresenter : MonoBehaviour
{
    [SerializeField] GolemMove move;
    [SerializeField] GolemAttack attack;
    [SerializeField] GolemView view;
    [SerializeField] GolemHP HP;
    [SerializeField] GolemCore core;

    void Start(){
        core.State
        .Where(s => s==0)
        .Subscribe(_ => {
            view.ChangeShader(1);
            view.ChangeMaterial();
        })
        .AddTo(this);

        core.State
        .Where(s => s==1)
        .Subscribe(_ => view.ChangeAnime("idol"))
        .AddTo(this);

        move.OnMove
        .Subscribe(_ => view.ChangeAnime("move"))
        .AddTo(this);

        attack.OnAttack
        .Subscribe(_ => view.ChangeAnime("attack"))
        .AddTo(this);

        HP.HP
        .Where(hp => hp <= 0)
        .Subscribe(_ => view.ChangeShader(0))
        .AddTo(this);
    }


}
