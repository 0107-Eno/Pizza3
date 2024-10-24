using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Haptics;

public class Control_Shake : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter(Collision other)
    {
        //�G�ꂽ�牽���N������
        string tag = other.gameObject.tag;
        if (tag.Contains("Player"))
        {
            Debug.Log("�Փ�");
            StartCoroutine("Shake");
        }
    }
    private IEnumerator Shake()
    {
        var gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.Log("�Q�[���p�b�h���ڑ�");
            yield break;
        }

        Debug.Log("���[�^�[�U��");
        gamepad.SetMotorSpeeds(1.0f, 1.0f);
        yield return new WaitForSeconds(1.0f);

        Debug.Log("���[�^�[��~");
        gamepad.SetMotorSpeeds(0.0f, 0.0f);
    }

}
