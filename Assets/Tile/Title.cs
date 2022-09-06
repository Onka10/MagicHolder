using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace u1w.Tile{
    public class Title : MonoBehaviour,ITileForPlayer,ITileForManager
    {
        #region プロパティ
        //色
        public Color Color => _color;
        [SerializeField]private Color _color;
        
        //自身の座標
        public Vector3 Pos => _pos;
        [SerializeField] private Vector3 _pos;

        //移動先
        [SerializeField] private Vector3[] Dire = new Vector3[4];

        [SerializeField] float cubeHalf=0.5f;
        #endregion

        void Start(){
            _pos = this.gameObject.transform.position;
            SetColor();
            RayTest();
        }

        void SetColor(){
            int rand = UnityEngine.Random.Range(0,3);

            if(rand == 0)      _color = Color.red;
            else if(rand == 1) _color = Color.blue;
            else if(rand == 2) _color = Color.green;
        }

        void RayTest(){
            Ray northRay = new Ray (transform.position + new Vector3 (0, 0, 0.4f), Vector3.forward);
            Ray eastRay = new Ray (transform.position + new Vector3 (0, 0, 0.4f), Vector3.left);
            Ray southRay = new Ray (transform.position + new Vector3 (0, 0, 0.4f), Vector3.back);
            Ray westRay = new Ray (transform.position + new Vector3 (0, 0, 0.4f), Vector3.right);
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

            if(dir == Direction.north) pos =  Dire[0];
            else if(dir == Direction.east) pos =  Dire[1];
            else if(dir == Direction.south) pos =  Dire[2];
            else if(dir == Direction.west) pos =  Dire[2];

            return pos;
        }
    }
}

