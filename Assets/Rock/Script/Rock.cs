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

        void Start()
        {
            // DestroyEffect.GetComponent<ParticleSystem>().main.stopAction = ParticleSystemStopAction.Callback;
        }

        public void Damaged(Magic magic){
            hp -= magic.GetAtk();
            
            

            if(hp <= 0){
                Debug.Log("攻撃されました"+hp);
                GameObject effect = Instantiate(DestroyEffect, Vector3.zero, Quaternion.identity);
                effect.transform.SetParent(this.gameObject.transform);
                effect.transform.localPosition = new Vector3(0f, 0f, 0f);

                // Destroy(this.gameObject);
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

