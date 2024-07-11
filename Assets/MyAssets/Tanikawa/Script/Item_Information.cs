using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Information : MonoBehaviour //�v���C���[�̒l���p��������
{
    //�G�t�F�N�g�̔����ASE�̔����AItem�̍폜
    [SerializeField] GameObject _eFfectPrefab;
    [SerializeField] AudioClip _sOund;
   
    // Start is called before the first frame update
    // �i�|�C���g�j�擪�Ɂupublic�v�����邱�ƁB
    public void ItemBase(GameObject Player)
    {
        //�v���C���[�̒l���p���o������
        //�A�C�e����tag���m�F����
        switch (gameObject.tag)
        {
            case "Item0": //Item0�̎�
                //�v���C���[�̒l������������
                Debug.Log("Item0"); 
                break;  

            case "Item1":
                //�v���C���[�̒l������������
                Debug.Log("Item1"); 
                break; 

            case "Item2":
                //�v���C���[�̒l������������
                Debug.Log("Item2"); 
                break; 

            default:    
                break; //switch�����甲����
        }

        //�G�t�F�N�g�̃C���X�^���X����
        GameObject effect0 = Instantiate(_eFfectPrefab, Player.transform.position, Quaternion.identity);
        // �G�t�F�N�g���G�l�~�[�̎q�ɐݒ肷��
        effect0.transform.SetParent(Player.transform);
        //�G�t�F�N�g�̍폜
        Destroy(effect0, 1.5f);
      
        //SE�̍Đ�
        AudioSource.PlayClipAtPoint(_sOund, transform.position);

        // �A�C�e���͔j�󂷂�B
        Destroy(this.gameObject);
    }
}
