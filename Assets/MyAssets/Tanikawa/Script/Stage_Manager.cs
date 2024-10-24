using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;  // �����ǋL

public class Stage_Manager : MonoBehaviour
{
    //�X�e�[�W�����Ԍo�߂ŗ��Ƃ�

    [SerializeField] GameObject[] _pizzaPrefabs; // ��������v���t�@�u�̔z��// �h�炷�I�u�W�F�N�g
    public float[] _time; //���Ԃ�����ϐ�
    public float _speed = 0.5f; //���x��ϐ��Ƃ��Ĉ���

    float deltaTime = 0;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //���Ԃ�i�߂�
        deltaTime += Time.deltaTime;

        for(int i = 0; i < _pizzaPrefabs.Length; i++)
        {
            if (deltaTime + 3f >= _time[i])
            {
                Shake(i);
                
            }
            if (deltaTime >= _time[i])
            {
                DOTween.KillAll();
                StageDown(i);
            }
        }
       
        
    }
    // DOTween�ŃI�u�W�F�N�g����炷
    private void Shake(int i)
    {
        //Debug.Log("�U��");
        if (_pizzaPrefabs[i] == null) return;
        {
            _pizzaPrefabs[i].transform.DOShakePosition(
                1f,1f,2,10,false,true).SetLink(_pizzaPrefabs[i]);
        }
    }
    //���Ԍo�߂�����stage1��y�������ɗ��Ƃ��֐������
    private void StageDown(int i)
    {
        if (_pizzaPrefabs[i] == null) return;
        _pizzaPrefabs[i].transform.position += new Vector3(0, -_speed, 0) * Time.deltaTime;

        //��藎������delete
        if (_pizzaPrefabs[i].transform.position.y < -10)
        {
            Destroy(_pizzaPrefabs[i]);
        }
    }

}