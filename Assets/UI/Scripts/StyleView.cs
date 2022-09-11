using UnityEngine;
using UnityEngine.UI;
using UniRx;

// namespace u1w.UI;
// {
    public class StyleView : MonoBehaviour
    {
        [SerializeField] Text text;
        [SerializeField] Image image;

        u1w.player.PlayerCore _playerCore;

        void Start()
        {
            _playerCore = u1w.player.PlayerCore.I;

            _playerCore.UIReLoad
            .Subscribe(_ => Refresh())
            .AddTo(this);
        }

        void Refresh(){
            text.text = _playerCore.HaveMagic.nowMagicType.ToString();

            var nowMagicType = _playerCore.HaveMagic.nowMagicType;

            if(nowMagicType == MagicType.Flame) image.color = Color.red;
            else if(nowMagicType == MagicType.Water) image.color = Color.blue;
            else if(nowMagicType == MagicType.Wind) image.color = Color.green;
        }
    }
// }