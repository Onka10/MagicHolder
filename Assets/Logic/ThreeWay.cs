public static class ThreeWay{

    public static float CalcDamageRate(MagicType me, MagicType notMe){
        //あいこ
        if (me == notMe)
        {
            return 1f;
        }

        //効果バツグン
        if (MeWinIs() == notMe)
        {
            return 2f;
        }

        //いまひとつ
        return 0.5f;


        MagicType MeWinIs(){
            if(me == MagicType.Flame)   return MagicType.Wind;
            else if(me == MagicType.Water) return MagicType.Flame;
            else  return MagicType.Water;
        }
    }

}