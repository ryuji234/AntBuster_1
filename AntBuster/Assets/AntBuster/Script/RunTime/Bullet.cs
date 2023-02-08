using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    private const int DAMAGE = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime*5);
        Invoke("DestroyBullet", 0.5f);
    }
    private Vector3 direction;
   

    public void DestroyBullet()
    {
        BulletPool.ReturnObject(this);
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "ANT")
        {
            Ant ant= other.GetComponent<Ant>();
            ant.hit(DAMAGE);
            Invoke("DestroyBullet",0);
        }
    }
}
