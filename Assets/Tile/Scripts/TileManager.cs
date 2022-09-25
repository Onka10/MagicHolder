using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using System;
using u1w.Tiles;

namespace u1w.Tiles
{
    public class TileManager : Singleton<TileManager>
    {

        public UniTask FuncAsync => _uniTaskCompletionSource.Task;
        private readonly UniTaskCompletionSource _uniTaskCompletionSource = new UniTaskCompletionSource();

        public GameObject prefab;
        [SerializeField] TileMap _tileMap;

        void Start()
        {
            var result =  TileCreate.CreateBlockObject(this.gameObject,prefab);
            _tileMap = new TileMap(result.X,result.Y);
            //生成の終了通知
            _uniTaskCompletionSource.TrySetResult();
        }

        
        //結果を返却する
        public bool MovePlayer(Direction direction, out Vector3 result){
            _tileMap.PlayerMove(direction);
            // result = NextTiles[(int)direction].Pos;
            result = Vector3.back;
            // return NextTiles[(int)direction].OnLock
            return true;
        }
    }

}
