using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.Tiles{
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

        private NextPosition next;

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
            next = new NextPosition();

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

            if (Physics.Raycast(northRay,out hit))  next.SetPos(Direction.north, hit.collider.gameObject.transform.position);
            else next.SetEmpty(Direction.north);

            if (Physics.Raycast(eastRay,out hit))   next.SetPos(Direction.east, hit.collider.gameObject.transform.position);
            else next.SetEmpty(Direction.east);

            if (Physics.Raycast(southRay,out hit))  next.SetPos(Direction.south, hit.collider.gameObject.transform.position);
            else next.SetEmpty(Direction.south);

            if (Physics.Raycast(westRay,out hit))   next.SetPos(Direction.west, hit.collider.gameObject.transform.position);
            else next.SetEmpty(Direction.west);
        }

        public void DeleteColor(){
            _color.Value = Color.black;
        }

        public void SetID(int x, int y){
            XID = x;
            YID = y;
        }

        public IGetNext GetNextPosition(){
            return next;
        }
    }
    public class NextPosition:IGetNext{
        private Vector3[] Dire = new Vector3[4];
        
        public NextPosition(){}
        
        public void SetPos(Direction dir, Vector3 pos){
            Dire[(int)dir] = pos;
        }

        public void SetEmpty(Direction dir){
            Dire[(int)dir] = new Vector3(99f,99f,99f);
        }

        public bool CanGetPos(Direction dir){
            if(Dire[(int)dir] == new Vector3(99f,99f,99f)) return false;
            else    return true;
        }

        public Vector3 GetPos(Direction dir){
            return Dire[(int)dir];
        }
    }


}

