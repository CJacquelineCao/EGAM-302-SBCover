using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditorMenu : MonoBehaviour, IDropHandler
{
    public List<GameObject> allStickers = new List<GameObject>();
    public RectTransform _transform;
    public bool canbeSaved;
    public Button savebutton;
    private Canvas _canvas;
    public GameObject createdStickerPrefab;

    public ComboMenu comboref;
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
        _transform = GetComponent<RectTransform>();
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        RemoveDeleted();
        Savestickers();
        if(canbeSaved == true)
        {
            savebutton.interactable = true;
        }
        else
        {
            savebutton.interactable = false;
        }
    }
    void RemoveDeleted()
    {
        for (int i = 0; i < allStickers.Count; i++)
        {
            if (allStickers[i].gameObject == null)
            {
                allStickers.RemoveAt(i);
            }
        }
        void getStickers()
        {

        }
    }

    void Savestickers()
    {
        for (int i = 0; i < allStickers.Count; i++)
        {
            if(allStickers[i].GetComponent<DragAndDrop>().Valid == true)
            {
                canbeSaved = true;
            }
            else
            {
                canbeSaved = false;
            }
        }
    }

    public void CreateStickerCombo()
    {
        GameObject Sticker = Instantiate(createdStickerPrefab, _transform.anchoredPosition, Quaternion.identity);
        Sticker.transform.SetParent(_canvas.transform, false);
        foreach (GameObject sticker in allStickers)
        {
            sticker.transform.SetParent(Sticker.transform, false);
            sticker.GetComponent<DragAndDrop>().enabled = false;
        }
        allStickers.Clear();
        canbeSaved = false;
        Sticker.SetActive(false);
        comboref.gameObject.SetActive(true);
        comboref.addToList(Sticker);
    }
}
