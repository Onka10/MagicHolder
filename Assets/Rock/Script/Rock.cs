using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class Rock : MonoBehaviour
    {
        public int HP=>hp;
        private int hp=10;
        RockFactory _rockFactory;
        [SerializeField] RockView view;
        private MagicType magicType;

        void Start()
        {
            int rand = UnityEngine.Random.Range(0,3);
            magicType = Dictionaries.MagicTypeDictionary[rand];
            view.SetMaterial(rand);

            _rockFactory = RockFactory.I;
            //チェックと入手を兼ねている
            if(!new GetTile().GetTileObject(transform.position,out var result)) return;
            result.GetComponent<ILock>().LockOfRock();
        }

        public void Damaged(IGetMagic magic){
            // //ダメージ計算
            magic.GetDamage(out int atk);
            float damage = (float)atk * ThreeWay.CalcDamageRate(magic.GetMagicType(),magicType);
            hp -= (int)damage;
            SoundManager.I.PlayPlayerAttack();

            // Debug.Log("のこり"+hp);

            if(hp <= 0){
                //エフェクト再生
                view.PlayDestroy();

                //マスのLockを解除
                //チェックと入手を兼ねている
                if(!new GetTile().GetTileObject(transform.position,out var result)) return;
                result.GetComponent<ILock>().UnLockOfRock();

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

