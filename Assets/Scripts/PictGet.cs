using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictGet : MonoBehaviour
{
    void Update()
    {
        // �^�b�`���ɌĂ΂��
        if (Input.GetMouseButtonDown(0))
        {
            // �X�N���[���V���b�g���M�������[�ɕۑ�
            StartCoroutine(TakeScreenshotAndSave());
        }
    }

    // �X�N���[���V���b�g���M�������[�ɕۑ�
    private IEnumerator TakeScreenshotAndSave()
    {
        yield return new WaitForEndOfFrame();

        // �X�N���[���V���b�g�̎擾
        Texture2D ss = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        ss.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        ss.Apply();

        // �X�N���[���V���b�g���M�������[�ɕۑ�
        NativeGallery.Permission permission = NativeGallery.SaveImageToGallery(
            ss, "GalleryTest", "Image.png",
            (success, path) => Debug.Log("Media save result: " + success + " " + path)
        );
        Debug.Log("Permission result: " + permission);

        // ���������[�N�̉��
        Destroy(ss);
    }
}
