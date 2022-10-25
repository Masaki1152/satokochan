using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspect : MonoBehaviour
{
    //����
    float cameraWidth = 1080;
    //�c��
    float cameraHeight = 1920;

    void Start()
    {
        //�f�o�C�X�̃A�X�y�N�g��Ɨ��z�̃A�X�y�N�g����r����
        Camera MainCamera = Camera.main;
        float defaultAspect = cameraWidth / cameraHeight;
        float actualAspect = (float)Screen.width / (float)Screen.height;
        float ratio = actualAspect / defaultAspect;

        //�c���̂͂ݏo����ɍ��킹�Ĕ䗦�𒲐�����
        if (ratio < 1)
        {
            MainCamera.orthographicSize /= ratio;
        }
    }
}
