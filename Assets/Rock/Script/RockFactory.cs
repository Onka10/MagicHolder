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

        List<Vector3> rockies = new List<Vector3>();

        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.EnemyInsight)
            .Subscribe(_ => InstantRock())
            .AddTo(this);

            //FIXME
            // rockies[0] = new Vector3(0,0,0);
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
                if(x != 0 && z != 0 && !checkList())    break;
            }
            
            bool checkList(){
                for(int i=1;i<rockies.Count;i++){
                    if(rockies[i] == new Vector3(x, 1f, z))  return true;
                }
                return false;
            }

            // effect.transform.localPosition = new Vector3(x, 1f, z);
            rock.transform.localPosition = new Vector3(x, 1f, z);
            
            rockies.Add(rock.transform.position);
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

