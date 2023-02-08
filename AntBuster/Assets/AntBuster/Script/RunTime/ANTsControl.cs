using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANTsControl : MonoBehaviour
{
    public GameObject ant1;
    public GameObject ant2;
    public GameObject ant3;
    public GameObject ant4;
    public GameObject ant5;
    public GameObject ant6;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Ant1",0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Ant1()
    {
        ant1.SetActive(true);
        CancelInvoke();
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
