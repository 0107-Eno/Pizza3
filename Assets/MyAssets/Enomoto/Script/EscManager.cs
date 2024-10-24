using UnityEngine;

public class SingletonDontDestroy : MonoBehaviour
{
    private static SingletonDontDestroy instance;

    void Awake()
    {
        // ���łɃC���X�^���X�����݂���ꍇ�A�����j��
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // �C���X�^���X��ݒ肵�A�I�u�W�F�N�g��j�����Ȃ�
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update���\�b�h��K�v�ɉ����Ēǉ�
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
