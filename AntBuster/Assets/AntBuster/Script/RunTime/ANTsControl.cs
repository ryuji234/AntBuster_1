using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANTsControl : MonoBehaviour
{
    public GameObject Counter;
    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;
    public GameObject ant4;
    public GameObject ant5;
    public GameObject ant6;

    private float Time = 9;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        Counter.SetTextMeshPro($"{Time}");
        if(Time == 0)
        {
            Counter.SetActive(false);
            Ant1();
        }
        else
        {
            Invoke("CountDown",1);
        }
    }
    private void CountDown()
    {
        Time--;
        CancelInvoke();
    }
    private void Ant1()
    {
        ant1.SetActive(true);
        Invoke("Ant2", 2);
    }
    private void Ant2()
    {
        ant2.SetActive(true);
        CancelInvoke();
        Invoke("Ant3", 2);
    }
    private void Ant3()
    {
        ant3.SetActive(true);
        CancelInvoke();
        Invoke("Ant4", 2);
    }
    private void Ant4()
    {
        ant4.SetActive(true);
        CancelInvoke();
        Invoke("Ant5", 2);
    }
    private void Ant5()
    {
        ant5.SetActive(true);
        CancelInvoke();
        Invoke("Ant6", 2);
    }
    private void Ant6()
    {
        ant6.SetActive(true);
        CancelInvoke();
        
    }

}
