using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;

public class GameOverManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] u1w.player.InputObserver _input;
    void Start()
    {
            _input.OnSpace
            .Where(_ => u1w.PlayerCore.I.IsGameOver)
            .Subscribe(_ =>{
                SceneManager.LoadScene("title");
            })
            .AddTo(this);
    }

}
