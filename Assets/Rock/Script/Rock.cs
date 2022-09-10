using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class Rock : MonoBehaviour,IAttack
    {
        public int HP=>hp;
        private int hp=10;

        public GameObject DestroyEffect;
        RockFactory _rockFactory;

        void Start()
        {
            _rockFactory = RockFactory.I;
        }

        public void Damaged(Magic magic){
            hp -= magic.GetAtk();
            

            if(hp <= 0){
                //エフェクト再生
                GameObject effect = Instantiate(DestroyEffect, Vector3.zero, Quaternion.identity);
                effect.transform.SetParent(this.gameObject.transform);
                effect.transform.localPosition = new Vector3(0f, 0f, 0f);

                _rockFactory.DeadCall();
                StartCoroutine("Destroy");
            }
        }        

        IEnumerator Destroy()
        {
            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
      
    }
}

