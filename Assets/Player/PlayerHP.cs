using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public interface IPlayerHP
{
    public void Damage(int atk);
}

namespace u1w.player
{
    public class PlayerHP : MonoBehaviour,IPlayerHP
    {
        [SerializeField] GameObject ui;                   
        
        public static readonly int MaxHP = 100;
        public IReadOnlyReactiveProperty<int> HP => _hp;
        private readonly ReactiveProperty<int> _hp = new ReactiveProperty<int>(MaxHP);

        void Start(){
            _hp
            .Where(hp => hp <= 0)
            .Subscribe(_ =>GameOver())
            .AddTo(this);
        }

        public void Damage(int atk){
            _hp.Value -= atk;
        }

        void GameOver(){
            // IsGameOver=true;
            ui.SetActive(true);
        }
    }
}

