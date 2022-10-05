using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonReturn : MonoBehaviour
{
    //ボタンでシーン遷移
        public void ButtonreturnClicked()
        {
            SceneManager.LoadScene("MainScene");
    }


}