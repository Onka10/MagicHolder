using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

namespace u1w.player
{
    public class PlayerCore : Singleton<PlayerCore>
    {
        public MagicHolder MagicHolder => _magicHolder;
        private MagicHolder _magicHolder = new MagicHolder();

        public IObservable<Unit> UIReLoad => _reload;
        private readonly Subject<Unit> _reload = new Subject<Unit>();


        //最初は0,0のTileを入れておくこと！
        public GameObject NowTile => _nowTile;
        [SerializeField]private GameObject _nowTile;

        public void GetTile(){
            //移動後に今の位置を取得
            Ray Ray = new Ray (transform.position + new Vector3 (0, 0, 0), Vector3.down);
            RaycastHit hit;

            //デバッグ
            Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.red,10f);

            if (Physics.Raycast(Ray,out hit)){
                //タイル入手
                _nowTile = hit.collider.gameObject;
            }

            //色入手
            var nowColor = _nowTile.GetComponent<ITileForPlayer>().Color;
            GotColor(nowColor);

            //回収済み
            _nowTile.GetComponent<ITileForPlayer>().DeleteColor();
        }


        /// <summary>
        /// 色をチャージさせる
        /// </summary>
        void GotColor(Color color){
            _magicHolder.Add(color);
            _reload.OnNext(Unit.Default);
        }
    }
}

