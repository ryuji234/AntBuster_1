using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    public GameObject Cannon;
    public BasicCannonControl control;
    public GameObject textName;
    public GameObject select1;
    public GameObject select2;
    public GameObject select3;

    GameManager gameManager;
    public string Name;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager =FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select1()
    {
        if (gameManager.moneyint >= 50)
        {
            gameManager.moneyint -= 50;
            Name = "Heavy Cannon";
            control = Cannon.GetComponent<BasicCannonControl>();
            control.Name = Name;
            WhatCannon();
        }
        
    }
    public void Select2()
    {
        if (gameManager.moneyint >= 50)
        {
            gameManager.moneyint -= 50;
            Name = "Quick Cannon";
            control = Cannon.GetComponent<BasicCannonControl>();
            control.Name = Name;
            WhatCannon();
        }
            
    }
    public void Select3()
    {
        if(gameManager.moneyint >=50)
        {
            gameManager.moneyint -= 50;
            Name = "Double Cannon";
            control = Cannon.GetComponent<BasicCannonControl>();
            control.Name = Name;
            WhatCannon();
        }
        
    }
    public void Select4()
    {
        gameObject.SetActive(false);
        WhatCannon();
    }
    public void Select5()
    {
        control = Cannon.GetComponent<BasicCannonControl>();
        if (Name != "Cannon")
        {
            Name = "Cannon";
            control.Name = Name;
            gameManager.moneyint += 50;
            WhatCannon();
        }
        else
        {
            control.DestroyCannon();
            gameObject.SetActive(false);
            gameManager.moneyint += 50;
        }
        
    }
    public void WhatCannon()
    {
        textName.SetTextMeshPro($"{Name}");
        switch (Name)
        {
            case "Cannon":
                select1.SetActive(true);
                select2.SetActive(true);
                select3.SetActive(true);
                break;
            case "Heavy Cannon":
                select1.SetActive(false);
                select2.SetActive(false);
                select3.SetActive(false);
                break;
            case "Quick Cannon":
                select1.SetActive(false);
                select2.SetActive(false);
                select3.SetActive(false);
                break;
            case "Double Cannon":
                select1.SetActive(false);
                select2.SetActive(false);
                select3.SetActive(false);
                break;
        }
    }
}
