using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DestroyColider : MonoBehaviour
{
    void Start()
    {
        // Playerと衝突したら、Playerは死亡する
        this.OnCollisionEnterAsObservable()
        .Subscribe(hit => DestroyObject(hit))
        .AddTo(this);
    }

    void DestroyObject(Collision hit){
        if(hit.gameObject.TryGetComponent<IOutofDead>(out IOutofDead dead))
        {
            dead.Dead();
        }
    }
}

public interface IOutofDead{
    public void Dead();
}
