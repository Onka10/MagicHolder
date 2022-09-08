using UnityEngine;

public class Magic
{
    int atk;

    int Flame;
    int Water;
    int Wind;


    public Magic(int R,int G, int B){
        Flame = R;
        Water = B;
        Wind = G;
    }

    public int GetAtk(){
        return 10;
    }
}
