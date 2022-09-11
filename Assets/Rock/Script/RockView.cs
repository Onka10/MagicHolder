using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class RockView : MonoBehaviour
    {
        //破壊
        public GameObject DestroyEffect;
        //攻撃
        public Animator anim;  //Animatorをanimという変数で定義する

        [SerializeField] Material[] typeMaterials = new Material[3];

        void Start(){
            PhaseManager.I.State
            .Where(s => s==PhaseState.EnemyAttack)
            .Subscribe(_ => PlayAttack())
            .AddTo(this);
        }

        void PlayAttack(){
            //Bool型のパラメーターであるblRotをTrueにする
            anim.SetTrigger("Play");
        }

        public void PlayDestroy(){
            //エフェクト再生
            GameObject effect = Instantiate(DestroyEffect, Vector3.zero, Quaternion.identity);
            effect.transform.SetParent(this.gameObject.transform);
            effect.transform.localPosition = new Vector3(0f, 0f, 0f);
        }

        public void SetMaterial(int type){
            this.gameObject.GetComponent<MeshRenderer>().material = typeMaterials[type];
        }        
    }
}

