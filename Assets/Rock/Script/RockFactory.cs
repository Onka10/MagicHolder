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

        [SerializeField]int rockCount=0;
        [SerializeField] int RockPower=5;

        PhaseManager _phaseManager;

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.EnemyInsight)
            .Subscribe(_ => InstantRock())
            .AddTo(this);
        }

        void InstantRock(){
            GameObject rock = Instantiate(RockPre, Vector3.zero, Quaternion.identity);
            rock.transform.SetParent(this.gameObject.transform);
            //FIXMEハードコード5,5あと、00の時のバグ潰し出来てない
            
            rock.transform.localPosition = new Vector3((float)Random.Range(0,StageSetting.X), 1f, (float)Random.Range(0,StageSetting.Y));
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

