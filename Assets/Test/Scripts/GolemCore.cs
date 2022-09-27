using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class GolemCore :MonoBehaviour
{
    public IReadOnlyReactiveProperty<int> State => state;
     private readonly ReactiveProperty<int> state = new ReactiveProperty<int>(0);
     [SerializeField] GolemMove move;
     [SerializeField] GolemAttack attack;

    //  [SerializeField] 
    void Start()
    {
        state
        .Where(s => s==2)
        .Subscribe(_ => move.Move())
        .AddTo(this);

        state
        .Where(s => s==3)
        .Subscribe(_ => attack.Attack())
        .AddTo(this);

        Ready2Idol().Forget();
    }

    async UniTask Ready2Idol(){
        await UniTask.Delay(1000);
        state.Value++;
    }

    public void Dead(){
        Destroy(this.gameObject);
    }

    public void Next(){
        state.Value++;
    }
}