using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;

public class ButtonMission : MonoBehaviour
{
    DateTime day;
    string[] eyes = { "ノーマル", "つり目", "たれ目", "とろ目", "じと目" };
    string[] longhair = { "ロング／ストレート", "ロング／パーマ", "ロング／ワンレン", "ロング／縦ロール", "ロング／姫カット" };
    string[] semilonghair = { "セミロング／ストレート" };
    string[] medium = { "ミディアム／パーマ", "ミディアム／カーリー" };
    string[] shorthair = { "ショート／ストレート", "ショート／パーマ", "ショート／ボブ", "ショート／マッシュボブ", "ショート／ウルフカット", "ショート／ベリーショート" };
    string[] elsehair = { "おさげ", "ポニーテール", "ワンサイドアップ", "ハーフアップ", "サイドテール", "ツインテール", "シニヨン", "ツイストティアラ" };
    string[] addItem = { "ヘアゴム", "ヘアピン", "シュシュ", "ヘアバンド", "バレッタ", "リボン" };
    string eyeTheme;
    string hairTheme;
    string addItemTheme;
    Random r;
    Text theme;
    char[] texts;
    [SerializeField] GameObject commentPanel;
    public Animator animator;
    public GameObject obj;
    Vector3 position;
    Vector3 eulerAngles;
    string latestButtonClick;    // 最新の日付
    string textline;   //テクストの保存用
    public Button btnM; //処理中はボタンを押せなくする
    public Button btnF; //処理中はボタンを押せなくする
    public Button btnW; //処理中はボタンを押せなくする
    public Button btnP; //処理中はボタンを押せなくする

    public static List<string> WorkStr;  //作品の数をリストで表示。図鑑と違い、追加していくもののため。


