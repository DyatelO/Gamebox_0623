using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    Sword,
    Shield,
}

public class Merge2test : MonoBehaviour, IPointerDownHandler, IDropHandler
{
    public ItemType itemType;
    //public delegate void ClickBySlotEvent(GameObject gameobjectByClicked);

    public ClickController clickColider = null;

    //public delegate void PickUpItem(GameObject itemObject);

    //public event PickUpItem pickUpItemAction;

    private void Awake()
    {
        clickColider = FindObjectOfType<ClickController>();
    }

    public void PickUp()
    {
        //slot1 = this.gameObject;
        //pickUpItemAction?.Invoke(slot1);

        clickColider.clickedObjects.Add (this.gameObject);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PickUp();
        Debug.Log(gameObject.name);
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {


        var droppedItemTransform = eventData.pointerDrag.transform;
        droppedItemTransform.SetParent(transform);
        droppedItemTransform.localPosition = Vector2.zero;
    }
}
