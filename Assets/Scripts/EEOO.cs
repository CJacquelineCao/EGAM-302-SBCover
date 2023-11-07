using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EEOO : MonoBehaviour, IDropHandler
{
    public List<GameObject> ComboStickers = new List<GameObject>();
    public Button savebutton;
    public bool canbeSaved;
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
        if (eventData.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
        {
            ComboStickers.Add(eventData.pointerDrag.gameObject);
            eventData.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Savestickers();
        if (canbeSaved == true)
        {
            savebutton.interactable = true;
        }
        else
        {
            savebutton.interactable = false;
        }
    }
    void Savestickers()
    {
        for (int i = 0; i < ComboStickers.Count; i++)
        {
            if (ComboStickers[i].GetComponent<DragAndDrop>().Valid == true)
            {
                canbeSaved = true;
            }
            else
            {
                canbeSaved = false;
            }
        }
    }
}
