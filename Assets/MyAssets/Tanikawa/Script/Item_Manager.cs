using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // ��������v���t�@�u�̔z��
    [SerializeField] float _startTime; // �ŏ��̃^�C�}�[�p�̕ϐ�
    [SerializeField] int _tmin; //Time�����_���l�̍ŏ��l
    [SerializeField] int _tmax; //Time�����_���l�̍ő�l
    [SerializeField] int _rmin; //Radius�����_���l�̍ŏ��l
    [SerializeField] int _rmax; //Radius�����_���l�̍ő�l
    private int _number; // �����_���ɑI�΂ꂽ�v���t�@�u�̃C���f�b�N�X
    private float _posX; // �����_���ɑ������X���̈ʒu
    private float _posZ; // �����_���ɑ������Z���̈ʒu
    private float _time; //���Ԃ�����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _time = Random.Range(_tmin,_tmax);
        Debug.Log(_time);
    }
    
    // Update is called once per frame
    void Update()
    {
        _startTime -= Time.deltaTime;  // �^�C�}�[������������
        if (_startTime <= 0.0f)
        {
            _time -= Time.deltaTime; // �^�C�}�[������������
        }
        if (_time <= 0.0f) // �^�C�}�[��0�ȉ��ɂȂ�����
        {
            ItemFall();
        }

    }
    void ItemFall()
    {
        _number = Random.Range(0, Prefabs.Length); // �v���t�@�u�z�񂩂烉���_���ɃC���f�b�N�X��I��
        _posX = Random.Range(_rmin, _rmax);
        _posZ = Random.Range(_rmin, _rmax);
        Instantiate(Prefabs[_number], new Vector3(_posX, 50, _posZ), Quaternion.identity); // �I�΂ꂽ�v���t�@�u�𐶐�
        _time = Random.Range(_rmin, _rmax);
    }
}
