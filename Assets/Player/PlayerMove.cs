using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] InputObserver _input;

        public GameObject NowTile;

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
        }

        void Check(Direction d){
            //本来はチェックして実行
            this.gameObject.transform.position = NowTile.GetComponent<ITileForPlayer>().GetPos(d);
            //オフセット
            this.gameObject.transform.position += new Vector3(0,2,0);

            
            //移動後に今の位置を取得
            Ray Ray = new Ray (transform.position + new Vector3 (0, 0, 0), Vector3.down);
            RaycastHit hit;

            //デバッグ
            Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.red,10f);

            if (Physics.Raycast(Ray,out hit)){
                NowTile = hit.collider.gameObject;
            }
        }

    }
}

