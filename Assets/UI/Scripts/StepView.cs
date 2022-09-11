using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.UI
{
    public class StepView : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] u1w.player.StepCounter _step;

        void Start()
        {
            _step.Step
            .Subscribe(s => text.text =_step.Step.ToString())
            .AddTo(this);
        }
    }
}