    // Start is called before the first frame update
    void Start()
    {
        position =  obj.transform.position;
        eulerAngles =  obj.transform.eulerAngles;
        r = new Random();
        theme = GameObject.FindGameObjectWithTag("Comment").GetComponent<Text>();
        commentPanel.SetActive(false);
        WorkStr = new List<string>();
        day = DateTime.Now;   //今日の日付を取得
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ボタンが押された時の処理
    public void ButtonClicked()
    {
        //１日に１回しか押せない処理
        if(isClicked()==false)
        {
            btnM.interactable = false;  //処理中はボタンを押せなくする
            btnF.interactable = false;  //処理中はボタンを押せなくする
            btnW.interactable = false;  //処理中はボタンを押せなくする
            btnP.interactable = false;  //処理中はボタンを押せなくする

            SatokoAction();
            commentShow();  //コメントパネルを表示する
            theme.text = null;

            Debug.Log("first");

            int eyeNum = r.Next(0,5);  //目のテーマの決定
            eyeTheme = eyes[eyeNum];
            int hairNum = r.Next(0,5);  //髪のテーマの決定
            hairTheme = todayHair(hairNum);
            int itemNum = r.Next(0,6);
            addItemTheme = addItem[itemNum];
            //テキストへの書き込み
            textline = "今日のテーマは...\n目は<color=#008000>" + eyeTheme + "</color>、髪型は<color=#0000ff>" + hairTheme + "</color>で、ヘアアクセサリーは<color=#ff4500>" + addItemTheme + "</color>のキャラクターですわ！\n可愛くお描きあそばせ☆";

            StartCoroutine(Communication(textline));

            //過去のテーマに格納するために要素をリストに追加
            string ws = eyeTheme + "," + hairTheme + "," + addItemTheme + "," + day.ToString("yyyy/MM/dd");
            WorkStr.Add(ws);
            int hold = WorkStr.Count - 1;
            PlayerPrefs.SetString("WorkRefer" + hold, ws);
            Debug.Log("ws=" + ws);
         }
         else  //既に押していたら
        {
            btnM.interactable = false;  //処理中はボタンを押せなくする
            btnF.interactable = false;  //処理中はボタンを押せなくする
            btnW.interactable = false;  //処理中はボタンを押せなくする
            btnP.interactable = false;  //処理中はボタンを押せなくする

            SatokoAction();
            commentShow();  //コメントパネルを表示する
            StartCoroutine(Communication(textline));

            Debug.Log("second");
        }
    }

    //一文字ずつ表示するメソッド
    IEnumerator Communication(string line)
    {
        texts = line.ToCharArray();
        int flag = 0;
        string preserve = null;
        int num = 0;

        //<color>などをテキストに表示させないために遷移を利用
        for (int i = 0; i < texts.Length; i++)
        {
            switch(flag)
            {
                case 0:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if(texts[i + 1] == '<')
                    {
                        flag = 1;
                    }
                    break;
                case 1:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if (num == 2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 2;
                        num = 0;
                    }
                    break;
                case 2:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if (texts[i + 1] == '<')
                    {
                        flag = 3;
                    }
                    break;
                case 3:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if(num==2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 4;
                        num = 0;
                    }
                    break;
                case 4:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if (texts[i + 1] == '<')
                    {
                        flag = 5;
                    }
                    break;
                case 5:
                    preserve += texts[i].ToString();
                    if (texts[i - 1] == '>')
                    {
                        num++;
                    }
                    if(num==2)
                    {
                        theme.text += preserve;
                        preserve = null;
                        flag = 6;
                        num = 0;
                    }
                    break;
                case 6:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    break;
            }
            
        }
        flag = 0;

        yield return new WaitForSeconds(10.0f);
        theme.text = "";
        commentPanel.SetActive(false);    //会話後にコメントパネルを消す
        latestButtonClick = DateTimeString(System.DateTime.Now);
        btnM.interactable = true;  //処理後はボタンを押せる
        btnF.interactable = true;  //処理後はボタンを押せる
        btnW.interactable = true;  //処理後はボタンを押せる
        btnP.interactable = true;  //処理後はボタンを押せる
    }

    public string todayHair(int num)   //髪の長さごとに詳細な情報を表示するためのメソッド
    {
        string hair = null;
        int randNum;

        switch (num)
        {
            case 0:  //ロングの時
                randNum = r.Next(0, 5);
                hair = longhair[randNum];
                break;
            case 1:  //セミロングの時
                hair = semilonghair[0];
                break;
            case 2:  //ミディアムの時
                randNum = r.Next(0, 2);
                hair = medium[randNum];
                break;
            case 3:
                randNum = r.Next(0, 6);
                hair = shorthair[randNum];
                break;
            case 4:
                randNum = r.Next(0, 8);
                hair = elsehair[randNum];
                break;
        }
        return hair;
    }

    public void commentShow()
    {
        commentPanel.SetActive(true);
    }

    //以下アニメーション設定
    public void SatokoAction()
    {
        
        Random r = new Random();
        int rnd = r.Next(1, 6);
        switch (rnd)
        {
            case 1:
                animator.SetBool("Head_Lean", true);
                StartCoroutine("IEHead_Lean");
                break;
            case 2:
                animator.SetBool("Kizoku", true);
                StartCoroutine("IEKizoku");
                break;
            case 3:
                animator.SetBool("Koshiate", true);
                StartCoroutine("IEKoshiate");
                break;
            case 4:
                animator.SetBool("Poster", true);
                StartCoroutine("IEPoster");
                break;
            case 5:
                animator.SetBool("Yubisashi", true);
                StartCoroutine("IEYubisashi");
                break;
        }

        Debug.Log("Yes," + rnd);
    }

    IEnumerator IEHead_Lean()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Head_Lean", false);
    }

    IEnumerator IEKizoku()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Kizoku", false);
    }

    IEnumerator IEKoshiate()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Koshiate", false);
    }

    IEnumerator IEPoster()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Poster", false);
        obj.transform.eulerAngles = eulerAngles;
        obj.transform.position = position;
    }

    IEnumerator IEYubisashi()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Yubisashi", false);
    }

    //１日に１回しかボタンを押せないようにする
    //本日ボタンを押したかを返す
    public bool isClicked()
    {
        string today = DateTimeString(System.DateTime.Now);

        Debug.Log(today);
        Debug.Log(latestButtonClick);
        //初めてならfalse,２回目以降ならtrue
        if (today == latestButtonClick)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    
    //DateTime変数をYYYY/MM/DD形式で返す
    public string DateTimeString(DateTime date)
    {
        return date.Year.ToString() + "/" + date.Month.ToString() + "/" + date.Day.ToString();
    }
}
