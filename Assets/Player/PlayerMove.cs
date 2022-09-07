using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] InputObserver _input;
        PlayerCore _playerCore;

        // Start is called before the first frame update
        void Start()
        {
            _input.OnW
            .Subscribe(_ => Check(Direction.north))
            .AddTo(this);

            _input.OnA
            .Subscribe(_ => Check(Direction.west))
            .AddTo(this);

            _input.OnS
            .Subscribe(_ => Check(Direction.south))
            .AddTo(this);

            _input.OnD
            .Subscribe(_ => Check(Direction.east))
            .AddTo(this);

            _playerCore = u1w.player.PlayerCore.I;
        }

        void Check(Direction d){
            //本来は壁かどうかチェックして実行
            this.gameObject.transform.position = _playerCore.NowTile.GetComponent<ITileForPlayer>().GetPos(d);
            //オフセット
            this.gameObject.transform.position += new Vector3(0,2,0);

            _playerCore.GetTile();
        }

    }
}

