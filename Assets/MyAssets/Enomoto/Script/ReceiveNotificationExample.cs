using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ReceiveNotificationExample : MonoBehaviour
{
   //�v���C���[�����������Ƃ��Ɏ󂯎��ʒm
   public void OnplayerJoined(PlayerInput playerInput)
    {
        print($"�v���C���[#{playerInput.user.index}������");
    }
}
