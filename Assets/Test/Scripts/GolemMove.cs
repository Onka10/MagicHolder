using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public class GolemMove : MonoBehaviour
{
    public IObservable<Unit> OnMove => _on;
    private readonly Subject<Unit> _on = new Subject<Unit>();
    public void Move(){
        //transformの移動とか
        _on.OnNext(Unit.Default);
    }
}
