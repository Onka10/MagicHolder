using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public interface IPlayerAttack
{
    public void Attack();
}

namespace u1w.player
{
    public class PlayerAttack : MonoBehaviour,IPlayerAttack
    {
        [SerializeField] PlayerMove _playerMove;
        PhaseManager _phaseManager;

        [SerializeField] GameObject Axe;
        [SerializeField] GameObject[] Axes = new GameObject[3];
        [SerializeField] PlayerCore _playerCore;

        [SerializeField] PlayerFacade _playerFacade;

        public void Attack(){
            // //見た目
            // PlayView();
            // SoundManager.I.PlayMagic();

            // Ray Ray = new Ray (this.transform.position + new Vector3(0.0f, 0.0f, 0.0f), Dictionaries.AttackDirDictionary[_playerMove.NowDirection]);
            // RaycastHit hit;
            
            // //デバッグ
            // Debug.DrawRay(Ray.origin, Ray.direction * 10, Color.blue,10f);
            
            // if (Physics.Raycast(Ray,out hit)){
            //     if(hit.collider.gameObject.TryGetComponent<IDamaged>(out IDamaged attack)){
            //         attack.Damaged(_playerCore.HaveMagic);
            //     }
            // }else{
            //     // _playerCore.HaveMagic.DeleteMagic();
            // }


            //TODOピッケルを生成する。ピッケルにダメージの値を入れる
            float y= Dictionaries.AttackDirDictionary[_playerMove.NowDirection].y;
            // GameObject axe = Instantiate(Axes[(int)_playerCore.HaveMagic.nowStyle], this.transform.position, Quaternion.Euler(0,y,0));
            // axe.transform.SetParent(this.gameObject.transform);
            // axe.GetComponent<Pickel>().SetMaterial();

            Debug.Log("攻撃");

        }

        void PlayView(){
            
            // GameObject axe = Instantiate(Axes[(int)_playerCore.HaveMagic.nowStyle], this.transform.position, Quaternion.Euler(0,y,0));
            // axe.transform.SetParent(this.gameObject.transform);
            // axe.GetComponent<Pickel>().SetMaterial();
        }

    }
}

