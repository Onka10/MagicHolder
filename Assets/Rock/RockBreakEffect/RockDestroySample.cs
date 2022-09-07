using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class RockDestroySample : MonoBehaviour
{

	public GameObject Rock;
	void Start () {
	var main = GetComponent<ParticleSystem>().main;

	// StopAction��Callback�ɐݒ肵�Ă���K�v������
	main.stopAction = ParticleSystemStopAction.Callback;
	}

void OnParticleSystemStopped()
{
		Destroy(Rock);

	}

}