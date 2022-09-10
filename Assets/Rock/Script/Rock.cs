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
        RockFactory _rockFactory;
        [SerializeField] RockView view;

        void Start()
        {
            _rockFactory = RockFactory.I;
            //チェックと入手を兼ねている
            if(!new GetTile().GetTileObject(transform.position,out var result)) return;
            result.GetComponent<IOnRock>().LockOfRock();
        }

        public void Damaged(Magic magic){
            hp -= magic.GetAtk();
            

            if(hp <= 0){
                //エフェクト再生
                view.PlayDestroy();

                //マスのLockを解除
                //チェックと入手を兼ねている
                if(!new GetTile().GetTileObject(transform.position,out var result)) return;
                result.GetComponent<IOnRock>().UnLockOfRock();

                _rockFactory.DeadCall();
                ScoreManager.I.AddScore();
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

