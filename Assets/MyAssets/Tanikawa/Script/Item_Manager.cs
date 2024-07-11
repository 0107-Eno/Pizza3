using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Manager : MonoBehaviour
{
    [SerializeField] GameObject[] Prefabs; // ��������v���t�@�u�̔z��
    [SerializeField] float _sTartTime; // �ŏ��̃^�C�}�[�p�̕ϐ�
    [SerializeField] int _tMin; //Time�����_���l�̍ŏ��l
    [SerializeField] int _tMax; //Time�����_���l�̍ő�l
    [SerializeField] int _rMin; //Radius�����_���l�̍ŏ��l
    [SerializeField] int _rMax; //Radius�����_���l�̍ő�l
    private int _nMmber; // �����_���ɑI�΂ꂽ�v���t�@�u�̃C���f�b�N�X
    private float _pOsX; // �����_���ɑ������X���̈ʒu
    private float _pOsZ; // �����_���ɑ������Z���̈ʒu
    private float _tIme; //���Ԃ�����ϐ�

    // Start is called before the first frame update
    void Start()
    {
        _tIme = Random.Range(_tMin,_tMax);
        Debug.Log(_tIme);
    }
    
    // Update is called once per frame
    void Update()
    {
        _sTartTime -= Time.deltaTime;  // �^�C�}�[������������
        if (_sTartTime <= 0.0f)
        {
            _tIme -= Time.deltaTime; // �^�C�}�[������������
        }
        if (_tIme <= 0.0f) // �^�C�}�[��0�ȉ��ɂȂ�����
        {
            ItemFall();
        }

    }
    void ItemFall()
    {
        _nMmber = Random.Range(0, Prefabs.Length); // �v���t�@�u�z�񂩂烉���_���ɃC���f�b�N�X��I��
        _pOsX = Random.Range(_rMin, _rMax);
        _pOsZ = Random.Range(_rMin, _rMax);
        Instantiate(Prefabs[_nMmber], new Vector3(_pOsX, 50, _pOsZ), Quaternion.identity); // �I�΂ꂽ�v���t�@�u�𐶐�
        _tIme = Random.Range(_tMin, _tMax);
    }
}
