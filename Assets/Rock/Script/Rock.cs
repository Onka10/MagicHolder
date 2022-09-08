using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.Rock
{
    public class Rock : MonoBehaviour,IAttack
    {
        public int HP=10;

        void Start()
        {
            
        }

        public void Damaged(){
            Debug.Log("攻撃されました");
        }

    }
}

