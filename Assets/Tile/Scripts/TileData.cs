using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData
{
    public bool OnLock=false;

    public Vector3 Pos;

    public TileData(Vector3 pos){
        Pos = pos;
        OnLock = false;
    }

    public TileData(){
        OnLock = true;
    }
}
