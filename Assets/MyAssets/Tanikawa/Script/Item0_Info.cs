using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item0_Info : Item_Information
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        //�G�ꂽ�牽���N������
        if (other.gameObject.tag == "Player")
        {
            // �i�d�v�|�C���g�jItem�N���X��ItemBase���\�b�h���Ăяo���B
            // �G�t�F�N�g�A���ʉ����͂���Ŕ������܂��B
            base.ItemBase(other.gameObject);
        }

    }
    private void Update()
    {
        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
