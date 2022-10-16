using Kakera;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;


public class AddImage : MonoBehaviour
{
    [SerializeField] private Unimgpicker imagePicker;
    [SerializeField] private Image ssImage;
    public Texture2D texture;
    public static Sprite texture2;

    private void Awake()
    {
        imagePicker.Completed += path => StartCoroutine(LoadImage(path, ssImage));
    }

    private void Start()
    {
        if (!ssImage)
        {
            ssImage = gameObject.GetComponent<Image>();
        }
    }

    public void OnPressShowPicker()
    {
        imagePicker.Show("Select Image", "unimgpicker", 512);//1024��512�ɕύX
    }

    private IEnumerator LoadImage(string path, Image output)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;


        //�e�N�X�`�����R�s�[
        //TextureCopy(texture, path);
        //PlayerPrefs.SetString("URL" + WorkRefer.btnindex, path);
        //PlayerPrefs.Save();
        //Debug.Log("�ԍ��m�F" + WorkRefer.btnindex + "�AURL��" + PlayerPrefs.GetString("URL" + WorkRefer.btnindex));


        // �܂����T�C�Y
        int _CompressRate = TextureCompressionRate.TextureCompressionRatio(texture.width, texture.height);
        TextureScale.Bilinear(texture, texture.width / _CompressRate, texture.height / _CompressRate);
        // ���Ɉ��k(�c���E����������Ǝg���Ȃ��ꍇ������悤�ł��B) -> https://forum.unity.com/threads/strange-error-message-miplevel-m_mipcount.441907/
        //texture.Compress(false);
        // Sprite�ɕϊ����Ďg�p����
        texture2 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        output.overrideSprite = texture2;
    }

    public static Texture2D TextureCopy(Texture source, string savePath)
    {
        var texture = new Texture2D(source.width, source.height, TextureFormat.RGB24, false);
        var renderTexture = new RenderTexture(texture.width, texture.height, 32);

        // ���Ƃ̃e�N�X�`����RenderTexture�ɃR�s�[
        Graphics.Blit(source, renderTexture);
        RenderTexture.active = renderTexture;

        // RenderTexture.active�̓��e��texture�ɏ�������
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        RenderTexture.active = null;

        // �s�v�ɂȂ����̂ō폜
        RenderTexture.DestroyImmediate(renderTexture);

        // png�Ƃ��ĕۑ�
        System.IO.File.WriteAllBytes(savePath, texture.EncodeToPNG());

        AssetDatabase.Refresh();

        // �ۑ��������̂����[�h���Ă���Ԃ�
        return AssetDatabase.LoadAssetAtPath<Texture2D>(savePath);
    }
}


public static class TextureCompressionRate
{
    /// <summary>
    /// Texture��500x500�Ɏ��܂�悤�Ƀ��T�C�Y���܂�
    /// </summary>
    public static int TextureCompressionRatio(int width, int height)
    {
        if (width >= height)
        {
            if (width / 500 > 0) return (width / 500);
            else return 1;
        }
        else if (width < height)
        {
            if (height / 500 > 0) return (height / 500);
            else return 1;
        }
        else return 1;
    }
}

