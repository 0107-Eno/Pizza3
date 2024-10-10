using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGenerater : MonoBehaviour
{
    public GameObject[] playerPrefab;  // ��������v���C���[�̃v���n�u
    public Transform[] spawnPoints;  // �v���C���[�����������X�|�[���n�_

    void Start()
    {
        // SelectManager ���� PlayerNum ���擾
        int playerNum = SelectManager.Instance.userSetting.PlayerNum;

        // PlayerNum �̐������v���C���[�𐶐�
        for (int i = 0; i < playerNum; i++)
        {
            if (i < spawnPoints.Length)  // �X�|�[���n�_������邩�m�F
            {
                Instantiate(playerPrefab[i], spawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning("�X�|�[���n�_������܂���I");
            }
        }
        Debug.Log(playerNum);
    }
// Update is called once per frame
void Update()
    {
        
    }
}
