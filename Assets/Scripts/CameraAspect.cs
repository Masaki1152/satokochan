using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    //横幅
    float cameraWidth = 1080;
    //縦幅
    float cameraHeight = 1920;

    void Start()
    {
        //デバイスのアスペクト比と理想のアスペクト比を比較する
        Camera MainCamera = Camera.main;
        float defaultAspect = cameraWidth / cameraHeight;
        float actualAspect = (float)Screen.width / (float)Screen.height;
        float ratio = actualAspect / defaultAspect;

        //縦横のはみ出る方に合わせて比率を調整する
        if (ratio < 1)
        {
            MainCamera.orthographicSize /= ratio;
        }
    }
}
