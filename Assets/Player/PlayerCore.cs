using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Cysharp.Threading.Tasks;
using u1w.player;

namespace u1w
{
    public class PlayerCore : Singleton<PlayerCore>
    {
        public Magic HaveMagic => _magic;
        private Magic _magic = new Magic();


        public bool IsGameOver=false;


        //最初は0,0のTileを入れておくこと！
        public GameObject NowTile => _nowTile;
        [SerializeField] private GameObject _nowTile;
        [SerializeField] InputObserver _input;
        [SerializeField] StepCounter _step;

        public IPlayerMove playerMove;
        public IPlayerStyle playerStyle;
        public IPlayerAttack playerAttack;
        public IPlayerHP playerHP;
        public IPlayerMagic playerMagic;

        void Start(){

            _input.OnCtrl
            .Subscribe(_ =>{
                playerStyle.StyleChange();
            })
            .AddTo(this);

            PhaseManager.I.State
            .Where(s => s==PhaseState.PlayerAttack)
            .Subscribe(_ => playerAttack.Attack())
            .AddTo(this);

            // _magic.nowStyle = MagicType.Flame;
        }


        /// <summary>
        /// 真下のタイルを入手
        /// </summary>
        public void GetTile(){
            //移動後に今の位置を取得

            //チェックと入手を兼ねている
            if(!new GetTile().GetTileObject(transform.position,out var result)) return;
            _nowTile = result;

            //色入手
            playerMagic.AddMagiCell(_nowTile.GetComponent<IGetTileData>().GetColor());
        }

        public void Damage(int atk){
            playerHP.Damage(atk);
        }
    }
}

