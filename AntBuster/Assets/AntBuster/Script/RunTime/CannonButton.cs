using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CannonButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IDragHandler
{
    public Canvas canvas;
    BasicCannonControl Cannon;
    Image CannonImage;
    public GameObject cannonpoolobj;
    CannonPool cannonpool;
    private bool IsClick = false;
    
    private bool MakeCannon = false;
    private float PosX;
    private float PosY;
    // Start is called before the first frame update
    void Start()
    {
        cannonpool = cannonpoolobj.GetComponent<CannonPool>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {

        IsClick = true;
        MakeCannon = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        IsClick = false;
        Cannon.Activate = true;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (IsClick)
        {
             
            if (MakeCannon)
            {
                Cannon = cannonpool.GetObject();
                Debug.Log(Cannon.name);
                PosX = Input.mousePosition.x;
                PosY = Input.mousePosition.y;
                MakeCannon = false;
            }
            Vector2 mousePosition = new Vector2(transform.position.x + (Input.mousePosition.x - PosX)/130, transform.position.y + (Input.mousePosition.y-PosY)/130);
            Cannon.transform.position = mousePosition;

        }
    }
}
