using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace u1w.Tiles
{
    [System.Serializable]
    public class TileMap
    {
        [SerializeField] TileID Player;
        Tile[,] Tiles;

        public TileMap(int x,int y){
            Tiles = new Tile[x, y];
        }

        public void PlayerMove(Direction direction){
            if(direction==Direction.north)  Player.Add(0,1);
            if(direction==Direction.east)   Player.Add(1,0);
            if(direction==Direction.south)   Player.Add(0,-1);
            if(direction==Direction.west)   Player.Add(-1,0);
        }

    }
}

[System.Serializable]
public struct TileID{
    public int X=>x;
    [SerializeField] private int x;

    public int Y=>y;
    [SerializeField] private int y;

    public TileID(int x,int y){
        this.x = x;
        this.y = y;
    }

    public void Add(int x,int y){
        this.x += x;
        this.y -= y;
    }
}

