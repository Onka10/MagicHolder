using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Animations;
using UnityEngine.Profiling;
using System.Linq;

//dancetextの変更をanimationを購読するようにしたいUniRx導入後

public class AnimationHelp : MonoBehaviour
{
	PlayableGraph graph;
	AnimationMixerPlayable mixer;

    [SerializeField] AnimationClip anime1;
    [SerializeField] AnimationClip anime2;
    [SerializeField] AnimationClip anime3;
	[Range(0, 1)] public float weight;

	void Awake()
	{
		graph = PlayableGraph.Create ();
	}

	void Start()
	{
		// アニメーションをResourcesから取得し
		// AnimationClipPlayableを構築
		var clip1Playable = AnimationClipPlayable.Create (graph, anime1);

		var clip2Playable = AnimationClipPlayable.Create (graph, anime2);

		// ミキサーを生成して、Clip1とClip2を登録
		// （代わりにAnimatorControllerPlayableとかでも可能）
		mixer = AnimationMixerPlayable.Create (graph, 2, true);
		mixer.ConnectInput (0, clip1Playable, 0);
		mixer.ConnectInput (1, clip2Playable, 0);

		// outputを生成して、出力先を自身のAnimatorに設定
		var output = AnimationPlayableOutput.Create (graph, "output", GetComponent<Animator>());

		// playableをoutputに流し込む
		output.SetSourcePlayable (mixer);

		graph.Play ();
	}

	void Update()
	{
		mixer.SetInputWeight (0, weight);
		mixer.SetInputWeight (1, 1 - weight);
	}

	void OnDestroy()
	{
		graph.Destroy ();
	}
}
