using UnityEngine;
using static UnityEngine.ParticleSystem;

public class TriggerEffect : MonoBehaviour
{
    // �G�t�F�N�g�̃v���n�u�i���O�ɍ쐬�����p�[�e�B�N���V�X�e���Ȃǂ��A�T�C���j
   [SerializeField] private ParticleSystem effectBoom;
   [SerializeField] private ParticleSystem effectEx;

    // �g���K�[�ɓ������Ƃ��ɌĂ΂�郁�\�b�h
    private void OnTriggerEnter(Collider other)
    {
        // �^�O�� "Player" �̏ꍇ�̂݃G�t�F�N�g�𔭐�������
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("��������");
            // �p�[�e�B�N���V�X�e���̃C���X�^���X�𐶐�����B
            ParticleSystem newParticle0 = Instantiate(effectBoom);
            ParticleSystem newParticle1 = Instantiate(effectEx);
            // �p�[�e�B�N���̔����ꏊ�����̃X�N���v�g���A�^�b�`���Ă���GameObject�̏ꏊ�ɂ���B
            newParticle0.transform.position = this.transform.position;
            newParticle1.transform.position = this.transform.position;
            // �p�[�e�B�N���𔭐�������B
            newParticle0.Play(); 
            newParticle1.Play();
            // �C���X�^���X�������p�[�e�B�N���V�X�e����GameObject��5�b��ɍ폜����B(�C��)
            // ����������newParticle�����ɂ���ƃR���|�[�l���g�����폜����Ȃ��B
            Destroy(newParticle0.gameObject, 5.0f);
            Destroy(newParticle1.gameObject, 5.0f);
        }
    }
}
