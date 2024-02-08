

using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;



public class DamlaManager : MonoBehaviour
{
    [SerializeField]
    private Text sorutext;

    TuşManager tuşmanager;
    
    public int doğrucevap;

    GameManager gameManager;

    public GameObject damlaprefab;

    public float damlahızı;
    

    private void Awake()
    {
        tuşmanager = Object.FindObjectOfType<TuşManager>();
        gameManager = Object.FindObjectOfType<GameManager>();
        

    }
    void Start()
    {


    }

    
    void Update()
    {
        damlahızı += 0.00002f;
        transform.Translate(Vector3.down * Time.deltaTime * damlahızı);
    }


    public void rastgelesoruseç()
    {
        int rastgele = Random.Range(1, 6);

        if (rastgele == 2)
        {
            toplamaÇıkarma();
 
            

        }
        else if (rastgele == 3)
        {
            toplamaÇıkarma();

        }
        else if (rastgele == 4)
        {
            toplamaÇıkarma();
          


        }
        else if (rastgele == 5)
        {
            bölme();

        }
        else
        {
            çarpma();
        }


    }


    public void toplamaÇıkarma()
    {
        int birincisayı = Random.Range(20, 40);
        int ikincisayı = Random.Range(5, 25);
        int üçüncüsayı = Random.Range(5, 20);
        int rastgele = Random.Range(1, 10);

        if (rastgele <= 5)
        {
            sorutext.text = ikincisayı.ToString() + "+" + üçüncüsayı.ToString();
            doğrucevap = ikincisayı + üçüncüsayı;

            
        }
        else if (rastgele > 5)
        {
            sorutext.text = birincisayı.ToString() + "-" + üçüncüsayı.ToString();
            doğrucevap = birincisayı - üçüncüsayı;
        }
        
    }


    public void çarpma()
    {
        int birincisayı = Random.Range(5, 10);
        int ikincisayı = Random.Range(1, 15);

        sorutext.text = birincisayı.ToString() + "X" + ikincisayı.ToString();
        doğrucevap = birincisayı * ikincisayı;
        

    }

    public void bölme()
    {

        int ikincisayı = Random.Range(1, 15);
        doğrucevap = Random.Range(1, 12);
        int birinicsayı = doğrucevap * ikincisayı;

        sorutext.text = birinicsayı.ToString() + "/" + ikincisayı.ToString();

    }


    
















}
