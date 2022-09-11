using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.player
{
    public class MagicView : MonoBehaviour
    {
        [SerializeField] Text textR;
        [SerializeField] Text textG;
        [SerializeField] Text textB;
        void Start()
        {
            PlayerCore.I.UIReLoad
            .Subscribe(_ => Refresh())
            .AddTo(this);
        }

        void Refresh(){
            textR.text = PlayerCore.I.HaveMagic.Flame.ToString();
            textB.text = PlayerCore.I.HaveMagic.Water.ToString();
            textG.text = PlayerCore.I.HaveMagic.Wind.ToString();
        }
    }
}

