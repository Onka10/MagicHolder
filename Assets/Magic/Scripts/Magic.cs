using UnityEngine;
public interface IGetMagic{
    // public void GetDamage(out int damage);
    // public MagicType GetMagicType();
}

public class Magic:IGetMagic
{
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
        if(c==Color.red){
            flame++;
            flame =  Mathf.Clamp(flame, 0, 10);
        }
        if(c==Color.blue){
            water++;
            water = Mathf.Clamp(water, 0, 10);
        }   
        if(c==Color.green){
            wind++;
            wind = Mathf.Clamp(wind, 0, 10);
        }  
    }



    //外部出力
    // public void GetDamage(out int damage){
    //     if(nowStyle == MagicType.Flame) damage = Flame;
    //     if(nowStyle == MagicType.Water) damage = Water;
    //     else damage = Wind;

    //     DeleteMagic();
    // }

    //攻撃したらダメージ計算後に、外れたらすぐに実行する
    // public void DeleteMagic(MagicType nowStyle){
    //     if(nowStyle == MagicType.Flame) flame = 0;
    //     else if(nowStyle == MagicType.Water) water=0;
    //     else if(nowStyle == MagicType.Wind) wind = 0;
    // }

    // public MagicType GetMagicType(){
    //     return nowStyle;
    // }
}


