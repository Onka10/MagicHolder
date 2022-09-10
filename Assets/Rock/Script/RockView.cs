using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class RockView : MonoBehaviour
    {

        public GameObject DestroyEffect;

        void Start()
        {
        }

        public void PlayDestroy(){
            //エフェクト再生
            GameObject effect = Instantiate(DestroyEffect, Vector3.zero, Quaternion.identity);
            effect.transform.SetParent(this.gameObject.transform);
            effect.transform.localPosition = new Vector3(0f, 0f, 0f);
        }        
    }
}

