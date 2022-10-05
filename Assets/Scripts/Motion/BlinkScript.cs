using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour
{
    //アニメーションを取得
    public Animator animator;

    //時間を計測するための変数
    public float countTime = 0.0f;
    //まばたきの発動タイミングの変数
    public float blinkTriggerTime = 5.0f;

    void FixedUpdate()
    {
        //FixedUpdateは初期設定のままなら
        //0.02秒間隔でくり返し呼ばれる
        CheckCountTime();
    }

    void CheckCountTime()
    {
        //時間を計測
        countTime += Time.deltaTime;
        //時間がまばたきの発動タイミングを超えたら
        if (countTime > blinkTriggerTime)
        {
            //計測時間をリセット
            countTime = 0.0f;
            //まばたきの発動タイミングの変数に
            //5.0fから10.5fの間でランダムな数値を取得
            blinkTriggerTime = Random.Range(5.0f, 10.5f);

            //目を閉じる処理
            animator.SetBool("Blink", true);

            //目を閉じる処理開始
            StartCoroutine("OpenEye");
        }
    }

    IEnumerator OpenEye()
    {
        yield return new WaitForSeconds(0.015f);
        animator.SetBool("Blink", false);
    }

}



