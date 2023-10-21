using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StickerMenu : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
      if(eventData.pointerDrag !=null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
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
