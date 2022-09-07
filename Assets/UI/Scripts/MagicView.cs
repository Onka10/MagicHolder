using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.UI
{
    public class MagicView : MonoBehaviour
    {
        [SerializeField] Text textR;
        [SerializeField] Text textG;
        [SerializeField] Text textB;
        void Start()
        {
            u1w.player.PlayerCore.I.UIReLoad
            .Subscribe(_ => Refresh())
            .AddTo(this);
        }

        void Refresh(){
            textR.text = u1w.player.PlayerCore.I.MagicHolder.Flame.ToString();
            textB.text = u1w.player.PlayerCore.I.MagicHolder.Water.ToString();
            textG.text = u1w.player.PlayerCore.I.MagicHolder.Wind.ToString();
        }
    }
}

