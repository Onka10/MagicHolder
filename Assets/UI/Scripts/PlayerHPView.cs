using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w.player
{
    public class PlayerHPView : MonoBehaviour
    {
        [SerializeField] Slider _hPSlider;
        [SerializeField] Text _text;
        [SerializeField] PlayerHP _hp;

        void Start()
        {
            _hPSlider.maxValue = (float)PlayerHP.MaxHP;
    
            _hp.HP
            .Subscribe(s =>{
                _hPSlider.value = (float)s;
                _text.text = s.ToString();
            })
            .AddTo(this);
        }
    }
}

