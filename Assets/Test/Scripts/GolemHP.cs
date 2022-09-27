using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GolemHP : MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> HP => hp;
    private readonly ReactiveProperty<int> hp = new ReactiveProperty<int>(10);
    [SerializeField] GolemCore core;

    // public IObservable<Unit> OnDead => _on;
    // private readonly Subject<Unit> _on = new Subject<Unit>();

    void Start(){
        HP
        .Where(hp => hp <= 0)
        .Subscribe(_ => core.Dead())
        .AddTo(this);

        core.State
        .Where(s => s==4)
        .Subscribe(_ => hp.Value=0)
        .AddTo(this);
    }
}
