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

    private int point = 0;
    private int money = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Point.SetTextMeshPro($"{point}");
        Money.SetTextMeshPro($"{money}");
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
    }
}
