using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemView : MonoBehaviour
{
    [SerializeField] MeshRenderer mesh;
    [SerializeField] List<Material>Materials = new List<Material>(3);
    [SerializeField] Animator animator;
    [SerializeField] int Style=0;

    public void ChangeAnime(string clip){
        animator.SetBool(clip,true);
    }

    public void ChangeMaterial(){
        if(0 > Style || Style >= 3) throw new System.Exception("マテリアルのidがおかしい");
        mesh.material = Materials[Style];
    }

    public void ChangeShader(float cut){
        mesh.GetComponent<Material>().SetFloat("Cut",cut);   
    }

}
