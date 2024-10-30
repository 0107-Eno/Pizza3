using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Information : MonoBehaviour //�v���C���[�̒l���p��������
{
    //�G�t�F�N�g�̔����ASE�̔����AItem�̍폜
    [SerializeField] GameObject _effectPrefab;
    [SerializeField] AudioClip _sound;

    //�v���C���[�̕ύX�l���U���́A�X�s�[�h�A�g�̑���
    //public static float _addForce;
    //public static float _speed;
    //public static float _body;

    public float _time;

    private void Start()
    {
    }
    // Start is called before the first frame update
    // �i�|�C���g�j�擪�Ɂupublic�v�����邱�ƁB
    public void ItemBase(GameObject Player)
    {
        var p = Player.GetComponent<PlayerMovementStateMachine>();
        Debug.Log(p.ToString());

        //�v���C���[�̒l���p���o������
        //�A�C�e����tag���m�F����
        switch (gameObject.tag)
        {
            case "Item0": //Item0�̎�
                //�v���C���[�̒l������������
                p.StartBufImpulse();
                Debug.Log("Item0"); 
                break;  

            case "Item1":
                //�v���C���[�̒l������������
                p.StartBufSpeed();
                Debug.Log("Item1"); 
                break; 

            case "Item2":
                //�v���C���[�̒l������������
                p.StartBufDouble();
                Debug.Log("Item2"); 
                break; 

            default:
                break; //switch�����甲����
        }

        //�G�t�F�N�g�̃C���X�^���X����
        GameObject effect0 = Instantiate(_effectPrefab, Player.transform.position, Quaternion.identity);
        // �G�t�F�N�g���G�l�~�[�̎q�ɐݒ肷��
        effect0.transform.SetParent(Player.transform);
        //�G�t�F�N�g�̍폜
        Destroy(effect0, 1.5f);
      
        //SE�̍Đ�
        AudioSource.PlayClipAtPoint(_sound, transform.position);

        // �A�C�e���͔j�󂷂�B
        Destroy(this.gameObject);
    }
    private void Update()
    {
        _time += Time.deltaTime;
    }
}
