using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StyleChange : MonoBehaviour
{
    [SerializeField] GameObject[] UnityChan = new GameObject[3];
    u1w.player.PlayerCore _playerCore;

    void Start()
    {
        _playerCore = u1w.player.PlayerCore.I;

        _playerCore.OnStyleChange
        .Subscribe(_ => ChangeStyle())
        .AddTo(this);
    }
    void ChangeStyle(){
        foreach(Transform child in gameObject.transform){
            Destroy(child.gameObject);
        }

        GameObject chara = Instantiate(UnityChan[(int)_playerCore.HaveMagic.nowStyle], Vector3.zero, Quaternion.identity);
        chara.transform.SetParent(this.gameObject.transform);
        chara.transform.localPosition = new Vector3(0,0,0);
        chara.transform.localRotation = Quaternion.identity;
    }
}
