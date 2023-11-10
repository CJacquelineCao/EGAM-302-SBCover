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

    public GameObject overlapdetection;
    public void OnDrop(PointerEventData eventData)
    {
        eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
        if (eventData.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
        {
            ComboStickers.Add(eventData.pointerDrag.gameObject);
            eventData.pointerDrag.GetComponent<DragAndDrop>().Addded = true;

        }
        foreach (GameObject sticker in ComboStickers)
        {
            foreach (Transform child in sticker.gameObject.transform)
            {
                GameObject Image = child.transform.GetChild(0).gameObject;

                overlapdetection.GetComponent<CheckOverlap>().ChangeColor(Image, Color.white);



            }
        }
        overlapdetection.GetComponent<CheckOverlap>().checkOverlaps();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Savestickers();
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
    public void setStickersInactive()
    {
        for (int i = 0; i < ComboStickers.Count; i++)
        {
            if(ComboStickers[i] !=null)
            {
                ComboStickers[i].SetActive(false);
            }
        }
    }

    public void setStickersActive()
    {
        for (int i = 0; i < ComboStickers.Count; i++)
        {
            if (ComboStickers[i] != null)
            {
                ComboStickers[i].SetActive(true);
            }
        }
    }
}
