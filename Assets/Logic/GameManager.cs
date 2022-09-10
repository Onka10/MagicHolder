using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using System;

public class GameManager : Singleton<GameManager>
{

    public IReadOnlyReactiveProperty<GameState> State => _state;
    private readonly ReactiveProperty<GameState> _state = new ReactiveProperty<GameState>(GameState.Title);

    public Subject<Unit> Ready2 => _ready2; 
    private Subject<Unit> _ready2 = new Subject<Unit>();


    [SerializeField] u1w.Tiles.TileManager _tileManager;
    [SerializeField] u1w.player.PlayerCore _playerCore;


    // Start is called before the first frame update
    void Start()
    {
        GameFlow().Forget();
    }

    private async UniTaskVoid GameFlow(){
        //タイトル画面
        _state.Value = GameState.Title;

        //準備処理スタートの合図
        Debug.Log("ready");
        _state.Value = GameState.Ready;
        // await Ready();

        //準備が終わるまで待つ
        await UniTask.WhenAll(Ready());
        Debug.Log("準備終わり");

        //ゲーム開始
        _state.Value = GameState.InGame;
    }

    private async UniTask Ready(){
        //tileの生成
        await _tileManager.FuncAsync;
        await UniTask.Delay(500);
        Debug.Log("rayとばすよ");
        //rayを飛ばす指示
        _ready2.OnNext(Unit.Default);
    }
}
