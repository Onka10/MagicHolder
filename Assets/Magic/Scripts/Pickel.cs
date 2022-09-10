using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Pickel : MonoBehaviour,IOutofDead
{
    // transformを取得
    // Transform myTransform;

    void Start()
    {
        // this.UpdateAsObservable()
        // .Subscribe(_ => Move())
        // .AddTo(this);
    }

    // void Move(){
    //     Vector3 localPos = this.transform.localPosition;
    //     // localPos.x = 1.0f;    // ローカル座標を基準にした、x座標を1に変更
    //     // localPos.y = 1.0f;    // ローカル座標を基準にした、y座標を1に変更
    //     localPos.z = 1.0f;    // ローカル座標を基準にした、z座標を1に変更

    //     this.transform.localPosition = localPos; // ローカル座標での座標を設定
    // }

    void Update(){
 
        // transformを取得
        Transform myTransform = this.transform;
 
        // ローカル座標での座標を取得
        Vector3 localPos = myTransform.localPosition;
        // localPos.x = 1.0f;    // ローカル座標を基準にした、x座標を1に変更
        // localPos.y = 1.0f;    // ローカル座標を基準にした、y座標を1に変更
        localPos.z =+ 0.01f;    // ローカル座標を基準にした、z座標を1に変更
        myTransform.localPosition += localPos; // ローカル座標での座標を設定
    }

    public void Dead(){
        Destroy(this);
    }
}
