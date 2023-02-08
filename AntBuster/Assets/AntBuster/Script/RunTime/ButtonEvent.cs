using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEvent : MonoBehaviour
{
    GameManager gameManager;
    UIControl UI;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        UI = FindObjectOfType<UIControl>();

    }
    public void Select1()
    {
        UI.Select1();
    }
    public void Select2()
    {
        UI.Select2();
    }
    public void Select3() 
    {
        UI.Select3();
    }
    public void Select4()
    {
        UI.Select4();
    }
    public void Select5()
    {
        UI.Select5();
    }
}
