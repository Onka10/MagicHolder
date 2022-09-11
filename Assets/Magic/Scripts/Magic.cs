using UnityEngine;
public interface IGetMagic{
    public void GetDamage(out int damage);
    public MagicType GetMagicType();
}

public class Magic:IGetMagic
{
    public MagicType nowStyle;

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
        if(nowStyle == MagicType.Flame) nowStyle = MagicType.Water;
        else if(nowStyle == MagicType.Water) nowStyle = MagicType.Wind;
        else if(nowStyle == MagicType.Wind) nowStyle = MagicType.Flame;
    }

    //外部出力
    public void GetDamage(out int damage){
        DelleteMagic();
        if(nowStyle == MagicType.Flame) damage = Flame;
        if(nowStyle == MagicType.Water) damage = Water;
        else damage = Wind;

        DelleteMagic();
    }
    void DelleteMagic(){
        if(nowStyle == MagicType.Flame) flame = 0;
        else if(nowStyle == MagicType.Water) water=0;
        else if(nowStyle == MagicType.Wind) wind = 0;
    }

    public MagicType GetMagicType(){
        return nowStyle;
    }
}


