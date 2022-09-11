using UnityEngine;
public interface IGetMagic{
    public void GetDamage(out int damage);
    public MagicType GetMagicType();
}

public class Magic:IGetMagic
{
    public MagicType nowMagicType;

    public int Flame =>flame;
    private int flame;

    public int Water => water;
    private int water;

    public int Wind => wind;
    private int wind;

    public Magic(){
        flame = 0;
        water = 0;
        wind = 0;
    }

    public Magic(int R,int G, int B){
        flame = R;
        water = B;
        wind = G;
    }


    //入力
    public void Add(Color c){
        if(c==Color.red)    flame++;
        if(c==Color.blue)   water++;
        if(c==Color.green)  wind++;
    }



    public void StyleChange(){
        if(nowMagicType == MagicType.Flame) nowMagicType = MagicType.Water;
        else if(nowMagicType == MagicType.Water) nowMagicType = MagicType.Wind;
        else if(nowMagicType == MagicType.Wind) nowMagicType = MagicType.Flame;
    }

    //外部出力
    public void GetDamage(out int damage){
        DelleteMagic();
        if(nowMagicType == MagicType.Flame) damage = Flame;
        if(nowMagicType == MagicType.Water) damage = Water;
        else damage = Wind;

        DelleteMagic();
    }
    void DelleteMagic(){
        if(nowMagicType == MagicType.Flame) flame = 0;
        else if(nowMagicType == MagicType.Water) water=0;
        else if(nowMagicType == MagicType.Wind) wind = 0;
    }

    public MagicType GetMagicType(){
        return nowMagicType;
    }
}


