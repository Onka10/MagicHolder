using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

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
            .Where(_ => _stepCounter.Step.Value > 0)
            .ThrottleFirst(TimeSpan.FromSeconds(.5))
            .Subscribe(_ => Check(Direction.north))
            .AddTo(this);

            _input.OnA
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Where(_ => _stepCounter.Step.Value > 0)
            .ThrottleFirst(TimeSpan.FromSeconds(.5))
            .Subscribe(_ => Check(Direction.west))
            .AddTo(this);

            _input.OnS
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Where(_ => _stepCounter.Step.Value > 0)
            .ThrottleFirst(TimeSpan.FromSeconds(.5))
            .Subscribe(_ => Check(Direction.south))
            .AddTo(this);

            _input.OnD
            .Where(_ => _phaseManager.State.Value == PhaseState.PlayerTurn)
            .Where(_ => _stepCounter.Step.Value > 0)
            .ThrottleFirst(TimeSpan.FromSeconds(.5))
            .Subscribe(_ => Check(Direction.east))
            .AddTo(this);

            _playerCore = u1w.player.PlayerCore.I;
        }

        void Check(Direction d){
            //ダメか確認
            if(_playerCore.NowTile.GetComponent<IGetTileData>().GetNextPosition(d,out var NextPos))  return;
            this.gameObject.transform.position = NextPos + new Vector3(0,.8f,0);

            //方向を変える
            this.gameObject.transform.eulerAngles = Dictionaries.OwnDirDictionary[d];
            NowDirection = d;

            _stepCounter.Count();
            _playerCore.GetTile();
            SoundManager.I.PlayerMove();
        }

    }
}

