using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Information : MonoBehaviour
{
    public static GameObject lastPlayer;  // 最後のPlayerタグを持つGameObjectを保存するための静的変数
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Playerタグを持つGameObjectが一つだけ残った場合、そのGameObjectを静的変数に保存
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if (players.Length == 1)
        {
            lastPlayer = players[0];
            Invoke(nameof(LoadScene), 3f);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("EndhingScene");
    }
}
