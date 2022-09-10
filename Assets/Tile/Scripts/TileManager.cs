using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using System;

namespace u1w.Tiles
{
        public class TileManager : Singleton<TileManager>
    {
        // オブジェクトを生成する元となるPrefabへの参照を保持します。
        public GameObject prefabObj;

        public IObservable<Unit> ReCharge => _recharge;
        private readonly Subject<Unit> _recharge = new Subject<Unit>();

        public UniTask FuncAsync => _uniTaskCompletionSource.Task;
        private readonly UniTaskCompletionSource _uniTaskCompletionSource = new UniTaskCompletionSource();

        PhaseManager _phaseManager;

        [SerializeField] float xOffset = 1.5f;
        [SerializeField] float zOffset = 1.5f;

        void Start()
        {
            CreateBlockObject();

            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.TurnEnd)
            .Subscribe(_ => _recharge.OnNext(Unit.Default))
            .AddTo(this);
        }

        /// <Summary>
        /// Prefabからブロックとして使うオブジェクトを生成します。
        /// </Summary>
        void CreateBlockObject(){

            for (int j = 0; j < StageSetting.X; j++){
                for (int x = 0; x < StageSetting.Y; x++){
                    //0,0は生成済みだから無し
                    if(x==0 && j==0)    continue;

                    // ゲームオブジェクトを生成します。
                    //obj(x,y)で座標の位置
                    GameObject objPP = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objPM = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objMP = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);
                    GameObject objMM = Instantiate(prefabObj, Vector3.zero, Quaternion.identity);

                    // ゲームオブジェクトの親オブジェクトを設定します。
                    objPP.transform.SetParent(this.gameObject.transform);
                    objPM.transform.SetParent(this.gameObject.transform);
                    objMP.transform.SetParent(this.gameObject.transform);
                    objMM.transform.SetParent(this.gameObject.transform);

                    // ゲームオブジェクトの位置を設定します。
                    float xPos = xOffset * x;
                    float zPos = zOffset * j;

                    objPP.transform.localPosition = new Vector3(xPos, 0f, zPos);
                    objPM.transform.localPosition = new Vector3(xPos, 0f, zPos * -1);
                    objMP.transform.localPosition = new Vector3(xPos * -1, 0f, zPos);
                    objMM.transform.localPosition = new Vector3(xPos * -1, 0f, zPos * -1);
                }
            }

            //生成の終了通知
            _uniTaskCompletionSource.TrySetResult();

        }
    }

}
