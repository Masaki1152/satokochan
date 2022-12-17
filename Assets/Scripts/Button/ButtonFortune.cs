using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Random = System.Random;



public class ButtonFortune : MonoBehaviour
{
    public static string[] character = {   "5,北条沙都子,今日も元気に頑張りますわよ！,0",
                            "4,古手梨花,私の大切な親友ですわ！,1",
                            "2,竜宮レナ,お持ち帰りぃ〜には注意しませんと。,2",
                            "1,園崎魅音,男勝りでも乙女心は傷つけたくないですわね。,3",
                            "1,園崎詩音,詩音さんを怒らせると怖いですわよ…,4",
                            "2,神楽坂明日菜,たまには誰かに頼ってもいいんですわよ。,5",
                            "3,綾瀬夕映,図書館で勉強するのも悪くないですわよ。,6",
                            "1,宮崎のどか,たまには髪を短くするのもよいですわよ,7",
                            "2,近衛木乃香,京都弁って癒されますわ〜,8",
                            "1,エヴァンジェリン,吸血鬼にはお気をつけあそばせ。,9",
                            "1,結城友奈,うどんを食べると運勢アップですわ！,10",
                            "2,東郷美森,友奈さんと美森さんのような友情、憧れますわぁ〜,11",
                            "1,犬吠埼風,リーダーシップが発揮できそうですわ！,12",
                            "1,犬吠埼樹,綺麗な歌声を聞かせてほしいですわ！,13",
                            "3,三好夏凛,たまにはツンデレも悪くないですわね。,14",
                            "2,乃木園子,満開のしすぎに注意...大赦は私が潰しますわ。,15",
                            "3,三ノ輪銀,もしもの事態は逃げ出すことが大事ですわ！,16",
                            "1,丈槍由紀,目の前の現実から逃げないで立ち向かう時ですわ！,17",
                            "1,恵飛須沢胡桃,ラッキーアイテムはシャベルですわ！,18",
                            "1,りーさん,頼りになる友達は大事にするべきですわ！,19",
                            "4,直樹美紀,偶には後輩を可愛がるのもいいですわよ！,20",
                            "3,めぐねえ,...エウアさんにお願いしてめぐねえさんを救いに行きますわ。,21",
                            "2,太郎丸,ゾンビには注意ですわ！,22",
                            "1,赤沢さん,窓ガラスには気を付けてくださいまし。,23",
                            "4,桜木ゆかり,階段は走らないように...\n特に雨の日は傘に気をつけてくださいまし。,24",
                            "1,見崎鳴,人形を大事にすると吉ですわよ。,25",
                            "2,水野早苗,エレベーターで楽せず階段を利用するべきですわ！,26",
                            "2,小椋由美,窓の外に乗り出さないよう注意ですわ！,27",
                            "1,雁淵ひかり,今日も元気いっぱい頑張れそうですわ！,28",
                            "1,ニパ,運がわるくてもくじけず、ですわ！,29",
                            "4,ロスマン,今日は人に説明すると良く理解してもらえそうですわ。,30",
                            "1,ラル,頼れるリーダーになれますわ！,31",
                            "2,エイラ,今日は予測がよく当たりそうですわ！,32",
                            "3,サーニャ,夜考え事をすると頭が冴えますわよ！,33",
                            "5,ルッキーニ,今日も笑顔で元気いっぱいに頑張れますわ！,34",
                            "3,宮藤芳佳,誰かを癒せる存在になれそうですわ！,35",
                            "1,ペリーヌ,ラッキーアイテムはメガネですわ。,36",
                            "1,リーネ,誰かを支えると吉ですわ。,37",
                            "1,ハルトマン,エリートであっても休む時は全力ですわ！,38",
                            "1,バルクホルン,常に厳しく、エリートを目指せますわ！,39",
                            "1,シャーリー,スピードの出し過ぎには注意ですわ！,40",
                            "1,ミーナ,良きリーダーになれますわ！,41",
                            "1,坂本美緒,ラッキーアイテムは烈風丸ですわ！,42",
                            "3,ゆりっぺ,強がりすぎは体に毒ですわ！,43",
                            "4,立華かなで,天使のような存在、憧れますわね！,44",
                            "1,春風どれみ,ステーキを食べれば運気アップですわ！,45",
                            "1,藤原はづき,思ったことをはっきり伝えることが重要ですわ！,46",
                            "4,妹尾あいこ,今日も元気いっぱいすごせそうですわ！,47",
                            "3,瀬川おんぷ,魔法を使用する時は注意ですわね。,48",
                            "1,源さくら,交通事故には注意ですわよ！,49",
                            "1,二階堂サキ,我慢比べには注意ですわよ！,50",
                            "4,水野愛,落雷には注意ですわね。,51",
                            "2,紺野純子,飛行機は避けた方が良いですわね。,52",
                            "1,ゆうぎり,人の話はよく聞くようにすべきですわ。,53",
                            "2,星川リリィ,過労は避けてよく休憩すべきですわ。,54",
                            "1,山田たえ,食事の際はマナーよく、ですわ。,55",
                            "2,ココア,今日も笑顔で頑張れそうですわ！,56",
                            "1,チノ,ラッキーアイテムはティッピーですわ！,57",
                            "5,リゼ,ラッキーヘアーはツインテールですわ！,58",
                            "1,千夜,和菓子を食べると吉ですわよ。,59",
                            "3,シャロ,たまにはツンデレもいいですわね。,60",
                            "1,マヤ,マヤさんの八重歯には親近感がありますわ！,61",
                            "1,メグ,メグさんみたいにバレエを習ってみたいですわ。,62",
                            "1,涼宮ハルヒ,不思議なことが起こりそうですわね。,63",
                            "4,長門有希,メガネを外すとまた別の世界が広がってますわよ。,64",
                            "1,朝比奈みくる,ドジなのもほどほどに...,65",
                            "1,泉こなた,オタク趣味を深く掘り下げると吉ですわ！,66",
                            "4,柊かがみ,ツッコミ担当になりそうですわね。,67",
                            "1,柊つかさ,ラッキーアイテムは大きなリボンですわね。,68",
                            "1,高良みゆき,歯医者を怖がってちゃいけませんわね。,69",
                            "1,平沢唯,ラッキーアイテムはギー太ですわ！,70",
                            "1,中野梓,後輩には優しく、ですわ！,71",
                            "2,秋山澪,縞々なものを身につけると吉ですわね。,72",
                            "3,田井中律,ヘアバンドはわたくしとの友情の証ですわ！,73",
                            "1,琴吹紬,太眉で割引が狙えそうですわ！,74",
                            "1,相生祐子,シャケやサバと相性が良さそうですわね。,75",
                            "3,長野原みお,絵を描くと運気アップですわ！,76",
                            "1,水上麻衣,ラッキーアイテムは菩薩像ですわね。,77",
                            "1,東雲なの,ラッキーアイテムはネジですわね。,78",
                            "2,はかせ,サメの絵を描くと運気アップですわ！,79",
                            "1,安中榛名,ぴょんぴょこぴょんぴょぴょんぴょんぴょぴょん！,80",
                            "1,トール,メイドのコスプレで運気アップですわ！,81",
                            "2,カンナ,たまには充電も必要ですわね。,82",
                            "1,イルル,バイトを頑張ると吉ですわね。,83",
                            "5,エルマ,プログラミングが捗りそうですわ！,84",
                            "1,ルコア,落ち着いた行動を取ると吉ですわね。,85",
                            "1,小林さん,小林さんのメイド愛には毎度驚かされますわ…,86",
                            "1,戦場ヶ原ひたぎ,文房具は武器ではありませんわね。,87",
                            "5,八九寺真宵,八重歯はわたくしとの友情の証ですわ！！,88",
                            "2,神原駿河,いつもより速く走ることができそうですわ！,89",
                            "1,千石撫子,生き物は大切にすべきですわ。,90",
                            "1,羽川翼,今日は知的に見られそうですわ！,91",
                            "2,鹿目まどか,ラッキーアイテムはピンクのリボンですわ！,92",
                            "5,美樹さやか,さやかさん...絶対魔女にはさせませんわ！,93",
                            "3,巴マミ,先輩でも悩みは聞いてあげるべきですわ。,94",
                            "1,暁美ほむら,まどかさん愛がすごいですけど梨花愛は負けませんわよ。,95",
                            "1,佐倉杏子,美味しい食べ物に出会えそうですわ！,96",
                            "3,キュゥべえ,きゅっぷい...ちょっと言ってみたかっただけですのよ。,97",
                            "2,星空みゆき,今日も元気にウルトラハッピーですわ！,98",
                            "4,青木れいか,ラッキーアイテムは弓矢ですわ！,99",
                            "3,羽衣ララ,初対面の人とも仲良くなれますですわ！,100",
                            "1,野々原ゆずこ,今日も元気に頑張れそうですわ！,101",
                            "1,櫟井唯,今日はツッコミ担当になりそうですわね。,102",
                            "1,日向縁,今日はマイペースに過ごせそうですわね。,103",
                            "2,折部やすな,今日も元気に過ごせそうですわ！,104",
                            "3,ソーニャ,熊との遭遇には注意ですわね。,105",
                            "2,シャーロック,大きなリボンがラッキーアイテムですわ！,106",
                            "5,譲崎ネロ,今日はたくさん食べると吉ですわ！,107",
                            "1,エリー,もっと自分に自信を持つべきですわね。,108",
                            "1,コーデリア,コーデリアさん、頭がお花畑ですわね。,109",
                            "1,明智小衣,今日はIQがとっても上がりそうですわね。,110",
                            "2,ゆの,今日はゆっくり入浴すると吉ですわよ。,111",
                            "1,宮子,雨の日の乾燥剤には気をつけるべきですわ。,112",
                            "4,ヒロ,ヒロさんには料理を教えてもらいたいですわ。,113",
                            "1,沙英,文章を書くと運気アップですわ！,114",
                            "3,乃莉,ラッキーアイテムはパソコンですわ！,115",
                            "1,なずな,おっとりマイペースに過ごせそうですわね。,116",
                            "1,赤座あかり,存在感をアピールすると吉ですわね。,117",
                            "3,吉川ちなつ,腹黒くても可愛ければ問題なしですわ！,118",
                            "1,歳納京子,今日も元気いっぱい頑張れそうですわ！,119",
                            "1,船見結衣,読書すると運気アップですわね。,120",
                            "5,大室桜子,磯辺揚げを食べるとさらに運気アップですわ！,121",
                            "2,古谷向日葵,桜子さんに振り回されないよう注意ですわね。,122",
                            "1,杉浦綾乃,たまには素直になるのもいいですわよ。,123",
                            "4,池田千歳,鼻血の出し過ぎはよくないですわよ。,124",
                            "2,アリス,金髪にすると運気アップですわね！,125",
                            "1,大宮忍,たまには和食もいいですわよ。,126",
                            "1,猪熊陽子,兄弟を大切にすると吉ですわね。,127",
                            "4,小路綾,ツンデレ、最高ですわよ！！,128",
                            "1,九条カレン,カタコトな日本語もいいですわね。,129",
                            "2,小田切双葉,たくさん食べるといいことがありますわ！,130",
                            "1,西川葉子,パンにマヨネーズをつけると美味しいですわ。,131",
                            "3,葉山照,猫をなでると運気アップですわ！,132",
                            "2,薗部篠,薗部さんみたいなメイドに会ってみたいですわね。,133",
                            "3,涼風青葉,頑張る人を見ると元気がもらえますわよ！,134",
                            "3,飯島ゆん,肌を見せない服もたまにはいいですわね。,135",
                            "1,篠田はじめ,たまには特撮趣味もいいですわよ。,136",
                            "1,滝本ひふみ,ハリネズミがラッキーアニマルですわね。,137",
                            "1,八神コウ,いいイラストが描けそうですわ！,138",
                            "1,望月紅葉,負けず嫌いは玉に瑕ですわよ。,139",
                            "3,鳴海ツバメ,なるっちさんは努力家で尊敬してますわ！,140",
                            "2,吉田優子,できるまぞくを目指せば吉ですわ！,141",
                            "3,千代田桃,ストイックな筋トレが必要ですわね。,142",
                            "1,陽夏木ミカン,レモンをかけると運気アップですわ！,143",
                            "1,リリス,ご先祖様は大切に、ですわよ。,144",
                            "2,リコ,リコさんの料理、食べてみたいですわね。,145",
                            "1,高山春香,妄想は程々に...ですわね。,146",
                            "1,園田優,抹茶関連のものを口にすると吉ですわ！,147",
                            "1,野田コトネ,今しかできないことに挑戦するとよいですわ！,148",
                            "2,南しずく,たまには正直に想いを伝えるべきですわね。,149",
                            "4,飯塚ゆず,髪の外ハネは最高のトレードマークですわ！,150",
                            "2,池野楓,イタズラはほどほどにすべきですわね。,151",
                            "1,キサラギ,素描より素猫の方が好きなんですの。,152",
                            "1,キョージュ,ラッキーカラーは当然、黒色ですわ。,153",
                            "4,ナミコさん,ナミコさんの暖かさにふれてみたいですわ。,154",
                            "1,トモカネ,やっぱり元気いいのが一番ですわね。,155",
                            "3,ノダミキ,元気がいいのはいいですけれど闇鍋は嫌ですわ。,156",
                            "1,あーさん,天気のいい日は白い雲を描くのもいいですわよ。,157",
                            "1,るん,おでこを見せる髪型が吉ですわね。,158",
                            "2,トオル,金属バットを振り回す…圭一さんかしら？,159",
                            "3,ナギ,眼鏡をはずすと美人…萌えますわね。,160",
                            "4,ユー子,スタイルの良さに料理上手…憧れますわね。,161",
                            "1,花小泉杏,何事も考え方ひとつで楽しめますわよ。,162",
                            "2,雲雀丘瑠璃,ラッキーアイテムは工事現場の看板…らしいですわ。,163",
                            "1,久米川牡丹,日ごろから体力をつけておく必要がありますわ。,164",
                            "3,萩生響,進む方向を間違えないよう気を付けてくださいまし。,165",
                            "4,江古田蓮,しっかりと睡眠をとると吉ですわね！,166",
                            "1,千矢,千矢さんはレディーなのに野生児すぎますわよね。,167",
                            "2,紺,紺さんは色んなコスプレが似合うお方ですわよね。,168",
                            "3,小梅,ラッキーアイテムは魔女のほうきですわよ！,169",
                            "1,ノノ,社交性を意識してみると吉ですわよ！,170",
                            "1,ニナ,こういう先生って憧れますわよね。,171",
                            "1,佐久,佐久隊長、いつも見廻りお疲れ様ですわ！,172",
                            "4,セイバー,凛々しい騎士様、憧れますわよね。,173",
                            "2,遠坂凛,凛さん、本当にかっこいい女性ですわよね。,174",
                            "5,イリヤ,イリヤさんとは親友になれそうな気がしますわ。,175",
                            "1,間桐桜,ライダーさんとの絡み、もっと見たいですわね。,176",
                            "1,朝霧彩,人を思う気持ちはいつまでも持っていたいですわ。,177",
                            "3,奴村露乃,復讐は何も解決しないですわよ。,178",
                            "2,潮井梨ナ,レディーなので変顔はほどほどに…,179",
                            "4,穴沢虹海,虹海さんのアイドル魂、とても憧れますわ！,180",
                            "1,雫芽さりな,感謝の気持ちはしっかりと伝えると吉ですわよ。,181",
                            "2,雨谷小雨,うっかり手を切らないように注意ですわね。,182",
                            "1,泉ヶ峰みかり,みかりさんのようにほうきで空を飛びたいですわ。,183",
                            "1,燐賀紗雪,最強の剣裁き、かっこよすぎますわ。,184",
                            "1,睡蓮寺清春,どうみても女の子にしか見えないんですのよ…,185",
                            "1,滝口あさひ,今日はパワーアップした１日になりますわよ！,186",
                            "1,一之瀬花名,ヒミツがあったら正直に伝えると吉ですわ。,187",
                            "2,百地たまて,今日はウナギを食べると運気アップですわ！,188",
                            "1,十倉栄依子,今日は人づきあいがより一層うまくなりそうですわ！,189",
                            "1,千石冠,たくさん食べること、それが幸運への近道ですわ。,190",
                            "5,万年大会,今日はおしゃれをして出かけると良いことがありますわ！,191",
                            "1,押本ユリ,困った先輩達には注意ですわよ。,192",
                            "1,新庄かなえ,何かあれば夜叉の構えで乗り切れますわ。,193",
                            "4,高宮なすの,メニメニマニマニが頭から離れませんわ…,194",
                            "1,板東まりも,まりもさんは困った変態さんですわ。,195",
                            "2,トマリン,トマリンさんは少し変わった宇宙人ですわよね。,196",
                            "3,デ・ジ・キャラット,語尾に“にょ”を付けると運気アップですわ！,197",
                            "1,プチ・キャラット,目からビームが出せるようになりそうですわ。,198",
                            "2,ラ・ビ・アン・ローズ,ウサギの耳で飛ぶ技術が本当に不思議ですわ。,199",
                            "4,ピョコラ＝アナローグⅢ世,似ているので時々わたくしと見間違えてしまいますわ。,200",
                            "2,吹雪,努力は必ず結果を導きますわ！,201",
                            "1,睦月,睦月さんは本当に心優しい方ですわよね。,202",
                            "2,夕立,今日はいい日っぽい、ですわよ。,203",
                            "5,島風,課題や問題事が迅速に解決しそうですわね！,204",
                            "1,赤城,カレーを食べると運気がアップしそうですわ！,205",
                            "1,瑞鶴,やっぱりツインテールは正義ですわよね！,206",
                            "1,金剛,今日も一日、元気よく過ごせそうですわ！,207",
                            "2,川内,今日は昼間より夜の方が集中できそうですわね。,208",
                            "1,神通,今日は物静かに過ごすのがよさそうですわよ。,209",
                            "3,那珂,那珂さんみたいな元気いっぱいなアイドルもいいですわよね。,210"
                         };
    List<string>star1;
    List<string>star2;
    List<string>star3;
    List<string>star4;
    List<string>star5;
    Text theme;
    Random r;
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
    

