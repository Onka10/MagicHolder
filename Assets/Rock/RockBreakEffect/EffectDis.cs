using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ParticleSystem))]
public class EffectDis : MonoBehaviour
{

	public GameObject Effect;
	void Start()
	{
		var main = GetComponent<ParticleSystem>().main;

		// StopActionはCallbackに設定している必要がある
		main.stopAction = ParticleSystemStopAction.Callback;
	}

	void OnParticleSystemStopped()
	{
		Destroy(Effect);
		
	}

}