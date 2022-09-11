using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;


/// <summary>
/// 攻撃可能
/// </summary>
public interface IDamaged
{
    public void Damaged(IGetMagic magic);
}

namespace u1w.Rock
{
    public class Rock : MonoBehaviour,IDamaged
    {
        public static readonly int MaxHP=7;
        public IReadOnlyReactiveProperty<int> HP => hp;
        private readonly ReactiveProperty<int> hp = new ReactiveProperty<int>(MaxHP);

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
            hp.Value -= (int)damage;

            Debug.Log("のこり"+hp);

            if(hp.Value <= 0){
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
            yield return new WaitForSeconds(3);
            //エフェクト再生 
            CameraShake.I.Shake(0.25f, 0.5f);
            view.PlayDestroy();
            SoundManager.I.PlayPlayerAttack();
            
            Destroy(this.gameObject);
        }
      
    }
}

