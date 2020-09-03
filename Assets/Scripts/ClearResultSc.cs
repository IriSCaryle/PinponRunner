using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClearResultSc : MonoBehaviour
{
    public CanvasRenderer[] RankNumber = new CanvasRenderer[10];//順位のCanvasRendererが入っている
    public CanvasRenderer[] RankAlphaNum = new CanvasRenderer[4];//ボーダーのランクのCanvasRendererが入っている
    public int[] timeBorder =new int[4];//ボーダーをint型で入れる配列
    public string[] Timeboad = new string[10];//タイムを文字列で入れる配列
    public int[] Timeboadtoint = new int[10];//順位をintで入れる配列
    public int nowTimeintScore;//現在測定終了したタイム(int)
    public static string nowTimeScore;//現在測定終了したタイム
    public Text TimeScore;//タイムを表示するテキスト
    public string TimeTemp;//一時的に取り出すstringのタイム
    public int TimetointTemp;//一時的に取り出すintのタイム
    public int bordernum;//クリアランクを判定するための変数
    public int ranknum;//順位を判定するための変数
    public string[] TimeboadName = new string[10];
    public string TimeboadtmpName;
    public string Playernames = "nowPlayer";
    bool isntrankin;//ランクインしていない判定
    bool isupdate;//記録更新してない判定
    //オブジェクトとして呼ぶための変数
    public DateTime Todaynow;//日時
    public String TodaynowString;
    public DateTime[] TimeArray = new DateTime[10];
    public DateTime tempTime;
    public String tempTimestring;
    public String[] TimeArraystring = new string[10];
    public Image Rank;
    public Image ClearTime;
    public Image RankInTxt;
    public Image RankUpdate;
    public Image GameClear;
    public Image Comments;
    //透明にするためのキャンバス
    public CanvasRenderer TimeScoreAlpha;
    public CanvasRenderer RankAlpha;
    public CanvasRenderer ClearTimeAlpha;
    public CanvasRenderer RankInTxtAlpha;
    public CanvasRenderer RankUpdateAlpha;
    public CanvasRenderer GameClearAlpha;
    public CanvasRenderer CommentsAlpha;
    public CanvasRenderer[] ResultCanvas = new CanvasRenderer[6];


    int Clicknum = 0;//クリック回数を測定
    //フェード関係
    public float waitTime;
    float counter = 0;
    bool isFO = false;
    bool isFI = false;
    bool isEnd = false;


    //キャンバス切替関係

    [SerializeField] Canvas resultcanvas;
    [SerializeField] Canvas NameEntryCanvas;
    [SerializeField] Text NextTxt;


    //エントリーネーム関連
    public tempNameEntry NameEntry;

    //音

    public AudioSource audioSource;
    public AudioClip enter;
    
    public AudioSource BGMAaudioscource;
    public AudioSource newrecordsouce;

    //コメント
    public Text A;
    public Text B;
    public Text C;
    public Text D;
    public Text[] CommentsText;
    // Start is called before the first frame update
    void Start()
    {
        isupdate = false;
        isntrankin = false;
        NextTxt.enabled = false;
        NumClear();
        ImageClear();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        int tempinttime = 0;
        string tempstringtime = "";
       TimeTemp  = GameSystem.timescore;//Gamemanagerのタイムスコアを持ってくる
        TimetointTemp = GameSystem.timetoint;//intに変換したタイムを持ってくる
        nowTimeScore = TimeTemp;//現在の記録を残す
        nowTimeintScore = TimetointTemp;//int型でも残す
        TimeScore.text = nowTimeScore;
        Todaynow = DateTime.Now;
        TodaynowString = Todaynow.Year.ToString() +"年" +Todaynow.Month.ToString() +"月" + Todaynow.Day.ToString() +"日" +Todaynow.Hour.ToString() +"時" + Todaynow.Minute.ToString() + "分"; 


        //保存したスコアを読み込む
        for (int o = 0; o < TimeboadName.Length; o++)//名前
        {

            TimeboadName[o]  = PlayerPrefs.GetString("BoadName" + o);
            Debug.Log(o + "番目を読み込み");

        }
        for (int p = 0; p < Timeboad.Length; p++)//タイム
        {
            Timeboad[p] = PlayerPrefs.GetString("BoadTime" + p);
            Debug.Log(p + "番目のタイムを読み込み");
        }
        for (int q = 0; q < TimeArray.Length; q++)//日時
        {
           TimeArraystring[q] = PlayerPrefs.GetString("BoadDayTime" + q);
            Debug.Log(q + "番目の日時を読み込み");
        }
        for (int r = 0; r < Timeboadtoint.Length; r++)//inttime
        {
            Timeboadtoint[r] = PlayerPrefs.GetInt("Boadint" + r);
            Debug.Log(r + "番目のintのタイムを読み込み");
        }
        
        if(Timeboadtoint[0] == 0)
        {
            for(int a=0;a< Timeboadtoint.Length; a++)
            {
                Timeboadtoint[a] = 999999;
                Debug.Log("int配列を初期化");
            }
        }
                
        A.enabled = false;
        B.enabled = false;
        C.enabled = false;
        D.enabled = false;
        CommentsText[0] = A;
        CommentsText[1] = B;
        CommentsText[2] = C;
        CommentsText[3] = D;
        //事前に設定したボーダーより小さければ配列番号をbordernumに吐く//クリアタイム判断処理
        for(int i=0; i <= timeBorder.Length; i++)
        {
            if (timeBorder[i] > TimetointTemp)
            {
                bordernum = i;
                Debug.Log(i + "番目のボーダーをクリア");
                break;

            }else if (timeBorder[3] < TimetointTemp)//ランクがDより多い場合
            {
                bordernum = 3;
                Debug.Log("強制的にランクがDになりました");
                break;
            }
        }
     
        //順位並べ替え

        for(int j=0; j < Timeboadtoint.Length; j++)
        {
            if(Timeboadtoint[j] >= TimetointTemp)
            {
                Debug.Log(j + "番目より速い");
                tempinttime = Timeboadtoint[j];//int型の前のデータを一時的に入れる
                tempstringtime = Timeboad[j];//string型**
                TimeboadtmpName = TimeboadName[j];//すでに入っている名前をtempで*名前*
                //時間
                tempTimestring = TimeArraystring[j];


                Timeboadtoint[j] = TimetointTemp;//int型のクリアタイムを配列の中に入れる
                Timeboad[j] = TimeTemp;//string型**
                TimeboadName[j] = Playernames;//nowPlayerを現在のプレイヤーネームとして仮に入れる(あとで入力した値を入れる)
                //時間
                TimeArraystring[j] = TodaynowString;

                TimeTemp = tempstringtime;//string型の前のデータを現在のクリアタイムの中に入れ次のループで比較する
                TimetointTemp = tempinttime;//int型**
                Playernames = TimeboadtmpName;//入れ替えたプレイヤーネームを次入れ替えするプレイヤーネームに入れる
               
                TodaynowString = tempTimestring;
                Debug.Log(j + "番目の配列が入れ替わりました");

            }
        }
        
        //順位を判定する

        for(int k = 0; k < Timeboadtoint.Length; k++)
        {
            if(Timeboadtoint[k] == nowTimeintScore)
            {
                if (Timeboadtoint[1] >nowTimeintScore)
                {
                    isupdate = true;//記録更新をtrue
                }
                ranknum = k;
                Debug.Log(k + "番目の順位にランクイン");
                break;
            
            }else if(Timeboadtoint[9] < nowTimeintScore)//最後より大きければ
            {
                isntrankin = true;//ランキングをfalse
                break;
            }
        }




        //それぞれのRendererを配列に入れる
        ResultCanvas[0] = GameClearAlpha;
        ResultCanvas[1] = RankAlpha;
        ResultCanvas[2] = RankAlphaNum[bordernum];//ランクのCanvasRendererを入れる
        ResultCanvas[3] = ClearTimeAlpha;
        ResultCanvas[4] = TimeScoreAlpha;
        ResultCanvas[5] = CommentsAlpha;

        FadeManager.FadeIn();
        BGMAaudioscource.Play();

        isFO = true;
        Clicknum = 0;
    }

    void NumClear()
    {
        foreach(CanvasRenderer tmpNum in RankAlphaNum)
        {
            tmpNum.SetAlpha(0);
        }
        foreach(CanvasRenderer tempRankNum in RankNumber)
        {
            tempRankNum.SetAlpha(0);
        }
    }
    void ImageClear()
    {
        //ゲームクリアの文字以外を透明に
        GameClearAlpha.SetAlpha(0);
        TimeScoreAlpha.SetAlpha(0);
        RankAlpha.SetAlpha(0);
        ClearTimeAlpha.SetAlpha(0);
        RankInTxtAlpha.SetAlpha(0);
        RankUpdateAlpha.SetAlpha(0);
        CommentsAlpha.SetAlpha(0);

    }
    // Update is called once per frame
    void Update()
    {
        fadein();

        if (isFI && isEnd == false)
        {
            Clicknum += 1;
           
            isFI = false;
            isFO = true;
            if(Clicknum == 6)
            {
                CommentsText[bordernum].enabled = true;
                
                if (isntrankin == false)
                {
                    RankInTxtAlpha.SetAlpha(1);
                    RankNumber[ranknum].SetAlpha(1);
                    
                }
                if (isupdate ==true)
                {
                    
                    RankUpdateAlpha.SetAlpha(1);
                    newrecordsouce.Play();
                }
                NextTxt.enabled = true;
                isEnd = true;
            }
        }
        if (isEnd)
        {

            if (isntrankin ==false &&Input.GetMouseButtonDown(0))
            {
                audioSource.PlayOneShot(enter);
                resultcanvas.enabled=false;
                NameEntryCanvas.enabled=true;

            }
            else if(isntrankin ==true)
            {
                FadeManager.FadeOut(0);
            }
        }

        
       
    }
    void fadein()
    {
        if (isFO && isFI == false && isEnd == false)
        { 
            counter += Time.deltaTime;
            // Debug.Log(counter);
            ResultCanvas[Clicknum].SetAlpha(counter / waitTime);
            

        }
        if(counter > waitTime)
        {
            ResultCanvas[0].SetAlpha(0);
            counter = 0;
            isFI = true;
        }
    }

    public void OnEntyName()
    {
        audioSource.PlayOneShot(enter);

        NameEntry.nowplayername = NameEntry.inputfield.text;
        Debug.Log("YourNameis" + NameEntry.nowplayername);
        for(int f=0; f <= TimeboadName.Length; f++)
        {
            if (TimeboadName[f] == "nowPlayer")
            {
                TimeboadName[f] = NameEntry.nowplayername;
                Debug.Log("名前を配列に入れたよ");
                break;
            }
                 


        }
        for (int g = 0; g < TimeboadName.Length; g++) {

            PlayerPrefs.SetString("BoadName" + g, TimeboadName[g]);
            Debug.Log(g + "番目に保存");

         }
        for(int h = 0; h < Timeboad.Length; h++)
        {
            PlayerPrefs.SetString("BoadTime" + h, Timeboad[h]);
            Debug.Log(h + "番目にタイムを保存");
        }
        for(int n = 0; n < TimeArraystring.Length; n++)
        {
            PlayerPrefs.SetString("BoadDayTime" + n, TimeArraystring[n]);
            Debug.Log(n + "番目に日時を保存");
        }
        for(int m =0; m<Timeboadtoint.Length; m++)
        {
            PlayerPrefs.SetInt("Boadint" + m , Timeboadtoint[m]);
            Debug.Log(m+"番目にintのタイムを保存");
        }

        FadeManager.FadeOut(0);
    }




}
