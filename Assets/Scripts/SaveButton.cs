using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO; //ファイル保存用

public class SaveButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    //『保存ボタン』をタップしたら実行
    public void PushSaveImage()
    {
        Debug.Log("課題を保存しました");
        
        //画像ファイル名に使う変数
        int i = int.Parse(WorkRefer.saveName);
        string path = "Assets/Resources/MyWork";

        //読み込んだ画像をpngに変換
        byte[] bytes = AddImage.texture2.texture.EncodeToPNG();

        //重複しない画像ファイル名を探す
        /*while (File.Exists(path + "/work" + i + ".png"))
        {
            i++;
        }*/
        //(重複しないファイル名を見つけたら)保存
        File.WriteAllBytes(path + "/work" + i + ".png", bytes);

        //画像変更を行ったため、画像変更をtrueにする
        PlayerPrefs.SetString("imgInfo" + i, "true");  //同時に保存内容を更新
        PlayerPrefs.Save();

        //詳細画面の画像も変化させる
        GameObject dh = GameObject.Find("detailHold" + i);
        GameObject dhpict = dh.transform.GetChild(2).gameObject;
        Image dhimg = dhpict.gameObject.GetComponent<Image>();
        dhimg.color = new Color(255, 255, 255, 255);

        //簡易画面の画像も変化させる
        //GameObject butimg = GameObject.Find(i);
        //Image bimg = butimg.gameObject.GetComponent<Image>();
    }
}
