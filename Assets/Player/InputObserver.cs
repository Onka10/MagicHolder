using System.Collections;
using System;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using UnityEngine.InputSystem;

namespace u1w.player
{
    public class InputObserver : MonoBehaviour
    {
            public IObservable<Unit> OnW=> _w;
            public IObservable<Unit> OnA => _a;
            public IObservable<Unit> OnS => _s;
            public IObservable<Unit> OnD => _d;
             public IObservable<Unit> OnCtrl => _ctrl;
            // public IObservable<Unit> OnSpace => _d;


            private readonly Subject<Unit> _w = new Subject<Unit>();          
            private readonly Subject<Unit> _a = new Subject<Unit>();
            private readonly Subject<Unit> _s = new Subject<Unit>();
            private readonly Subject<Unit> _d = new Subject<Unit>();
            private readonly Subject<Unit> _ctrl = new Subject<Unit>();


        private void Update()
        {
            // 現在のキーボード情報
            var current = Keyboard.current;

            // キーボード接続チェック
            if (current == null)    return;


            // 入力状態取得
            var wKey = current.wKey;
            var aKey = current.aKey;
            var sKey = current.sKey;
            var dKey = current.dKey;
            var ctrlKey = current.ctrlKey;
            var spaceKey = current.spaceKey;

            // Wキーが押された瞬間かどうか
            if (wKey.wasPressedThisFrame)   _w.OnNext(Unit.Default);

            // Aキーが押された瞬間かどうか
            if (aKey.wasPressedThisFrame)   _a.OnNext(Unit.Default);

            // Sキーが押された瞬間かどうか
            if (sKey.wasPressedThisFrame)   _s.OnNext(Unit.Default);

            // Dキーが押された瞬間かどうか
            if (dKey.wasPressedThisFrame)   _d.OnNext(Unit.Default);

            if (ctrlKey.wasPressedThisFrame)   _ctrl.OnNext(Unit.Default);

            // Spaceキーが押された瞬間かどうか
            if (spaceKey.wasPressedThisFrame)
            {
                Debug.Log("てすと");
            }
        }

    }
}

