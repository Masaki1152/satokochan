using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    //�A�j���[�V�������擾
    public Animator animator;

    //���Ԃ��v�����邽�߂̕ϐ�
    public float countTime = 0.0f;
    //�܂΂����̔����^�C�~���O�̕ϐ�
    public float blinkTriggerTime = 5.0f;

    void FixedUpdate()
    {
        //FixedUpdate�͏����ݒ�̂܂܂Ȃ�
        //0.02�b�Ԋu�ł���Ԃ��Ă΂��
        CheckCountTime();
    }

    void CheckCountTime()
    {
        //���Ԃ��v��
        countTime += Time.deltaTime;
        //���Ԃ��܂΂����̔����^�C�~���O�𒴂�����
        if (countTime > blinkTriggerTime)
        {
            //�v�����Ԃ����Z�b�g
            countTime = 0.0f;
            //�܂΂����̔����^�C�~���O�̕ϐ���
            //5.0f����10.5f�̊ԂŃ����_���Ȑ��l���擾
            blinkTriggerTime = Random.Range(5.0f, 10.5f);

            //�ڂ���鏈��
            animator.SetBool("Blink", true);

            //�ڂ���鏈���J�n
            StartCoroutine("OpenEye");
        }
    }

    IEnumerator OpenEye()
    {
        yield return new WaitForSeconds(0.015f);
        animator.SetBool("Blink", false);
    }

}



