using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RockDestroySample : MonoBehaviour
{

	public GameObject Rock;
	void Start () {
	var main = GetComponent<ParticleSystem>().main;

	// StopAction‚ÍCallback‚Éİ’è‚µ‚Ä‚¢‚é•K—v‚ª‚ ‚é
	main.stopAction = ParticleSystemStopAction.Callback;
	}

void OnParticleSystemStopped()
{
		Destroy(Rock);

	}

}