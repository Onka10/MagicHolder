using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

namespace u1w.player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] PlayerMove _playerMove;

        
        void Start()
        {
            
        }

        public void Attack(){
            //見た目
            PlayView();


            Ray Ray = new Ray (this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Dictionaries.AttackDirDictionary[_playerMove.NowDirection]);

            RaycastHit hit;
            
            //デバッグ
            Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.blue,10f);
            
            if (Physics.Raycast(Ray,out hit)){
                hit.collider.gameObject.TryGetComponent<IAttack>(out IAttack attack);
                attack.Damaged();
            }
        }

        void PlayView(){

        }

    }
}

