using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement; //シーン移動用
using System.IO;      //画像ファイル検索用


public class WorkRefer : MonoBehaviour
{
    public RectTransform contentRectTransform;
    public Button workbutton;
    Button[] obj = new Button[ButtonMission.WorkStr.Count];
    public GameObject detail;  //詳細画面のプレハブ
    GameObject detailHold;
    public Transform parentTran;
    EventSystem eventSystem;
    GameObject selectedObj;  //今選択しているボタンのインデックスを取り出す
    string index; //何番目のボタン
    public static int btnindex; //ボタンのインデックスを格納
    public static string saveName; //保存ボタンの名前
    GameObject objsave; //詳細画面の保存ボタンのインスタンス格納
    public static Sprite[] saveImage; //保存した画像を格納する配列
    public static string[] imgInfo; //詳細画面の画像が変更されたかを確認する配列
    Image btnImage;
    int workNum; //作品数
    public Sprite defaultimg;
    List<Sprite> SaveImageList = new List<Sprite>(); //一旦pngをテクスチャにしてスプライトにするために必要なリスト
    string[] path; //画像保存用のパスを格納



    private void Start()
    {
        //PlayerPrefs.SetInt("WorkNum", 0);   //初期化用
        workNum = PlayerPrefs.GetInt("WorkNum");     //リストの個数を取得
        /*for (int i = 0; i <workNum;i++)   //初期化用
        {
            PlayerPrefs.SetString("imgInfo"+ i, "false");
        }*/
        imgInfo = new string[workNum];
        saveImage = new Sprite[workNum];
        Debug.Log("作品数は" + workNum);

        //作品数の数だけボタンを生成
        for (int i = 0; i < workNum; i++)
        {
            obj[i] = Instantiate(workbutton, contentRectTransform);  //オブジェクトの生成
            obj[i].name = i.ToString();
            //日付を追加する
            string line = PlayerPrefs.GetString("WorkRefer" + i);
            string[] lineinfo = line.Split(',');
            obj[i].GetComponentInChildren<Text>().text = lineinfo[3];

            Button btn = obj[i].GetComponent<Button>();
            btn.onClick.AddListener(OnClickButton);
            Debug.Log("obj" + i + "を作成しました。");
            btnImage = obj[i].GetComponent<Image>();


            //既に変更していれば画像を表示
            if (PlayerPrefs.GetString("imgInfo" + i) == "true")
            {
                pngtoSprite(i);
                btnImage.sprite = saveImage[i];
            }
            else
            {
                btnImage.sprite = defaultimg;
            }
        }
    }

    public void OnClickButton()
    {
        eventSystem = EventSystem.current;  //イベントシステムを利用してどのボタンを押しているかを取得  
        selectedObj = eventSystem.currentSelectedGameObject;
        // ボタンの名前を取得
        index = selectedObj.name;
        Debug.Log("詳細画面名は" + index);

        //既に詳細画面を生成していれば画面外のものを持ってきて、していなければ新しく生成する。
        if (GameObject.Find("detailHold" + index) == null)
        {
            detailHold = Instantiate(detail, new Vector3(150, 200, 0), Quaternion.identity);
            detailHold.name = "detailHold" + index;
            detailHold.transform.SetParent(parentTran);
            detailHold.transform.localScale = new Vector3(0.75f, 0.75f, 1);
            detailHold.transform.position = new Vector3(530, 1000, 0);


            //子オブジェクトの取得
            GameObject objday = detailHold.transform.GetChild(0).gameObject;
            GameObject objpict = detailHold.transform.GetChild(1).gameObject;
            GameObject butpict = detailHold.transform.GetChild(2).gameObject;
            GameObject objeye = detailHold.transform.GetChild(3).gameObject;
            GameObject objhair = detailHold.transform.GetChild(4).gameObject;
            GameObject objitem = detailHold.transform.GetChild(5).gameObject;
            objsave = detailHold.transform.GetChild(7).gameObject;

            //ボタンを透明にする
            Image dhimg = butpict.gameObject.GetComponent<Image>();
            dhimg.color = new Color(255, 255, 255, 0);

            int btnindex = int.Parse(index);
            ConveyInfo(btnindex, out string eye, out string hair, out string item, out string day);

            objday.GetComponent<Text>().text = day;
            objeye.GetComponent<Text>().text = "目：" + eye;
            objhair.GetComponent<Text>().text = "髪型：" + hair;
            objitem.GetComponent<Text>().text = "アクセ：" + item;

            //保存ボタンの名前を変更
            objsave.name = index;
            saveName = objsave.name;

            Image pctimg = objpict.gameObject.GetComponent<Image>();
            Debug.Log("詳細画面の画像の名前は" + pctimg.sprite.name);

            //既に変更した画像があれば表示する 
            if (PlayerPrefs.GetString("imgInfo" + btnindex) == "true")
            {
                pctimg.sprite = saveImage[btnindex];
                Debug.Log("既に変更した画像がありました。");
            }
            else
            {
                pctimg.sprite = defaultimg;
                Debug.Log("既に変更した画像がありません。");
            }


            //詳細画面を開いているとき、他のボタンを押せなくする
            for (int i = 0; i < workNum; i++)
            {
                Button butobj = obj[i].GetComponent<Button>();
                butobj.interactable = false;
            }
        }
        else
        {
            Debug.Log("2回目の生成になります。");
            GameObject dlClone = GameObject.Find("detailHold" + index);
            dlClone.transform.SetParent(parentTran);
            dlClone.transform.localScale = new Vector3(0.75f, 0.75f, 1);
            dlClone.transform.position = new Vector3(530, 1000, 0);

            GameObject dlpict = dlClone.transform.GetChild(1).gameObject;
            Image pctimg = dlpict.GetComponent<Image>();
            btnindex = int.Parse(index);
            Debug.Log("2回目の画像変更のインデックスは：" + index);
            Debug.Log("2回目の画像変更のboolは：" + PlayerPrefs.GetString("imgInfo" + btnindex));
            //既に変更した画像があれば表示する 
            if (PlayerPrefs.GetString("imgInfo" + btnindex) == "true")
            {
                pctimg.sprite = saveImage[btnindex];
            }

            //詳細画面を開いているとき、他のボタンを押せなくする
            for (int i = 0; i < workNum; i++)
            {
                Button butobj = obj[i].GetComponent<Button>();
                butobj.interactable = false;
            }

            //保存ボタンの名前を変更
            objsave.name = index;
            saveName = objsave.name;
        }

    }

