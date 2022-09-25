using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using u1w;

namespace u1w.player
{
    public class StyleChange : MonoBehaviour
    {
        [SerializeField] GameObject[] UnityChan = new GameObject[3];
        
        [SerializeField] PlayerStyle playerStyle;

        void Start()
        {
            playerStyle.NowStyle
            .Subscribe(_ => ChangeStyle())
            .AddTo(this);
        }
        void ChangeStyle(){
            foreach(Transform child in gameObject.transform){
                Destroy(child.gameObject);
            }

            // GameObject chara = Instantiate(UnityChan[(int)_playerCore.HaveMagic.nowStyle], Vector3.zero, Quaternion.identity);
            // chara.transform.SetParent(this.gameObject.transform);
            // chara.transform.localPosition = new Vector3(0,0,0);
            // chara.transform.localRotation = Quaternion.identity;
        }
    }
}

