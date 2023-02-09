using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject UI;
    public GameObject Point;
    public GameObject Money;
    public GameObject GameOver;
    
    public int moneyint = 150;

    private int point = 0;
    private int CakeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Point.SetTextMeshPro($"{point}");
        Money.SetTextMeshPro($"{moneyint}");
    }
    
    public void ShowUI(string Name)
    {
        UI.SetActive(true); 
        UIControl control = UI.GetComponent<UIControl>();
        control.Name = Name;
    }
    public void AddScore(int score)
    {
        point += score;
        moneyint += 10;
    }

    public void LooseCake()
    {
        CakeCount++;
        Debug.Log("케이크 사라짐");
        if(CakeCount >= 8)
        {
            
            GameOver.SetActive(true);

            Invoke("Title",3);
        }
    }
    public void Title() 
    {
        GF.LoadScence(GData.SCENE_NAME_TITLE);
    }
}
