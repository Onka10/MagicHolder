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
        [SerializeField] InputObserver _input;

        [SerializeField] int MaxStep=7;   

        public int Step => _step; 
        private int _step;
        
        void Start(){
            _input.OnW
            .Subscribe(_ => Count())
            .AddTo(this);

            _input.OnA
            .Subscribe(_ => Count())
            .AddTo(this);

            _input.OnS
            .Subscribe(_ => Count())
            .AddTo(this);

            _input.OnD
            .Subscribe(_ => Count())
            .AddTo(this);
        }

        void Count(){
            _step++;
            Debug.Log(Step);

            // if(_step == MaxStep)    
        }

    }
}

