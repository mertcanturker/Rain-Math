using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.CodeDom.Compiler;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    public GameObject üstpanel;
    [SerializeField]
    private GameObject bir, iki, üç;

    public int süre1;
    bool süresaysınmı;



    bool ispaused = false;
    public Text süretext;

    [SerializeField]
    public Transform[] damlaçıkışyerleri;

    [SerializeField]

    public GameObject damlaprefab;

    [SerializeField]
    public Text puantext;

    [SerializeField]
    public GameObject pausepaneli;

    [SerializeField]
    public GameObject buton1, buton2, buton3, buton4;


    [SerializeField]
    private Button pausebtn1, pausebtn2;

    [SerializeField]
    private GameObject tuşpaneli;

    [SerializeField]
    public GameObject resultpaneli, resultımage,homebtn,restartbtn;

    [SerializeField]
    public Text resulttext;


    public int a = 0;

    public int puanartışı;

    public bool puanartsınmı = true;


    public Button buton;

    public GameObject[] damla1;


    public int süre;


    float hız = 4.3f;


    SüreManage süremanager;
    TuşManager tuşmanager;

    DamlaManager damlamanager;

    Timer time;

    public int[] doğrucevaplar;

    public int puan;


    private void Awake()
    {

        süremanager = Object.FindObjectOfType<SüreManage>();
        tuşmanager = Object.FindObjectOfType<TuşManager>();
        damlamanager = Object.FindObjectOfType<DamlaManager>();
        time = Object.FindObjectOfType<Timer>();
    }



    void Start()
    {
        Time.timeScale = 1;
        süre = 90;
        süresaysınmı = true;
        üstpanel.GetComponent<RectTransform>().localScale = Vector3.zero;      
        üstpanel.SetActive(true);     
        üstpanel.GetComponent<CanvasGroup>().DOFade(1, 0.9f);
        üstpanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(gerisay());


    }


    IEnumerator gerisay()
    {
        bir.GetComponent<RectTransform>().localScale = Vector3.zero;
        iki.GetComponent<RectTransform>().localScale = Vector3.zero;
        üç.GetComponent<RectTransform>().localScale = Vector3.zero;

        üç.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        üç.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        üç.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(0.5f);

        iki.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        iki.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        yield return new WaitForSeconds(0.5f);
        iki.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);


        yield return new WaitForSeconds(0.5f);

        bir.GetComponent<RectTransform>().DOScale(1.3f, 0.5f);
        bir.GetComponent<CanvasGroup>().DOFade(1, 0.5f);

        yield return new WaitForSeconds(0.5f);
        bir.GetComponent<RectTransform>().DOScale(0f, 0.5f).SetEase(Ease.InBack);

        yield return new WaitForSeconds(0.5f);

        

        
        tuşmanager.tuşlarıgöster();
        StartCoroutine(YağmurYağ());
        StartCoroutine(süreyigerisaydır());
    }

    IEnumerator YağmurYağ()
    {
        while (a < 90)
        {

            
            Transform damlaçıkışyeri = damlaçıkışyerleri[Random.Range(0, damlaçıkışyerleri.Length)];
            rastgelesoruseç();
            doğrucevaplar[a] = damlamanager.doğrucevap;
            damla1[a] = Instantiate(damlaprefab, damlaçıkışyeri.position, damlaçıkışyeri.rotation) as GameObject;
            yield return new WaitForSeconds(hız);
            hız -= 0.08f;
            a++;

        }


    }


    void rastgelesoruseç()
    {
        int rastgele = Random.Range(1, 5);

        if (rastgele == 1)
        {
            damlamanager.toplamaÇıkarma();


        }
        else if (rastgele == 2)
        {
            damlamanager.toplamaÇıkarma();


        }
        else if (rastgele == 3)
        {
            damlamanager.çarpma();


        }
        else if (rastgele == 4)
        {
            damlamanager.bölme();

        }
    }


    public void damlayıyoket()
    {
        for (int a = 0; a < doğrucevaplar.Length; a++)
        {
            if (GameObject.Find("Cevaptexti").GetComponent<Text>().text.ToString() == doğrucevaplar[a].ToString())
            {
              
                if (damla1[a]!= null)
                {
                    Destroy(damla1[a]);
                    doğrucevaplar[a]=0;
                    puan += 20;
                    puantext.text=puan.ToString();
                    GameObject.Find("Cevaptexti").GetComponent<Text>().text = "";



                }
                else
                {
                    
                }
    
            }
            else
            {
                
                continue;
            }
            
        }

        

    }



    void enterabastır()
    {
        buton.GetComponent<Button>().onClick.AddListener(() => damlayıyoket());
    }


    public void pausentnaçık()
    {
       
        pausebtn2.GetComponent<RectTransform>().localScale = Vector3.zero;
        


    }

    public void pausekapalı()
    {
        pausebtn2.GetComponent<RectTransform>().localScale = Vector3.one;

    }

    public void pausepaneliaç()
    {

        tuşpaneli.SetActive(false);
        pausepaneli.SetActive(true);
        StartCoroutine(Paneligetir());
       
               




    }
    public void pausepanelikapat()
    {
        pausepaneli.SetActive(false);
        pausepaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        pausebtn2.GetComponent<RectTransform>().localScale = Vector3.one;
        tuşpaneli.SetActive(true);
        

    }

    public void RestartButonu()
    {
        SceneManager.LoadScene("2.game");
    }


    public void AnaMenüButon()
    {
        Application.LoadLevel("MenüSahnesi");
    }

    IEnumerator Paneligetir()
    {
        pausepaneli.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        pausegame();
    }


    public void sürebitti()
    {
        StopAllCoroutines();
        tuşpaneli.SetActive(false);
        üstpanel.SetActive(false);

        for(int c = 0; c < damla1.Length; c++)
        {
            if (damla1[c] != null)
            {
                damla1[c].SetActive(false);
            }
        }

        StartCoroutine(ResultPaneligetir());




    }

    IEnumerator ResultPaneligetir()
    {
        yield return new WaitForSeconds(0.5f);
        resultımage.GetComponent<RectTransform>().localScale = Vector3.zero;
        homebtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        restartbtn.GetComponent<RectTransform>().localScale = Vector3.zero;
        resultpaneli.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        resultımage.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(0.5f);
        homebtn.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        restartbtn.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        StartCoroutine(PuanıRitmikArttır());


    }

    IEnumerator PuanıRitmikArttır()
    {
        while(puanartsınmı)
        {
            if (puanartışı < puan)
            {
                puanartışı += 10;
                resulttext.text = puanartışı.ToString();
                yield return new WaitForSeconds(0.03f);
            }
            else puanartsınmı = false;
        }
    }

    IEnumerator süreyigerisaydır()
    {
        while (süresaysınmı)
        {
            yield return new WaitForSeconds(1f);
            süre--;
            süretext.text = süre.ToString();

            if (süre < 10)
            {
                süretext.text = "0" + süre.ToString();
            }

            if (süre <= 0)
            {
                süresaysınmı = false;
                süretext.text = "0";
                sürebitti();
                break;
            }
        }
    }

    public void pausegame()
    {



        if (ispaused)
        {

            Time.timeScale = 1;
            ispaused = false;
        }
        else
        {
            Time.timeScale = 0;
            ispaused = false;
        }
    }
    public void continuetheGame()
    {
        Time.timeScale = 1;
    }





}
   
   



































