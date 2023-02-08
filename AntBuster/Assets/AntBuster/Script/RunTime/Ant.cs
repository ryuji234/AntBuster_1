using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ant : MonoBehaviour
{
    private Image guageFront = default;
    private float level = 1;
    private int HP;
    private int MAXHP;
    private int RandomMove;
    private bool TakeCake = false;
    private bool IsAlive = true;
    private float dirX;
    private float dirY;
    private const int ROTATESPEED = 100;
    private Vector2 Cake = new Vector2(5.75f, -2.34f);
    private Vector2 Hole = new Vector2(-259.8f, 154.2f);


    public float guageAmount = default;
    public Image cakeImage;
    // Start is called before the first frame update
    void Start()
    {
        guageFront = gameObject.GetComponentMust<Image>("HP_Front");
        MAXHP = (int)(4 * Mathf.Pow(1.1f, level) - 1);
        HP = MAXHP;
    }

    // Update is called once per frame
    void Update()
    {
        guageAmount = HP / (float)MAXHP;
        guageFront.fillAmount = guageAmount;
        Vector3 Velvo = Vector3.zero;
        if(IsAlive)
        {
            if (!TakeCake)
            {
                if (RandomMove > 40)
                {
                    transform.position = Vector2.MoveTowards(transform.position, Cake, 0.004f);
                    Vector2 direction = new Vector2(transform.position.x - Cake.x, transform.position.y - Cake.y);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
                    Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, ROTATESPEED * Time.deltaTime);
                    transform.rotation = rotation;
                    Invoke("RandomMoving", 0.5f);
                }
                else
                {
                    Vector2 direction = new Vector2(transform.position.x - dirX, transform.position.y - dirY);
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
                    Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, ROTATESPEED * Time.deltaTime);
                    transform.rotation = rotation;
                    transform.position = Vector2.MoveTowards(transform.position, new Vector2(dirX, dirY), 0.004f);
                    Invoke("RandomMoving", 0.1f);
                }
            }
            else
            {
                Vector2 direction = new Vector2(transform.position.x - Hole.x, transform.position.y - Hole.y);
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion angleAxis = Quaternion.AngleAxis(angle - 270f, Vector3.forward);
                Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, ROTATESPEED * Time.deltaTime);
                transform.rotation = rotation;
                transform.position = Vector2.MoveTowards(transform.position, Hole, 0.003f);
            }
        }
        else
        {
            gameObject.tag = "Dead";
            Invoke("ReVive", 2);
        }
        
    }

    public void hit(int hitdamage)
    {
        HP -= hitdamage;

        if (HP <= 0)
        {
            IsAlive = false;
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.AddScore((int)level);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cake")
        {
            TakeCake = true;
        }
        if (other.tag == "Hole")
        {
            TakeCake = false;
        }
    }
    private void RandomMoving()
    {
        RandomMove = Random.Range(0,100);
        dirX = Random.Range(transform.localPosition.x - 100f, transform.localPosition.x + 100f);
        dirY = Random.Range(transform.localPosition.y - 100f, transform.localPosition.y + 100f);
        
        CancelInvoke();
    }
    public void ReVive()
    {
        gameObject.tag = "ANT";
        transform.localPosition = new Vector2(-259.8f, 154.2f);
        level++;
        MAXHP = (int)(4 * Mathf.Pow(1.1f, level) - 1);
        HP = MAXHP;
        TakeCake = false;
        IsAlive = true;
        CancelInvoke();
    }
}
