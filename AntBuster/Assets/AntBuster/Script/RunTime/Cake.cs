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
    private int Count = 0;
    void Start()
    {
        cake = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        cake.sprite= Cake_img[Count];
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("���̰� ����ũ�� ��������.");
        if (Count >= 8) { }
        else
        {
            if(other.tag == "ANT")
            {
                Count++;
                Debug.Log("���̰� ����ũ�� ��������.");
            }
        }
    }

}
