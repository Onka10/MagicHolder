using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GolemAttack : MonoBehaviour
{
    public IObservable<Unit> OnAttack => _on;
    private readonly Subject<Unit> _on = new Subject<Unit>();
    public void Attack(){
        //攻撃とか
        _on.OnNext(Unit.Default);
    }
}
