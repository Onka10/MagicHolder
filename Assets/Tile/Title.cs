using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace u1w.Tile{
    public class Title : MonoBehaviour
    {
        #region プロパティ
        //色
        public Color Color => _color;
        [SerializeField]private Color _color;

        

        
        //移動先
        public Position PosID => _pos;
        [SerializeField] private Position _pos;
        #endregion

    }
}

