using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;


public interface IPlayerStyle{
    public void StyleChange();
}

namespace u1w.player
{
    public class PlayerStyle : MonoBehaviour,IPlayerStyle
    {

        // public IObservable<Unit> OnStyleChange => _reload;
        // private readonly Subject<Unit> _reload = new Subject<Unit>();

        [SerializeField] StepCounter _step;
        
        // public Style NowStyle;
        public IReadOnlyReactiveProperty<Style> NowStyle => _nowStyle;
        private readonly ReactiveProperty<Style> _nowStyle = new ReactiveProperty<Style>();

        void Start(){
            _nowStyle.Value = new Style();
        }

        public void StyleChange(){
            if(_step.Step.Value !=StepCounter.MaxStep) return;
            _nowStyle.Value.StyleChange();
            // _reload.OnNext(Unit.Default);
            SoundManager.I.PlayStyle();
        }
    }
}

