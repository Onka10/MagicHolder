using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.Tile{
    public class Title : MonoBehaviour,ITileForPlayer,ITileForManager
    {
        #region プロパティ
        //色
        [SerializeField] public Color Color => _color.Value;
        public IReadOnlyReactiveProperty<Color> ColorReset => _color;
        private readonly ReactiveProperty<Color> _color = new ReactiveProperty<Color>();

        
        //自身の座標
        public Vector3 Pos => _pos;
        [SerializeField] private Vector3 _pos;

        //移動先
        [SerializeField] private Vector3[] Dire = new Vector3[4];

        [SerializeField] float cubeHalf=0.5f;

        TileManager _tileManager;

        [SerializeField] bool IsFirstTile;

        public static int XID=0;
        public static int YID=0;

        #endregion

        void Start(){
            _pos = this.gameObject.transform.position;
            SetColor();
            if(IsFirstTile) _color.Value = Color.black;

            GameManager.I.Ready2
            .Subscribe(_ => GetRay())
            .AddTo(this);

            _tileManager = TileManager.I;
            _tileManager.ReCharge
            .Where(_ => _color.Value == Color.black)
            .Subscribe(_ => SetColor())
            .AddTo(this);
        }

        void SetColor(){
            int rand = UnityEngine.Random.Range(0,3);

            if(rand == 0)      _color.Value = Color.red;
            else if(rand == 1) _color.Value = Color.blue;
            else if(rand == 2) _color.Value = Color.green;
        }

        void GetRay(){
            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,1));
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(1,0,0));
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,-1));
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(-1,0,0));
            RaycastHit hit;
            
            //デバッグ
            // Debug.DrawRay(northRay.origin, northRay.direction * 10, Color.red,10f);

            if (Physics.Raycast(northRay,out hit)){
                //なんか上手くいかない if (TryGetComponent<ITileForManager>(out ITileForManager tile))
                // Debug.Log ("Rayが当たった"+ hit.collider.gameObject.name);
                Dire[0] = hit.collider.gameObject.transform.position;
            }

            if (Physics.Raycast(eastRay,out hit)){
                Dire[1] = hit.collider.gameObject.transform.position;
            }

            if (Physics.Raycast(southRay,out hit)){
                Dire[2] = hit.collider.gameObject.transform.position;
            }

            if (Physics.Raycast(westRay,out hit)){
                Dire[3] = hit.collider.gameObject.transform.position;
            }
        }

        public Vector3 GetPos(Direction dir){
            Vector3 pos = new Vector3();

            pos = Dire[(int)dir];
            return pos;
        }

        public void DeleteColor(){
            _color.Value = Color.black;
        }

        public void SetID(){
            
        }
    }
}

