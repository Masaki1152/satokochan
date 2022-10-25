using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonWork : MonoBehaviour
{
    public void ButtonClicked()
    {
        SceneManager.LoadScene("WorkScene");
    }
}
