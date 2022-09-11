using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.Tiles{
    public class Title : MonoBehaviour,IGetTileData,ILock,ILocked
    {
        #region プロパティ
        //色
        [SerializeField] public Color Color => _color.Value;
        public IReadOnlyReactiveProperty<Color> ColorReset => _color;
        private readonly ReactiveProperty<Color> _color = new ReactiveProperty<Color>();

        [SerializeField] bool IsFirstTile;
        TileManager _tileManager;

        TileData myTileData;
        private TileData[] NextTiles = new TileData[4];

        #endregion

        void Start(){
            //初期化
            myTileData = new TileData(this.gameObject.transform.position);
            SetColor();
            if(IsFirstTile) _color.Value = Color.black;

            GameManager.I.Ready2
            .Subscribe(_ => GetNextTile())
            .AddTo(this);

            //ずっと購読
            _tileManager = TileManager.I;
            _tileManager.ReCharge
            .Where(_ => _color.Value == Color.black)
            .Subscribe(_ => SetColor())
            .AddTo(this);
        }

        #region  private
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

            if (Physics.Raycast(northRay,out hit))  NextTiles[(int)Direction.north] = new TileData(hit.collider.gameObject.transform.position);
            else NextTiles[(int)Direction.north] = new TileData();

            if (Physics.Raycast(eastRay,out hit))   NextTiles[(int)Direction.east] = new TileData(hit.collider.gameObject.transform.position);
            else NextTiles[(int)Direction.east] = new TileData();

            if (Physics.Raycast(southRay,out hit))  NextTiles[(int)Direction.south] = new TileData(hit.collider.gameObject.transform.position);
            else NextTiles[(int)Direction.south] = new TileData();

            if (Physics.Raycast(westRay,out hit))   NextTiles[(int)Direction.west] = new TileData(hit.collider.gameObject.transform.position);
            else NextTiles[(int)Direction.west] = new TileData();
        }

        #endregion 

        #region IGetTileData
        public Color GetColor(){
            Color temp = _color.Value;
            _color.Value = Color.black;

            return temp;
        } 

        
        public bool GetNextPosition(Direction direction, out Vector3 result){
            result = NextTiles[(int)direction].Pos;
            return NextTiles[(int)direction].OnLock;
        }

        #endregion


        #region Rockからの命令
        public void LockOfRock(){
            //ロック
            myTileData = new TileData();

            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,1));
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(1,0,0));
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,-1));
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(-1,0,0));
            RaycastHit hit;

            if (Physics.Raycast(northRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))    obj.PleaseLock(Direction.north,myTileData);
            }

            if (Physics.Raycast(eastRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseLock(Direction.east,myTileData);
            }

            if (Physics.Raycast(southRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseLock(Direction.south,myTileData);
            }

            if (Physics.Raycast(westRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseLock(Direction.west,myTileData);
            }
        }

        public void UnLockOfRock(){
            //ロック解除
            myTileData = new TileData(this.gameObject.transform.position);
            
            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,1));
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(1,0,0));
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(0,0,-1));
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0f), new Vector3(-1,0,0));
            RaycastHit hit;

            if (Physics.Raycast(northRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))    obj.PleaseUnLock(Direction.north,myTileData);
            }

            if (Physics.Raycast(eastRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseUnLock(Direction.east,myTileData);
            }

            if (Physics.Raycast(southRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseUnLock(Direction.south,myTileData);
            }

            if (Physics.Raycast(westRay,out hit)){
                if(hit.collider.gameObject.TryGetComponent<ILocked>(out var obj))   obj.PleaseUnLock(Direction.west,myTileData);
            }
        }

        #endregion

        #region 隣からの命令
        public void PleaseLock(Direction from, TileData fromData){
            Direction fromMe;
            if(from == Direction.north) fromMe = Direction.south; 
            else if(from == Direction.east) fromMe = Direction.west; 
            else if(from == Direction.south) fromMe = Direction.north;
            else  fromMe = Direction.east;

            NextTiles[(int)fromMe] = fromData;
        }

        public void PleaseUnLock(Direction from, TileData fromData){
            Direction fromMe;
            if(from == Direction.north) fromMe = Direction.south; 
            else if(from == Direction.east) fromMe = Direction.west; 
            else if(from == Direction.south) fromMe = Direction.north;
            else  fromMe = Direction.east;

            NextTiles[(int)fromMe] = fromData;
        }
        #endregion 
    }
}