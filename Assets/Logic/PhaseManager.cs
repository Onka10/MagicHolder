using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace u1w
{
    public class PhaseManager : Singleton<PhaseManager>
    {

        public bool CanMove => _canMove;
        private bool _canMove=false;

        [SerializeField] u1w.player.StepCounter _stepCounter;
        [SerializeField] u1w.Rock.RockFactory _rockFactory;
        [SerializeField] u1w.player.PlayerAttack _playerAttack;

        void Start()
        {
            GameManager.I.State
            .Where(s => s==GameState.InGame)
            .Subscribe(_ => PhaseFlow().Forget())
            .AddTo(this);
        }

        private async UniTaskVoid PhaseFlow(){
            
            while(true){
                //色々初期化
                //歩数が決まる今は固定。色をリフレッシュ。
                _stepCounter.InitData();
                // Debug.Log("初期化");

                //岩を出現させる
                _rockFactory.InstantRock();
                //次の岩予測が公開
                // Debug.Log("岩フェーズ");

                //プレイヤー移動フェーズ
                Debug.Log("プレイヤー移動開始");
                _canMove = true;

                // await _stepCounter.StepAsync;
                await UniTask.WaitUntil(() => _stepCounter.TurnEnd);

                _canMove = false;

                //向きかえ？未定

                //魔法発動！
                _playerAttack.Attack();
                Debug.Log("攻撃");
                await UniTask.Delay(1000);

                //生存している岩が攻撃を行う
                // Debug.Log("岩攻撃");
                await UniTask.Delay(1000);

                //終わり
            }

        }

    }
}

