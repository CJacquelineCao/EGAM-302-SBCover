using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Border : MonoBehaviour, IDropHandler
{
    public EditorMenu editorref;

    public EEOO comboref;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 0.6f;
            if(editorref !=null && editorref.isActiveAndEnabled)
            {
                CheckforSticker(eventData);
            }
            else if(comboref !=null && comboref.isActiveAndEnabled)
            {
                CheckforCombos(eventData);
            }


        }
        // Start is called before the first frame update
    }

    void CheckforSticker(PointerEventData eventobject)
    {
        if(editorref.allStickers.Count == 0)
        {
            if (eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
            {
                editorref.allStickers.Add(eventobject.pointerDrag.gameObject);
                editorref.RefreshStickerOrder();
                eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
            }
        }
        else
        {
            for (int i = 0; i < editorref.allStickers.Count; i++)
            {
                if (editorref.allStickers[i].gameObject != eventobject.pointerDrag.gameObject || editorref.allStickers[i].gameObject == null)
                {
                    if (eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
                    {
                        editorref.allStickers.Add(eventobject.pointerDrag.gameObject);
                        editorref.RefreshStickerOrder();
                        eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
                    }
                }
            }
        }

    }

    void CheckforCombos(PointerEventData eventobject)
    {
        if (comboref.ComboStickers.Count == 0)
        {
            if (eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
            {
                comboref.ComboStickers.Add(eventobject.pointerDrag.gameObject);
                eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
            }
        }
        else
        {
            for (int i = 0; i < comboref.ComboStickers.Count; i++)
            {
                if (comboref.ComboStickers[i].gameObject != eventobject.pointerDrag.gameObject || comboref.ComboStickers[i].gameObject == null)
                {
                    if (eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
                    {
                        comboref.ComboStickers.Add(eventobject.pointerDrag.gameObject);
                        eventobject.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
                    }
                }
            }
        }
    }    
    void Start()
    {
        editorref = GameObject.FindObjectOfType<EditorMenu>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
