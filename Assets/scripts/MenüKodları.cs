using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenüKodları : MonoBehaviour
{
    [SerializeField]
    private GameObject menüpaneli;

    
    private float genişlik = 0.3f;
    
    private float tekrarlama = 1.8f;

    void Start()
    {
        Time.timeScale = 1;
        menüpaneli.GetComponent<RectTransform>().localScale = Vector3.zero;
        menüpaneli.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBounce);
        menüpaneli.GetComponent<CanvasGroup>().DOFade(1, 1f);


    }

    private void Update()
    {
       

        float x = transform.position.x;
        float y = Mathf.Sin(Time.time*tekrarlama) * genişlik;
        float z = transform.position.z;
        transform.position = new Vector3(x,y,z);

    }

    public void oyunageç()
    {
        SceneManager.LoadScene("2.game");
    }


    public void nasıloynanır()
    {
        
    }

    public void çıkış()
    {
        Application.Quit();
    }
  
}
