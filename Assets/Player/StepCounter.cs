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
        public int MaxStep => maxStep;
        [SerializeField] int maxStep=7;   

        public IReadOnlyReactiveProperty<int> Step => _step;
        private readonly ReactiveProperty<int> _step = new ReactiveProperty<int>(0);

        public bool TurnEnd => turnEnd;
        private bool turnEnd=false;

        public void Count(){
            _step.Value++;
            // Debug.Log(_step);
            if(_step.Value == MaxStep)    turnEnd = true;
        }

        public void InitData(){
            turnEnd = false;
            _step.Value = 0;
        }

    }
}

