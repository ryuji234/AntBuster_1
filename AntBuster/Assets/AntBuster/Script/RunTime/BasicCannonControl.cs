using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BasicCannonControl : MonoBehaviour, IPointerClickHandler
{
    public List<Ant> FoundObjects;
    public Ant enemy;
    public float shortDis;
    public bool Activate = false;
    public string Name = "Cannon";
    public Sprite[] Cannonsprites;
    public Sprite[] Legsprites;

    Image Leg;

    private Image CannonImg;
    private Ant ant;
    private Collider2D BasicCannon;
    UIControl UI;
    GameManager gameManager;
    private const int ROTATESPEED = 100;
    private bool IsFire = false;
    private bool FirstShoot = true;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        Leg = GetComponent<Image>();
        BasicCannon = gameObject.GetComponentMust<Collider2D>("Cannon");
        CannonImg = gameObject.GetComponentMust<Image>("Cannon");
    }


    // Update is called once per frame
    void Update()
    {
        if (Activate)
        {
            FoundObjects = FindObjectsOfType<Ant>().ToList();
            //new List<Ant>(Ant);

            shortDis = Vector3.Distance(BasicCannon.transform.position, FoundObjects[0].transform.position); // 첫번째를 기준으로 잡아주기 

            enemy = FoundObjects[0]; // 첫번째를 먼저 

            foreach (Ant found in FoundObjects)
            {
                if (found.tag == "ANT")
                {
                    float Distance = Vector3.Distance(BasicCannon.transform.position, found.transform.position);

                    if (Distance < shortDis) // 위에서 잡은 기준으로 거리 재기
                    {
                        enemy = found;
                        shortDis = Distance;
                    }
                }

            }

            if (IsFire)
            {

                if (FirstShoot)
                {

                    Invoke("Shoot", 0);
                }
                else
                {
                    Invoke("Shoot", 1);

                }
                FirstShoot = false;
            }
        }
        switch (Name)
        {
            case "Cannon":
                Leg.sprite = Legsprites[0];
                CannonImg.sprite = Cannonsprites[0];
                break;
            case "Heavy Cannon":
                Leg.sprite = Legsprites[1];
                CannonImg.sprite = Cannonsprites[1];
                break;
            case "Quick Cannon":
                Leg.sprite = Legsprites[2];
                CannonImg.sprite = Cannonsprites[2];
                break;
            case "Double Cannon":
                Leg.sprite = Legsprites[3];
                CannonImg.sprite = Cannonsprites[3];
                break;
        }


    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Activate)
        {
            if (other.tag == "ANT")
            {
                ant = enemy.GetComponent<Ant>();
                Vector2 direction = new Vector2(transform.position.x - ant.transform.position.x, transform.position.y - ant.transform.position.y);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, ROTATESPEED * Time.deltaTime);
                BasicCannon.transform.rotation = rotation;
                IsFire = true;
            }
            if (other.tag == "Dead")
            {
                IsFire = false;
                CancelInvoke();
            }
        }



    }
    private void OnTriggerExit2D(Collider2D other)
    {
        IsFire = false;
        FirstShoot = true;
        CancelInvoke();
    }
    private void Shoot()
    {
        var bullet = BulletPool.GetObject(); // 수정
        bullet.transform.position = transform.position;
        bullet.transform.rotation = BasicCannon.transform.rotation;
        CancelInvoke();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        gameManager.ShowUI(Name);
        UI = FindObjectOfType<UIControl>();
        UI.Cannon = this.gameObject;
        UI.WhatCannon();
    }
    public void DestroyCannon()
    {
        CannonPool.ReturnObject(this);
    }


}
