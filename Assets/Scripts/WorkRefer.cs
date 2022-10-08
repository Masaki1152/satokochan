using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class WorkRefer : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button workbutton;
    Image btnImage;
    Button obj;
    public GameObject detail;  //詳細画面のプレハブ
    GameObject detailHold;
    public Transform parentTran;
    EventSystem eventSystem;
    GameObject selectedObj;  //今選択しているボタンのインデックスを取り出す
    string index; //何番目のボタンか
    GameObject objpict; //画像取得用
    

    private void Start()
    {
        //作品数の数だけボタンを生成
        for (int i = 0; i < ButtonMission.WorkStr.Count; i++)
        {
            obj = Instantiate(workbutton, contentRectTransform);  //オブジェクトの生成
            btnImage = obj.gameObject.GetComponent<Image>();
            //btnImage.sprite =   //ライブラリから画像を取得し設定
            //リストのインデックスを取得するためにspriteデータの名前に数字を割り当てる
            btnImage.sprite.name = i.ToString();   
            Button btn = obj.GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
            //ボタンにAddImageスクリプトを追加する
            obj.gameObject.AddComponent<AddImage>();
        }
    }

    public void OnClickButton()
    {
        eventSystem = EventSystem.current;  //イベントシステムを利用してどのボタンを押しているかを取得  
        selectedObj = eventSystem.currentSelectedGameObject;
        // ボタンのImageコンポーネントからspriteデータの名前を取得
        index = selectedObj.GetComponent<Image>().sprite.name;

        detailHold = Instantiate(detail, new Vector3(150, 200, 0), Quaternion.identity);
        detailHold.transform.SetParent(parentTran);
        detailHold.transform.localScale = new Vector3(0.75f, 0.75f, 1);
        detailHold.transform.position = new Vector3(120, 240, 0);


        //子オブジェクトの取得
        GameObject objday = detailHold.transform.GetChild(0).gameObject;
        objpict = detailHold.transform.GetChild(1).gameObject;
        GameObject objeye = detailHold.transform.GetChild(2).gameObject;
        GameObject objhair = detailHold.transform.GetChild(3).gameObject;
        GameObject objitem = detailHold.transform.GetChild(4).gameObject;
        

        int btnindex = int.Parse(index);
        ConveyInfo(btnindex, out string eye, out string hair, out string item, out string day);

        objday.GetComponent<Text>().text = day;
        objeye.GetComponent<Text>().text = "目：" + eye;
        objhair.GetComponent<Text>().text = "髪型：" + hair;
        objitem.GetComponent<Text>().text = "アクセ：" + item;
        //objpict.GetComponent<Image>().sprite = PlayerPrefs.GetString("ImagePath");

        //StartCoroutine(GetImageFromPath(PlayerPrefs.GetString("URL" + btnImage)));

        /*もし画像が設定されていたら、簡略画面にもその画像を表示する
        Image pctimg = objpict.GetComponent<Image>();
        if(pctimg.sprite != null)
        {
            btnImage = obj.gameObject.GetComponent<Image>();
            btnImage.sprite = wwsp;  //ライブラリから画像を取得し設定
        }*/
        //objpict.GetComponent<Image>().sprite = pictImage[s];  //画像を設定する
    }

    //詳細画面にキャラクター情報を伝える
    public void ConveyInfo(int i, out string eye, out string hair, out string item , out string day)
    {
        string line = PlayerPrefs.GetString("WorkRefer" +i);
        string[] lineinfo = line.Split(',');
        eye = lineinfo[0];
        hair = lineinfo[1];
        item = lineinfo[2];
        day = lineinfo[3];
    }

    //プレハブの戻るボタンが押されたとき
    public void PrefabOnClick()
    {
        Destroy(detailHold);
    }

    /*//パスから画像を取得
    IEnumerator GetImageFromPath(string path)
    {
        WWW www = new WWW(path);
        yield return www;

        Image pctimg = objpict.GetComponent<Image>();
        //Texture2DをSpriteに変換
        var tex = www.textureNonReadable;
        wwsp = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), Vector2.zero);
        pctimg.sprite = wwsp;

        //簡易画面にもその画像を表示
        Image btnimg = obj.GetComponent<Image>();
        btnimg.sprite = wwsp;
    }*/
}
