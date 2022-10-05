using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class Pictorial : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public RectTransform contentRectTransform2;
    public Button button;
    Sprite[] pictImage = new Sprite[162];
    Button[]obj = new Button[162];
    Image btnImage;
    //Button btn;  //プレハブのボタン
    public GameObject detail;  //詳細画面のプレハブ
    GameObject detailHold;
    public Transform parentTran;
    EventSystem eventSystem;
    GameObject selectedObj;  //今選択しているボタンのインデックスを取り出す


    private void Start()
    {
        for (int i = 0; i < 162; i++)
        {
            pictImage[i] = Resources.Load<Sprite>("Images/" + i);
        }
        Debug.Log("pictImage =" + pictImage.Length);
        Debug.Log("ButtonFortune =" + ButtonFortune.pictInfo.Length);


        for (int i = 0; i < 162; i++)
        {
            obj[i] = Instantiate(button, contentRectTransform);
            int s = i + 1;
            obj[i].GetComponentInChildren<Text>().text = "No." + s.ToString();
            obj[i].GetComponent<Button>().interactable = false;  //未所持のキャラはボタンを押せなくする
            btnImage = obj[i].gameObject.GetComponent<Image>();
            ChangeImage(i);    //写真を変える
            Button btn = obj[i].GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
            Debug.Log("PictrialのChangeImageの後は、配列" + i + "は" + PlayerPrefs.GetString("pictInfo" + i));
        }

    }

    public void ChangeImage(int i)
    {
        //PlayerPrefsからtrue/flaseを取り出す
        string s = PlayerPrefs.GetString("pictInfo" + i);
        Debug.Log("PictrialのChangeImage中は配列" + i + "は" + s);

        //所持していた場合、画像を変更する
        if (s == "true")      //既に所持していた場合の処理
        {
            Debug.Log(i + "is OK!," + ButtonFortune.pictInfo[i] + pictImage[i].name);
            btnImage.sprite = pictImage[i];
            obj[i].GetComponent<Button>().interactable = true;  //未所持のキャラはボタンを押せるようにする
        }

        PlayerPrefs.SetString("pictInfo" + i, s);  //同時に保存内容を更新
        PlayerPrefs.Save();
    }

    //プレハブのボタンが押されたときの処理
    public void OnClickButton()
    {
        eventSystem = EventSystem.current;  //イベントシステムを利用してどのボタンを押しているかを取得  
        selectedObj = eventSystem.currentSelectedGameObject;
        // ボタンのImageコンポーネントからspriteデータの名前を取得
        string index = selectedObj.GetComponent<Image>().sprite.name;

        detailHold = Instantiate(detail, new Vector3(150, 200, 0), Quaternion.identity);
        detailHold.transform.SetParent(parentTran);
        detailHold.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        detailHold.transform.position = new Vector3(82, 170, 0);

        //ボタンを押している最中は他のボタンは押せない
        for(int i = 0; i<162;i++)
        {
            obj[i].GetComponent<Button>().interactable = false;
        }


        //子オブジェクトの取得
        GameObject objname = detailHold.transform.GetChild(2).gameObject;
        GameObject objstar = detailHold.transform.GetChild(1).gameObject;
        GameObject objcomment = detailHold.transform.GetChild(3).gameObject;
        GameObject objimage = detailHold.transform.GetChild(0).gameObject;

        int s = int.Parse(index);// int.Parse(this.gameObject.GetComponent<Image>().sprite.name);

        Debug.Log("s=" + s);

        ConveyInfo(s, out string name, out string star, out string comment);

        Debug.Log(s + name + star + comment);

        objname.GetComponent<Text>().text = name;
        objstar.GetComponent<Text>().text = star;
        objcomment.GetComponent<Text>().text = comment;
        objimage.GetComponent<Image>().sprite = pictImage[s];
    }

    //詳細画面にキャラクター情報を伝える
    public void ConveyInfo(int i, out string name, out string star, out string comment)
    {
        string line = ButtonFortune.character[i];
        string[] lineinfo = line.Split(',');
        name = lineinfo[1];
        int s = int.Parse(lineinfo[0]);  //星の数を整数化
        star = starStar(s);
        comment = lineinfo[2];
    }

    //☆を表示するためのメソッド
    public string starStar(int num)
    {
        string star = null;
        switch (num)
        {
            case 1:
                star = "★☆☆☆☆";
                break;
            case 2:
                star = "★★☆☆☆";
                break;
            case 3:
                star = "★★★☆☆";
                break;
            case 4:
                star = "★★★★☆";
                break;
            case 5:
                star = "★★★★★";
                break;
        }
        return star;
    }

    //プレハブの戻るボタンが押されたとき
    public void PrefabOnClick()
    {
        Destroy(detailHold);
        //詳細画面を消した後は他のボタンを押せる
        for (int i = 0; i < 162; i++)
        {
            if (PlayerPrefs.GetString("pictInfo" + i) == "true")
            {
                obj[i].GetComponent<Button>().interactable = true;
            }
        }
    }

}