    //他のシーンを参照可能にする
    public static string[] pictInfo;     //PlayerPrefsはboolを許可しないため、stringで判断

    // Start is called before the first frame update
    void Start()
    {
        position =  obj.transform.position;
        eulerAngles =  obj.transform.eulerAngles;

        //所持しているかどうかの判定をする配列
        pictInfo = new string[211];
        for (int i = 0; i < 211; i++)
        {
            pictInfo[i] = PlayerPrefs.GetString("pictInfo" + i,"false");   //未所持であればfalse、初期化
        }

        //一旦すべて保存
        for (int i = 0; i < 211; i++)
        {
            PlayerPrefs.SetString("pictInfo" + i, pictInfo[i]);
            PlayerPrefs.Save();
        }
        
        //一旦すべて保存されているかを確認
        for (int i = 0; i < 211; i++)
        {
            Debug.Log("配列の中身" + i + "は" + PlayerPrefs.GetString("pictInfo" + i));
        }
        

        r = new Random();
        theme = GameObject.FindGameObjectWithTag("Comment").GetComponent<Text>();

        star1 = new List<string>();
        star2 = new List<string>();
        star3 = new List<string>();
        star4 = new List<string>();
        star5 = new List<string>();
        for(int i= 0;i<character.Length;i++)
        {
            int starNum = NumExtract(character[i]);
            string nameInfo = NameExtract(character[i]);
            switch(starNum)
            {
                case 1:
                    star1.Add(nameInfo);
                    break;
                case 2:
                    star2.Add(nameInfo);
                    break;
                case 3:
                    star3.Add(nameInfo);
                    break;
                case 4:
                    star4.Add(nameInfo);
                    break;
                case 5:
                    star5.Add(nameInfo);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClicked()
    {
        //１日に１回しか押せない処理
        if (isClicked() == false)
        {
            btnM.interactable = false;  //処理中はボタンを押せなくする
            btnF.interactable = false;  //処理中はボタンを押せなくする
            btnW.interactable = false;  //処理中はボタンを押せなくする
            btnP.interactable = false;  //処理中はボタンを押せなくする

            SatokoAction();
            commentShow(); //コメントパネルの表示
            theme.text = null;

            //int star = 0;
            int point = r.Next(0, 100);
            StarNum(point, out string nameInfo, out int st);
            string[] info = nameInfo.Split(',');
            string starDescribe = starStar(st);

            //テキストへの書き込み
            textline = "私が占ってさしあげますわ。\n今日の運勢は" + starDescribe + "でしてよ！\nラッキーパーソンは...<color=#000080>" + info[0] + "</color>。\n" + info[1];

            StartCoroutine(Communication(textline));
            Debug.Log(info[2]);
            int n = int.Parse(info[2]);
            ChangeBool(int.Parse(info[2]));   //図鑑に画像を登録させるためにtrue/falseの登録
            Debug.Log(pictInfo[n]);
            Debug.Log("FortuneのButtonClickの後は" + PlayerPrefs.GetString("pictInfo" + n));
            //今日のキャラを保存
            PlayerPrefs.SetString("TodayText",textline);
            PlayerPrefs.Save();
        }
        else
        {
            btnM.interactable = false;  //処理中はボタンを押せなくする
            btnF.interactable = false;  //処理中はボタンを押せなくする
            btnW.interactable = false;  //処理中はボタンを押せなくする
            btnP.interactable = false;  //処理中はボタンを押せなくする

            SatokoAction();
            commentShow();  //コメントパネルを表示する
            StartCoroutine(Communication(PlayerPrefs.GetString("TodayText")));

            Debug.Log("second");
        }

    }

    //文字列から数字を抽出するメソッド
    public int NumExtract(string line)
    {
        int num = int.Parse(line.Substring(0,1));
        return num;
    }

    //文字列から名前以降を取り出すメソッド
    public string NameExtract(string line)
    {
        string nameinfo = line.Substring(2, line.Length - 2);
        return nameinfo;
    }

    //0~100の数字から星の数を決め、名前以降の情報を文字列として抽出するメソッド
    public void StarNum(int point, out string nameInfo, out int st)
    {
        int lucky = 0;
        if (point >= 0 && point <= 5)
        {
            //☆5の時
            st = 5;
            lucky = r.Next(0, star5.Count - 1);
            nameInfo = star5[lucky];
        }
        else if (point <= 15)
        {
            //☆4の時
            st = 4;
            lucky = r.Next(0, star4.Count - 1);
            nameInfo = star4[lucky];
        }
        else if (point <= 30)
        {
            //☆3の時
            st = 3;
            lucky = r.Next(0, star3.Count - 1);
            nameInfo = star3[lucky];
        }
        else if (point <= 50)
        {
            //☆2の時
            st = 2;
            lucky = r.Next(0, star2.Count - 1);
            nameInfo = star2[lucky];
        }
        else
        {
            //☆1の時
            st = 1;
            lucky = r.Next(0, star1.Count - 1);
            nameInfo = star1[lucky];
        }

    }

    //☆を表示するためのメソッド
    public string starStar(int num)
    {
        string star = null;
        switch(num)
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
            switch (flag)
            {
                case 0:
                    theme.text += texts[i].ToString();
                    yield return new WaitForSeconds(0.1f);
                    if (texts[i + 1] == '<')
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
                    break;
            }

        }
        flag = 0;

        yield return new WaitForSeconds(10.0f);
        theme.text = "";
        commentPanel.SetActive(false);    //会話後にコメントパネルを消す
        latestButtonClick = DateTimeString(System.DateTime.Now);
        PlayerPrefs.SetString("LatestButtonClick", latestButtonClick);  //１回目を終えたため
        PlayerPrefs.Save();
        btnM.interactable = true;  //処理後はボタンを押せる
        btnF.interactable = true;  //処理後はボタンを押せる
        btnW.interactable = true;  //処理後はボタンを押せる
        btnP.interactable = true;  //処理後はボタンを押せる
    }

    public void commentShow()
    {
        commentPanel.SetActive(true);
    }

    //以下アニメーション設定
    public void SatokoAction()
    {

        Random r = new Random();
        int rnd = r.Next(1, 8);
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
                animator.SetBool("Poster", true);
                StartCoroutine("IEPoster");
                break;
            case 4:
                animator.SetBool("Yubisashi", true);
                StartCoroutine("IEYubisashi");
                break;
            case 5:
                animator.SetBool("Zoi", true);
                StartCoroutine("IEZoi");
                break;
            case 6:
                animator.SetBool("Figure", true);
                StartCoroutine("IEFigure");
                break;
            case 7:
                animator.SetBool("Koshiate", true);
                StartCoroutine("IEKoshiate");
                break;
        }

        Debug.Log("アニメーション番号は、" + rnd);
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

    IEnumerator IEZoi()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Zoi", false);
    }

    IEnumerator IEFigure()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Figure", false);
        obj.transform.eulerAngles = eulerAngles;
        obj.transform.position = position;
    }

    IEnumerator IEKoshiate()
    {
        yield return new WaitForSeconds(15.0f);
        animator.SetBool("Koshiate", false);
    }

    //１日に１回しかボタンを押せないようにする
    //本日ボタンを押したかを返す
    public bool isClicked()
    {
        string today = DateTimeString(System.DateTime.Now);

        Debug.Log(today);
        Debug.Log(PlayerPrefs.GetString("LatestButtonClick"));
        //初めてならfalse,２回目以降ならtrue
        if (today == PlayerPrefs.GetString("LatestButtonClick"))
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

    //所持しているかを確認する配列に所持ならtrueを代入
    public void ChangeBool(int i)
    {
        //所持していた場合、画像を変更する
        if (pictInfo[i] == "false")      //初登場だった場合の処理
        {
            pictInfo[i] = "true";
            PlayerPrefs.SetString("pictInfo" + i, pictInfo[i]);  //同時に保存内容を更新
            PlayerPrefs.Save();
            Debug.Log("FortuneのChangeBoolの後は" + PlayerPrefs.GetString("pictInfo" + i));
        }
    }

}
