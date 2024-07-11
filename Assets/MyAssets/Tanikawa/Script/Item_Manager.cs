using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // ��������v���t�@�u�̔z��
    [SerializeField] float time; // �^�C�}�[�p�̕ϐ�
    [SerializeField] int Rmin; //�����_���l�̍ŏ��l
    [SerializeField] int Rmax; //�����_���l�̍ő�l
    private int number; // �����_���ɑI�΂ꂽ�v���t�@�u�̃C���f�b�N�X
    private float posX; // �����_���ɑ������X���̈ʒu
    private float posZ; // �����_���ɑ������Z���̈ʒu

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime; // �^�C�}�[������������
        if (time <= 0.0f) // �^�C�}�[��0�ȉ��ɂȂ�����
        {
            time = 1.0f; // �^�C�}�[�����Z�b�g
            number = Random.Range(0, Prefabs.Length); // �v���t�@�u�z�񂩂烉���_���ɃC���f�b�N�X��I��
            posX = Random.Range(Rmin,Rmax);
            posZ = Random.Range(Rmin,Rmax);
            Instantiate(Prefabs[number], new Vector3(posX, 50, posZ), Quaternion.identity); // �I�΂ꂽ�v���t�@�u�𐶐�
        }
    }
}
