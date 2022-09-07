using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w
{
    public class PhaseManager : Singleton<PhaseManager>
    {

        public bool CanMove => _canMove;
        private bool _canMove;

        void Start()
        {
            GameManager.I.State
            .Where(s => s==GameState.InGame)
            .Subscribe(_ => PhaseFlow().Forget())
            .AddTo(this);
        }

        private async UniTaskVoid PhaseFlow(){
            //色々初期化
            //歩数が決まる今は固定。色をリフレッシュ。

            //岩を出現させる
            //次の岩予測が公開

            //プレイヤー移動フェーズ
            _canMove = true;

            await UniTask.Delay(1000);

            //向きかえ？未定

            //魔法発動！

            //生存している岩が攻撃を行う

            //終わり

        }

    }
}

