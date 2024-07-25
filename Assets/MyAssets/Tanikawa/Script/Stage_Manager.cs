using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Stage_Manager : MonoBehaviour
{
    //�X�e�[�W�����Ԍo�߂ŗ��Ƃ�

    [SerializeField] GameObject[] _pizzaPrefabs; // ��������v���t�@�u�̔z��
    private float _time; //���Ԃ�����ϐ�
    public float speed = 0.5f; //���x��ϐ��Ƃ��Ĉ���

    // Start is called before the first frame update
    void Start()
    {
        //�������Ԃ����߂�
        _time = 10;
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ�i�߂�
        //���Ԃ��v��
        _time -= Time.deltaTime; // �^�C�}�[������������

        //��莞�Ԃ��o������
        //���I�N�A���Ă�����
        /*if (_time <= 0)
        {
            //for���ŉ񂵂ė��Ƃ�
            for (int i = 0; i < _pizzaPrefabs.Length; i++)
            {
                //�������g��Transform���擾
                Transform myTransform = _pizzaPrefabs[i].transform;
                //i�Ԗڂ̃s�U��-Y���Ɉړ�
                //��قǎ擾�������Transform�̏�񂩂���W�̏����擾
                Vector3 pos = myTransform.position;
                pos.y -= speed;
                //�����̍��W���قǉ��Z�����l�ɕύX
                myTransform.position = pos;
                _time = 1;
            }
        }*/
        if (_time < 0 )
        {
            for(int i = 0; i < _pizzaPrefabs.Length; i++)
            {
                StageDown(i);
            }
        }
       
        
    }
    //���Ԍo�߂�����stage1��y�������ɗ��Ƃ��֐������
    private void StageDown(int i)
    {
        //�������g��Transform���擾
        Transform myTransform = _pizzaPrefabs[i].transform;
        //i�Ԗڂ̃s�U��-Y���Ɉړ�
        //��قǎ擾�������Transform�̏�񂩂���W�̏����擾
        Vector3 pos = myTransform.position;
        pos.y -= speed;
        //�����̍��W���قǉ��Z�����l�ɕύX
        myTransform.position = pos;
        //��藎������delete
        if (pos.y < -5)
        {
            Destroy(_pizzaPrefabs[i]);
        }
        //���Ԃ��Ē�`
        _time = 15;
    }
}
//���Ԃ����߂�
//���Ԃ�i�߂�
//���Ԍo�߂�����stage1��y�������ɗ��Ƃ�
//��藎������delete
//���Ԃ��Ē�`
//�ȉ����[�v