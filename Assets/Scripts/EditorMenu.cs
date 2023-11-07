using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EditorMenu : MonoBehaviour, IDropHandler, IPointerDownHandler
{
    public List<GameObject> allStickers = new List<GameObject>();
    public RectTransform _transform;
    public bool canbeSaved;
    public Button savebutton;
    private Canvas _canvas;
    public GameObject createdStickerPrefab;

    public ComboMenu comboref;
    public GameObject ModPanel;
    public GameObject Container;
    public List<int> allX = new List<int>();

    public float biggestInt;
    public float smallestInt;

    public float largestX;
    public float smallestX;


    public float largestY;
    public float smallestY;

    public Material bordermat;
    public float thickness;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().Addded == false)
            {
                allStickers.Add(eventData.pointerDrag.gameObject);
                RefreshStickerOrder();
                eventData.pointerDrag.GetComponent<DragAndDrop>().Addded = true;
            }

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _transform = GetComponent<RectTransform>();
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        test();
    }

    // Update is called once per frame
    void Update()
    {
        RemoveDeleted();
        Savestickers();
        bordermat.SetFloat("_OutlineThickness", thickness);
        if (canbeSaved == true)
        {
            savebutton.interactable = true;
        }
        else
        {
            savebutton.interactable = false;
        }

    }

    public void RefreshStickerOrder()
    {
        for (int i = 0; i < allStickers.Count; i++)
        {
            // set allStickers[i] 's sorting order to be i
            allStickers[i].GetComponent<Sticker>().SetStickerSortingOrder(i);
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
        GameObject StickerContainer = Instantiate(createdStickerPrefab, _transform.anchoredPosition, Quaternion.identity);
        StickerContainer.transform.SetParent(_canvas.transform, false);
        if (ModPanel.gameObject.activeSelf == true)
        {
            ModPanel.SetActive(false);
        }
        foreach (GameObject sticker in allStickers)
        {
            sticker.transform.SetParent(StickerContainer.transform, false);
            sticker.GetComponent<DragAndDrop>().enabled = false;
            sticker.GetComponent<Sticker>().inCombo = true;
        }
        GameObject originalSticker = Instantiate(StickerContainer, _transform.anchoredPosition, Quaternion.identity);
        originalSticker.SetActive(false);
        CheckDistance();
        setNewSize();
        FindCenter(StickerContainer);
        allStickers.Clear();
        canbeSaved = false;
        StickerContainer.SetActive(false);
        comboref.addToList(StickerContainer, originalSticker);
    }

    void FindCenter(GameObject stickerCont)
    {
        var totalX = 0f;
        var totalY = 0f;
        foreach (var sticker in allStickers)
        {
            totalX += sticker.transform.position.x;
            totalY += sticker.transform.position.y;
        }
        var centerX = totalX / allStickers.Count;
        var centerY = totalY / allStickers.Count;
        stickerCont.transform.localPosition = new Vector3(centerX, centerY, 0);
    }
    void CheckDistance()
    {
        largestX = allStickers[0].transform.position.x;
        smallestX = allStickers[0].transform.position.x;
        for (int i = 0; i < allStickers.Count; i++)
        {
            if(allStickers[i].transform.position.x > largestX)
            {
                largestX = allStickers[i].transform.position.x;
            }
            if(allStickers[i].transform.position.x < smallestX)
            {
                smallestX = allStickers[i].transform.position.x;
            }
        }
;
        largestY = allStickers[0].transform.position.y;
        smallestY = allStickers[0].transform.position.y;
        for (int i = 0; i < allStickers.Count; i++)
        {
            if (allStickers[i].transform.position.y > largestY)
            {
                largestY = allStickers[i].transform.position.y;
            }
            if (allStickers[i].transform.position.y < smallestY)
            {
                smallestY = allStickers[i].transform.position.y;
            }
        }
        setNewDistance();
    }


    void setNewDistance()
    {
        if (largestX - smallestX >= 1)
        {
            foreach (GameObject sticker in allStickers)
            {
                float posX = sticker.GetComponent<Transform>().position.x;
                posX = sticker.transform.position.x / 10;
                sticker.GetComponent<Transform>().position = new Vector3(posX, sticker.transform.position.y, sticker.transform.position.z);
            }
        }
        if(largestY - smallestY >=1)
        {
            foreach (GameObject sticker in allStickers)
            {
                float posY = sticker.GetComponent<Transform>().position.y;
                posY = sticker.transform.position.y / 10;
                sticker.GetComponent<Transform>().position = new Vector3(sticker.transform.position.x, posY, sticker.transform.position.z);
            }
        }
    }
    void setNewSize()
    {
        foreach (GameObject sticker in allStickers)
        {
            sticker.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        }
    }

    public void changeBorderSize()
    {
        if(thickness <5)
        {
            thickness += 1;
        }

    }

    public void makeBorderSmall()
    {
        if (thickness > 0)
        {
            thickness -= 1;
        }
    }
    void test()
    {
        for (int i = 0; i < allX.Count; i++)
        {
            smallestInt = allX[i];
            if (allX[i] < smallestInt)
            {
                smallestInt = allX[i];
            }
            if (allX[i] > biggestInt)
            {
                biggestInt = allX[i];
            }

        }


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        ModPanel = GameObject.FindGameObjectWithTag("mod");
        ModPanel.GetComponent<ModPanel>().unParentModChannel();

    }
}
