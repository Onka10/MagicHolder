using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.UI
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] Text text;

        void Start()
        {
            ScoreManager.I
            .Score
            .Subscribe(s => text.text =s.ToString())
            .AddTo(this);
        }
    }
}

