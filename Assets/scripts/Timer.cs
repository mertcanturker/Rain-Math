using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{



    GameManager gamemanager;

    bool ispaused = false;


    private void Awake()
    {
        gamemanager = Object.FindObjectOfType<GameManager>();
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

    

}
