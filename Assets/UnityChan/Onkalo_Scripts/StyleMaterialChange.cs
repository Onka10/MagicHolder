using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StyleMaterialChange : MonoBehaviour
{
    [SerializeField] GameObject[] UnityChanParts = new GameObject[1];
    [SerializeField] Material[] materials = new Material[3];

    // [SerializeField] SkinnedMeshRenderer[] s = new SkinnedMeshRenderer[1];

        u1w.player.PlayerCore _playerCore;

        void Start()
        {
            _playerCore = u1w.player.PlayerCore.I;

            _playerCore.OnStyleChange
            .Subscribe(_ => MaterialChange())
            .AddTo(this);
        }

        void MaterialChange(){
            
            for(int i=0;i<UnityChanParts.Length;i++){
                var mats = UnityChanParts[i].GetComponent<SkinnedMeshRenderer>().materials;
                for(int j=0;j<mats.Length;j++){
                    mats[j] =  materials[(int)_playerCore.HaveMagic.nowStyle];
                }
            }
        }
}


// var mat = Resources.Load<Material>("Materials/mat");
// var mats = obj.GetComponent<SkinnedMeshRenderer>().materials;
// for (int i = 0; i < obj.GetComponent<SkinnedMeshRenderer>().materials.Length; i++)
//     {
//         mats[i] = mat;
// 	}
// obj.GetComponent<SkinnedMeshRenderer>().materials = mats;
