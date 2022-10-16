using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPictorial : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("PictorialBookScene");
    }
}
