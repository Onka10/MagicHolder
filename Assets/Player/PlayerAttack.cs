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

        [SerializeField] GameObject Axe;
        [SerializeField] PlayerCore _playerCore;
        
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
            SoundManager.I.PlayMagic();

            Ray Ray = new Ray (this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Dictionaries.AttackDirDictionary[_playerMove.NowDirection]);
            RaycastHit hit;
            
            //デバッグ
            Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.blue,10f);
            
            if (Physics.Raycast(Ray,out hit)){
                if(hit.collider.gameObject.TryGetComponent<IDamaged>(out IDamaged attack)){
                    attack.Damaged(_playerCore.HaveMagic);
                }
            }
        }

        void PlayView(){
            float y= Dictionaries.AttackDirDictionary[_playerMove.NowDirection].y;
            GameObject axe = Instantiate(Axe, this.transform.position, Quaternion.Euler(0,y,0));
            axe.transform.SetParent(this.gameObject.transform);
        }

    }
}

