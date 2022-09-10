using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickaxeEffect : MonoBehaviour
{

    public GameObject PickaxeObject;
    public GameObject PickaxeAttackParticle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ParticleOn()
    {
        Instantiate(PickaxeAttackParticle, PickaxeObject.transform.position, Quaternion.identity);

    }
}
