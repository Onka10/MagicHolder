using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChangeSample : MonoBehaviour
{
    public int TileType = 0;
    public Material TileMaterial;
    public Material[] TileSet = new Material[4];
    public GameObject gameObject;

    public float test = 0;
    void Start()
    {
        TileMaterial = this.GetComponent<Renderer>().material; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (test == 1)
        {
            CardSetMaterial();
            test = 0;
        }
    }



    public void CardSetMaterial()
    {
        TileMaterial = TileSet[TileType];
        gameObject.GetComponent<Renderer>().material = TileMaterial;

    }
}
