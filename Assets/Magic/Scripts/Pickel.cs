using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Pickel : MonoBehaviour
{
    // void Start()
    // {
    //     this.UpdateAsObservable()
    //     .Subscribe(_ => Move())
    //     .AddTo(this);
    // }

    // void Move(){
    //     Vector3 localPos = this.transform.localPosition;
    //     // localPos.x = 1.0f;    // ローカル座標を基準にした、x座標を1に変更
    //     // localPos.y = 1.0f;    // ローカル座標を基準にした、y座標を1に変更
    //     localPos.z = 1.0f;    // ローカル座標を基準にした、z座標を1に変更

    //     this.transform.localPosition = localPos; // ローカル座標での座標を設定
    // }

    void Update(){
        this.gameObject.transform.Translate(.1f,0,.1f);
    }
}
