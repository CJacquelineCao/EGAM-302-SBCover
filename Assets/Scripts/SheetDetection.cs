using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SheetDetection : MonoBehaviour, IDropHandler
{
    public List<GameObject> allStickers = new List<GameObject>();
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
            {
                allStickers.Add(eventData.pointerDrag.gameObject);
                eventData.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
