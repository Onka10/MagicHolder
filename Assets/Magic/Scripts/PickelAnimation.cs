using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
public class PickelAnimation : MonoBehaviour {

	PlayableGraph graph;

	[SerializeField] AnimationClip clip;

	void Awake()
	{
		graph = PlayableGraph.Create ();
	}

	void Start()
	{
		// アニメーションをResourcesから取得し
		// AnimationClipPlayableを構築
		var clipPlayable = AnimationClipPlayable.Create (graph, clip);

		// outputを生成して、出力先を自身のAnimatorに設定
		var output = AnimationPlayableOutput.Create (graph, "output", GetComponent<Animator>());

		// playableをoutputに流し込む
		output.SetSourcePlayable (clipPlayable);

		graph.Play ();
	}

	void OnDestroy()
	{
		graph.Destroy ();
	}
}