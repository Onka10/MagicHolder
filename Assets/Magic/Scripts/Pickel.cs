using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class Pickel : MonoBehaviour,IOutofDead
{
    [SerializeField] Material[] materials = new Material[3];

    void Start()
    {
        // this.UpdateAsObservable()
        // .Subscribe(_ => Move())
        // .AddTo(this);

        StartCoroutine("TimeOut");
    }

    IEnumerator TimeOut(){
        //3秒停止
        yield return new WaitForSeconds(3);
        Dead();
    }

    public void SetMaterial(int i){
        this.gameObject.GetComponent<Renderer>().material = materials[i];
    }

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
        Destroy(this.gameObject);
    }
}
