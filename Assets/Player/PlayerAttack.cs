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
        PhaseManager _phaseManager;
        
        void Start(){
            _phaseManager = PhaseManager.I;
            _phaseManager.State
            .Where(s => s==PhaseState.PlayerAttack)
            .Subscribe(_ => Attack())
            .AddTo(this);
        }

        void Attack(){
            //見た目
            PlayView();


            Ray Ray = new Ray (this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Dictionaries.AttackDirDictionary[_playerMove.NowDirection]);

            RaycastHit hit;
            
            //デバッグ
            Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.blue,10f);
            
            if (Physics.Raycast(Ray,out hit)){
                hit.collider.gameObject.TryGetComponent<IAttack>(out IAttack attack);
                attack.Damaged(new Magic(1,1,1));
            }
        }

        void PlayView(){

        }

    }
}

