using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;

public interface IPlayerMagic
{
    public void AddMagiCell(Color color);
    public void StyleChange();
}

namespace u1w.player
{
    public class PlayerMagicHold : MonoBehaviour
    {
        public IObservable<Unit> OnGetColor => _getColor;
        private readonly Subject<Unit> _getColor = new Subject<Unit>();
        public Magic _magic;


        public void AddMagiCell(Color color){
            _magic.Add(color);
            _getColor.OnNext(Unit.Default);
        }
    }
}

