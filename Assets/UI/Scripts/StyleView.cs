using UnityEngine;
using UnityEngine.UI;
using UniRx;

namespace u1w
{
    public class StyleView : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Image image;
        [SerializeField] GameObject UI;

        u1w.player.PlayerCore _playerCore;
        [SerializeField]  u1w.player.StepCounter _step;

        void Start()
        {
            _playerCore = u1w.player.PlayerCore.I;

            _playerCore.OnStyleChange
            .Subscribe(_ => Refresh())
            .AddTo(this);

            _step.Step
            .Subscribe(s =>{
                if(_step.Step.Value == u1w.player.StepCounter.MaxStep)  UI.SetActive(true);
                else UI.SetActive(false);
            })
            .AddTo(this);
        }

        void Refresh(){
            text.text = _playerCore.HaveMagic.nowStyle.ToString();

            var nowMagicType = _playerCore.HaveMagic.nowStyle;

            if(nowMagicType == MagicType.Flame) image.color = Color.red;
            else if(nowMagicType == MagicType.Water) image.color = Color.blue;
            else if(nowMagicType == MagicType.Wind) image.color = Color.green;
        }
    }
}