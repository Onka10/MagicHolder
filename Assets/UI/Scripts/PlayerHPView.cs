using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.UI
{
    public class PlayerHPView : MonoBehaviour
    {
        [SerializeField] Slider _hPSlider;
        [SerializeField] Text _text;
        [SerializeField] u1w.player.PlayerCore _hp;

        void Start()
        {
            _hPSlider.maxValue = (float)u1w.player.PlayerCore.MaxHP;
    
            _hp.HP
            .Subscribe(s =>{
                _hPSlider.value = (float)s;
                _text.text = s.ToString();
            })
            .AddTo(this);
        }
    }
}

