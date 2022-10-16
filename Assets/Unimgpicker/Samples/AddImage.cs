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
        imagePicker.Show("Select Image", "unimgpicker", 512);//1024→512に変更
    }

    private IEnumerator LoadImage(string path, Image output)
    {
        string url = "file://" + path;
        WWW www = new WWW(url);
        yield return www;

        texture = www.texture;


        //テクスチャをコピー
        //TextureCopy(texture, path);
        //PlayerPrefs.SetString("URL" + WorkRefer.btnindex, path);
        //PlayerPrefs.Save();
        //Debug.Log("番号確認" + WorkRefer.btnindex + "、URLは" + PlayerPrefs.GetString("URL" + WorkRefer.btnindex));


        // まずリサイズ
        int _CompressRate = TextureCompressionRate.TextureCompressionRatio(texture.width, texture.height);
        TextureScale.Bilinear(texture, texture.width / _CompressRate, texture.height / _CompressRate);
        // 次に圧縮(縦長・横長すぎると使えない場合があるようです。) -> https://forum.unity.com/threads/strange-error-message-miplevel-m_mipcount.441907/
        //texture.Compress(false);
        // Spriteに変換して使用する
        texture2 = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        output.overrideSprite = texture2;
    }

    public static Texture2D TextureCopy(Texture source, string savePath)
    {
        var texture = new Texture2D(source.width, source.height, TextureFormat.RGB24, false);
        var renderTexture = new RenderTexture(texture.width, texture.height, 32);

        // もとのテクスチャをRenderTextureにコピー
        Graphics.Blit(source, renderTexture);
        RenderTexture.active = renderTexture;

        // RenderTexture.activeの内容をtextureに書き込み
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        RenderTexture.active = null;

        // 不要になったので削除
        RenderTexture.DestroyImmediate(renderTexture);

        // pngとして保存
        System.IO.File.WriteAllBytes(savePath, texture.EncodeToPNG());

        AssetDatabase.Refresh();

        // 保存したものをロードしてから返す
        return AssetDatabase.LoadAssetAtPath<Texture2D>(savePath);
    }
}


public static class TextureCompressionRate
{
    /// <summary>
    /// Textureが500x500に収まるようにリサイズします
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

