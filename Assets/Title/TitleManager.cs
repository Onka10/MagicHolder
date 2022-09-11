using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class TitleManager : MonoBehaviour
{
    [SerializeField] AudioSource se;
    [SerializeField] AudioClip clip;

    void ChangeScene()
    {
        SceneManager.LoadScene("MainScene");
        se.PlayOneShot(clip);
    }

            private void Update()
        {
            // 現在のキーボード情報
            var current = Keyboard.current;

            // キーボード接続チェック
            if (current == null)    return;

            // 入力状態取得
            var spaceKey = current.spaceKey;

            // Spaceキーが押された瞬間かどうか
            if (spaceKey.wasPressedThisFrame)
            {
                ChangeScene();
            }
        }
}
