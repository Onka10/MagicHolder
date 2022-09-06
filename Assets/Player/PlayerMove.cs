using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] InputObserver _input;

        ITileForPlayer Iplay;
        public GameObject startTile;
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

            Iplay = startTile.GetComponent<ITileForPlayer>();
        }

        void Check(Direction d){
            //本来はチェックして実行
            this.gameObject.transform.position = Iplay.GetPos(d);
        }

    }
}
