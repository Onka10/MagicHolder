using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

namespace u1w.Tile
{
    public class TileView : MonoBehaviour
    {
        // マテリアルを保持します。
        public Material flame;
        public Material water;
        public Material wind;
        public Material none;

        [SerializeField] Tile.Title _tile;

        [SerializeField] MeshRenderer _mesh;
        void Start(){
            _tile.ColorR
            .Subscribe(color => MaterialChange(color))
            .AddTo(this);
        }

        void MaterialChange(Color c){
            if(c == Color.red)      _mesh.material = flame;
            else if(c == Color.green) _mesh.material = wind;
            else if(c == Color.blue) _mesh.material = water;
            else if(c == Color.black) _mesh.material = none;
        }
    }



}
