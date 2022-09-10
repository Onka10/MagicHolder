using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.Tiles{
    public class Title : MonoBehaviour,ITileForPlayer,ITileForManager,IOnRock,ILocked
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
            .Subscribe(_ => GetNextTile())
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

        void GetNextTile(){
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

        public void LockOfRock(){
            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,1));
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(1,0,0));
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,-1));
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(-1,0,0));
            RaycastHit hit;

            if (Physics.Raycast(northRay,out hit)){
                if(!hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))
                    obj.PleaseLock(Direction.north);
            }


            if (Physics.Raycast(eastRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))
                obj.PleaseLock(Direction.east);
            }

            if (Physics.Raycast(southRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))
                obj.PleaseLock(Direction.south);
            }

            if (Physics.Raycast(westRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))
                obj.PleaseLock(Direction.west);
            }
        }

        public void UnLockOfRock(){
            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,1));
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(1,0,0));
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,-1));
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(-1,0,0));
            RaycastHit hit;

            if (Physics.Raycast(northRay,out hit))  hit.collider.gameObject.GetComponent<ILocked>().PleaseUnLock(Direction.north);

            if (Physics.Raycast(eastRay,out hit))   hit.collider.gameObject.GetComponent<ILocked>().PleaseUnLock(Direction.east);

            if (Physics.Raycast(southRay,out hit))  hit.collider.gameObject.GetComponent<ILocked>().PleaseUnLock(Direction.south);

            if (Physics.Raycast(westRay,out hit))   hit.collider.gameObject.GetComponent<ILocked>().PleaseUnLock(Direction.west);
        }

        public void PleaseLock(Direction from){
            Direction fromMe;
            if(from == Direction.north) fromMe = Direction.south; 
            else if(from == Direction.east) fromMe = Direction.west; 
            else if(from == Direction.south) fromMe = Direction.north;
            else  fromMe = Direction.east;

            next.SetEmpty(fromMe);
        }

        public void PleaseUnLock(Direction from){
            Direction fromMe;
            if(from == Direction.north) fromMe = Direction.south; 
            else if(from == Direction.east) fromMe = Direction.west; 
            else if(from == Direction.south) fromMe = Direction.north;
            else  fromMe = Direction.east;

            next.SetPos(fromMe,this.transform.position);
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

