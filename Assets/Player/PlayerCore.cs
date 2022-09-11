using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using Cysharp.Threading.Tasks;

namespace u1w.player
{
    public class PlayerCore : Singleton<PlayerCore>
    {
        public Magic HaveMagic => _magic;
        private Magic _magic = new Magic();

        public IObservable<Unit> UIReLoad => _reload;
        private readonly Subject<Unit> _reload = new Subject<Unit>();

        public static readonly int MaxHP = 100;
        public IReadOnlyReactiveProperty<int> HP => _hp;
        private readonly ReactiveProperty<int> _hp = new ReactiveProperty<int>(MaxHP);

        public UniTask GameOverAsync => _uniTaskCompletionSource.Task;
        private readonly UniTaskCompletionSource _uniTaskCompletionSource = new UniTaskCompletionSource();

        public bool IsGameOver=false;


        //最初は0,0のTileを入れておくこと！
        public GameObject NowTile => _nowTile;
        [SerializeField]private GameObject _nowTile;
        [SerializeField] InputObserver _input;
        [SerializeField] StepCounter _step;

        void Start(){
            _hp
            .Where(hp => hp <= 0)
            .Subscribe(_ =>GameOver())
            .AddTo(this);

            _input.OnCtrl
            .Where(_ => _step.Step.Value ==0)
            .Subscribe(_ =>{
                _magic.StyleChange();
                _reload.OnNext(Unit.Default);
            })
            .AddTo(this);

            _magic.nowMagicType = MagicType.Flame;
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
            var nowColor = _nowTile.GetComponent<ITileForPlayer>().Color;
            GotColor(nowColor);

            //回収済み
            _nowTile.GetComponent<ITileForPlayer>().DeleteColor();
        }



        void GotColor(Color color){
            _magic.Add(color);
            _reload.OnNext(Unit.Default);
        }

        public void Damage(int atk){
            _hp.Value -= atk;
        }

        void GameOver(){
            _uniTaskCompletionSource.TrySetResult();
            IsGameOver=true;
        }
    }
}

