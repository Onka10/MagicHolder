using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace u1w
{
    public class PhaseManager : Singleton<PhaseManager>
    {
        public IReadOnlyReactiveProperty<PhaseState> State => _state;
        private readonly ReactiveProperty<PhaseState> _state = new ReactiveProperty<PhaseState>();

        [SerializeField] u1w.player.StepCounter _stepCounter;
        [SerializeField] u1w.player.PlayerCore _playerCore;

        void Start()
        {
            GameManager.I.State
            .Where(s => s==GameState.InGame)
            .Subscribe(_ => PhaseFlow().Forget())
            .AddTo(this);
        }

        private async UniTaskVoid PhaseFlow(){
            
            while(true){
                //準備
                _state.Value = PhaseState.Ready;
                
                //岩出現:岩出現、TODO 出現予想
                _state.Value = PhaseState.EnemyInsight;

                //プレイヤー移動
                _state.Value = PhaseState.PlayerTurn;
                Debug.Log("プレイヤー移動開始");
                await UniTask.WaitUntil(() => _stepCounter.TurnEnd);

                //魔法発動
                _state.Value = PhaseState.PlayerAttack;
                Debug.Log("プレイヤー攻撃");
                await UniTask.Delay(2000);

                //岩が攻撃:攻撃とアニメーション終了まち
                _state.Value = PhaseState.EnemyAttack;
                Debug.Log("岩攻撃");
                await UniTask.Delay(1000);
                
                //終了判定
                if(_playerCore.IsGameOver) break;

                //ターンエンド処理:色蘇生
                _state.Value = PhaseState.TurnEnd;

                //終わり
            }

            Debug.Log("ゲームオーバー");

        }

    }
}

