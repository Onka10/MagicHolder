using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] InputObserver _input;
        [SerializeField] StepCounter _stepCounter;

        PhaseManager _phaseManager;

        PlayerCore _playerCore;

        public Direction NowDirection;

        // Start is called before the first frame update
        void Start()
        {
            _phaseManager = PhaseManager.I;

            _input.OnW
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Subscribe(_ => Check(Direction.north))
            .AddTo(this);

            _input.OnA
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Subscribe(_ => Check(Direction.west))
            .AddTo(this);

            _input.OnS
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Subscribe(_ => Check(Direction.south))
            .AddTo(this);

            _input.OnD
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Subscribe(_ => Check(Direction.east))
            .AddTo(this);

            _playerCore = u1w.player.PlayerCore.I;
        }

        void Check(Direction d){
            //ダメか確認
            if(!_playerCore.NowTile.GetComponent<ITileForPlayer>().GetNextPosition().CanGetPos(d))  return;
  

            this.gameObject.transform.position = _playerCore.NowTile.GetComponent<ITileForPlayer>().GetNextPosition().GetPos(d);
            //オフセット
            this.gameObject.transform.position += new Vector3(0,.8f,0);

            //方向を変える
            this.gameObject.transform.eulerAngles = Dictionaries.OwnDirDictionary[d];
            NowDirection = d;

            _stepCounter.Count();
            _playerCore.GetTile();
        }

    }
}