    //詳細画面にキャラクター情報を伝える
    public void ConveyInfo(int i, out string eye, out string hair, out string item, out string day)
    {
        string line = PlayerPrefs.GetString("WorkRefer" + i);
        string[] lineinfo = line.Split(',');
        eye = lineinfo[0];
        hair = lineinfo[1];
        item = lineinfo[2];
        day = lineinfo[3];
    }

    //プレハブの戻るボタンが押されたとき
    public void PrefabOnClick()
    {
        //destroyを使うとAddImageが使えないエラーが出るため、画面外に移動させてdestroyを使わない。
        GameObject dlClone = GameObject.Find("detailHold" + index);
        dlClone.transform.position += new Vector3(-1200.0f, 0.0f, 0.0f);
        //詳細画面を閉じると、他のボタンを押せるようにする
        for (int i = 0; i < workNum; i++)
        {
            Button butobj = obj[i].GetComponent<Button>();
            butobj.interactable = true;
        }
    }

    //簡易画面のボタンを即座に変更するメソッド
    public void PushChangeImage()
    {
        //画像ファイル名に使う変数
        int i = int.Parse(saveName);

        Debug.Log("ボタン２つ目もキチンと呼ばれています。画像番号は" + i);

        //簡易画面の画像も変化させる
        Image bimg = obj[i].gameObject.GetComponent<Image>();
        pngtoSprite(i);
        bimg.sprite = saveImage[i];
    }

    //png画像をスプライトに変換する
    public void pngtoSprite(int i)
    {
#if UNITY_EDITOR
        path = Directory.GetFiles(@"Assets/Resources/MyWork", "*.png");
        Debug.Log("パスはエディター用が使われています。");
#elif  !UNITY_EDITOR && UNITY_IOS
        //iOSのみ
        path = Directory.GetFiles(UnityEngine.Application.persistentDataPath, "*.png");
        Debug.Log("パスはiOS用が使われています。");
#endif

        if (i < path.Length)
        {
            //画像を使える形に変える
            //Texture2Dに変換
            string thispath = path[i];
            byte[] bytes = File.ReadAllBytes(thispath);
            Texture2D texture = new Texture2D(2, 2);
            texture.LoadImage(bytes);

            //Debug.Log("スプライト変換1　ここまでは実行できました。");

            //spriteに変換
            Rect rect = new Rect(0f, 0f, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, rect, Vector2.zero);

            //Debug.Log("スプライト変換2　ここまでは実行できました。");

            //spriteを格納
            saveImage[i] = sprite;

            //Debug.Log("スプライト変換3　ここまでは実行できました。");
        }
        else
        {
            //Debug.Log("スプライト変換4　ここまでは実行できました。");

            saveImage[i] = defaultimg;

            //Debug.Log("スプライト変換5　ここまでは実行できました。");
        }
    }
}
