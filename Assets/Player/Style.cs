using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style
{
    public MagicType nowStyle;

    public Style(){
        nowStyle = MagicType.Flame;
    }

    public void StyleChange(){
        if(nowStyle == MagicType.Flame) nowStyle = MagicType.Water;
        else if(nowStyle == MagicType.Water) nowStyle = MagicType.Wind;
        else if(nowStyle == MagicType.Wind) nowStyle = MagicType.Flame;
    }

}
