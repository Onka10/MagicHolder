using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class RockFactory : Singleton<RockFactory>
    {
        // オブジェクトを生成する元となるPrefabへの参照を保持します。
        public GameObject RockPre;
        public GameObject SpawnEffect;

        [SerializeField]int rockCount=0;
        [SerializeField] int RockPower=5;

        PhaseManager _phaseManager;

        // List<int[]> rockies = new List<int[]>();

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.EnemyInsight)
            .Subscribe(_ => InstantRock())
            .AddTo(this);
        }

        void InstantRock(){
            //エフェクト再生
            // GameObject effect = Instantiate(SpawnEffect, Vector3.zero, Quaternion.identity);
            // effect.transform.SetParent(this.gameObject.transform);

            GameObject rock = Instantiate(RockPre, Vector3.zero, Quaternion.identity);
            rock.transform.SetParent(this.gameObject.transform);
            //FIXMEハードコード5,5あと、00の時のバグ潰し出来てない
            
            float x;
            float z;

            while(true){
                x = (float)Random.Range(0,StageSetting.X);
                z = (float)Random.Range(0,StageSetting.Y);
                //チェック
                if(x != 0 && z != 0)    break;
            }
            

            // effect.transform.localPosition = new Vector3(x, 1f, z);
            rock.transform.localPosition = new Vector3(x, 1f, z);
            
            rockCount++;
        }

        public int GetAtk(){
            return rockCount * RockPower;
        }

        public void DeadCall(){
            rockCount-=1;
        }

    }
}

