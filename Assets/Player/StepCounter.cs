using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UniRx;
using System;

namespace u1w.player
{
    public class StepCounter : MonoBehaviour
    {
        public static readonly int MaxStep = 7;  

        public IReadOnlyReactiveProperty<int> Step => _step;
        private readonly ReactiveProperty<int> _step = new ReactiveProperty<int>(MaxStep);

        public bool TurnEnd => turnEnd;
        private bool turnEnd=false;

        PhaseManager _phaseManager;

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.Ready)
            .Subscribe(_ => ResetStep())
            .AddTo(this);
        }

        public void Count(){
            _step.Value--;
            if(_step.Value <= 0)    turnEnd = true;
        }

        public bool CanMove(){
            return _step.Value > 0;
        }

        void ResetStep(){
            turnEnd = false;
            _step.Value = MaxStep;
        }

    }
}

