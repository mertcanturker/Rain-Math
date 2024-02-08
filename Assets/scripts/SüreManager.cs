using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SüreManager : MonoBehaviour
{
    public int süre;
    bool süresaysınmı;
    

    
    public Text süretext;
    GameManager game;


    private void Awake()
    {
        game = GameManager.FindObjectOfType<GameManager>();
    }
    void Start()
    {
        süre = 90;
        süresaysınmı = true;
       
    }

    public void süreyibaşlat()
    {
        StartCoroutine(süreyigerisaydır());
    }
   
    IEnumerator süreyigerisaydır()
    {
        while(süresaysınmı)
        {
            yield return new WaitForSeconds(1f);
            süre--;
            süretext.text = süre.ToString();

            if (süre < 10)
            {
                süretext.text = "0"+süre.ToString();
            }

            if (süre <= 0)
            {
                süresaysınmı = false;
                süretext.text = "0";
                //game.sürebitti();
                break;
            }
        }
    }
}
