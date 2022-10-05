using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPictional : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("PictorialBookScene");
    }
}
