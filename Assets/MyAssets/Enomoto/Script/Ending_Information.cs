using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Information : MonoBehaviour
{
    public static GameObject lastPlayer;  // �Ō��Player�^�O������GameObject��ۑ����邽�߂̐ÓI�ϐ�
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Player�^�O������GameObject��������c�����ꍇ�A����GameObject��ÓI�ϐ��ɕۑ�
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
