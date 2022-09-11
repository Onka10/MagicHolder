using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animetest : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

    void RockAnime()
    {

        Animator RockAnimatorController = GetComponent<Animator>();
        RockAnimatorController.SetFloat("RockAnimeState", 0f);
        RockAnimatorController.SetFloat("RockAnimeState", 1f);

    }
}
