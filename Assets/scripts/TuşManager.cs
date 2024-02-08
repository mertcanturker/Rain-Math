using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class TuşManager : MonoBehaviour
{
    [SerializeField]
    private GameObject tuşpaneli;


    
    public Text cevaptext;
   

    void Start()
    {

        
    }

    public void tuşlarıgöster()
    {
        tuşpaneli.GetComponent<RectTransform>().DOLocalMoveY(-570, 0.5f);
       
    }

    

    public void hangituş(string hangituş)
    {
        if (cevaptext == null)
        {
            cevaptext.text = hangituş.ToString();
           
            

        }
        else if (cevaptext != null)
        {
            cevaptext.text = cevaptext.GetComponent<Text>().text.ToString() + hangituş.ToString();
            


        }



    }

    public void textisil()
    {
        cevaptext.text = "";
    }




}
