using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Dictionaries
{
    static public Dictionary<Direction, Vector3 > OwnDirDictionary = new Dictionary<Direction, Vector3 >(){
        {Direction.north, new Vector3(0,0,0)},
        {Direction.east, new Vector3(0,90,0)},
        {Direction.south, new Vector3(0,180,0)},
        {Direction.west, new Vector3(0,270,0)},
    };

    static public Dictionary<Direction, Vector3 > AttackDirDictionary = new Dictionary<Direction, Vector3 >(){
        {Direction.north, Vector3.forward},
        {Direction.east, Vector3.right},
        {Direction.south, Vector3.back},
        {Direction.west, Vector3.left},
    };


    static public Dictionary<int, MagicType> MagicTypeDictionary = new Dictionary<int, MagicType>(){
        {0, MagicType.Flame},
        {1, MagicType.Water},
        {2, MagicType.Wind},
    };
}