using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicHolder
{
    public int Flame =>flame;
    private int flame;

    public int Water => water;
    private int water;

    public int Wind => wind;
    private int wind;

    public MagicHolder(){
        flame = 0;
        water = 0;
        wind  = 0;
    }
    public MagicHolder(int r,int g,int b){
        flame = r;
        water = b;
        wind  = g;
    }

    public void Add(Color c){
        if(c==Color.red)    flame++;
        if(c==Color.blue)   water++;
        if(c==Color.green)  wind++;
    }
}
