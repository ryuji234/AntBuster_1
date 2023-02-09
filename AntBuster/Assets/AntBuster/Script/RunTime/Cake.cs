using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Cake : MonoBehaviour
{
    // Start is called before the first frame update
    public Sprite[] Cake_img;
    Image cake;
    public int Count = 0;
    void Start()
    {
        cake = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        cake.sprite= Cake_img[Count];
        if(Count < 8)
        {
            transform.localPosition = new Vector2(277.2f, -112.8f);
        }
        else
        {
            transform.localPosition = new Vector2(3000, -1200);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (Count == 8) 
        {
            
        }
        else
        {
            if(other.tag == "ANT")
            {
                Count++;
            }
        }
    }

}
