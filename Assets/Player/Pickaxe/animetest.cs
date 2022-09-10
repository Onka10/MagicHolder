using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animetest : MonoBehaviour
{
    // Start is called before the first frame update
    public float ani = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Animator PickaxeAnimatorController = GetComponent<Animator>();
        PickaxeAnimatorController.SetFloat("PickaxeAnime", ani); // "Float"にはパラメータ名が入ります
        PickaxeAnimatorController.GetFloat("PickaxeAnime"); // 値を取得する場合
    }
}
