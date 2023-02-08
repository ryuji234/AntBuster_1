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
    public string Name;
    private bool IsUpgrade = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Select1()
    {
        Name = "Heavy Cannon";
        control = Cannon.GetComponent<BasicCannonControl>();
        control.Name = Name;
        WhatCannon();
    }
    public void Select2()
    {
        Name = "Quick Cannon";
        control = Cannon.GetComponent<BasicCannonControl>();
        control.Name = Name;
        WhatCannon();
    }
    public void Select3()
    {
        Name = "Double Cannon";
        control = Cannon.GetComponent<BasicCannonControl>();
        control.Name = Name;
        WhatCannon();
    }
    public void Select4()
    {
        gameObject.SetActive(false);
        Debug.Log(Cannon.transform.position);
        WhatCannon();
    }
    public void Select5()
    {
        control = Cannon.GetComponent<BasicCannonControl>();
        if (Name != "Cannon")
        {
            Name = "Cannon";
            control.Name = Name;
            IsUpgrade = false;
            WhatCannon();
        }
        else
        {
            control.DestroyCannon();
            gameObject.SetActive(false);
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
