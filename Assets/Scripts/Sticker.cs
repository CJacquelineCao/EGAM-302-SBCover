using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Sticker : MonoBehaviour, IPointerDownHandler
{
    public GameObject ModPanel;

    public GameObject ActualSticker;
    public GameObject Container;

    Vector3 stickerpos;
    private Canvas _canvas;


    int LargestSize = 3;
    int SmallestSize = 0;
    int currentSize;

    public bool inCombo;

    public EditorMenu editorRef;

    public int totalLayers;

    bool isflipped;
    // Start is called before the first frame update
    void Start()
    {
        editorRef = GameObject.FindObjectOfType<EditorMenu>();
    }
     void Update()
    {
        stickerpos = new Vector3(0, ActualSticker.GetComponent<RectTransform>().sizeDelta.y/2, 0);
       if(editorRef !=null)
        {
            totalLayers = editorRef.allStickers.Count;
        }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        ModPanel = GameObject.FindGameObjectWithTag("mod");
        if (ModPanel !=null)
        {
            if(inCombo == false)
            {            
                Container = ModPanel.transform.GetChild(0).gameObject;
                Container.SetActive(true);
                ModPanel.transform.SetParent(gameObject.transform);
                ModPanel.transform.localPosition = stickerpos;

            }

        }

    }
    // Update is called once per frame
    public void SetStickerSortingOrder(int i)
    {
        ActualSticker.GetComponent<Canvas>().sortingOrder = i;
    }
    public void Grow()
    {
        Vector3 GrowSize = new Vector3(0.5f, 0.5f, 0.5f);
        if(currentSize < LargestSize)
        {
            ActualSticker.GetComponent<RectTransform>().localScale += GrowSize;
            currentSize += 1;
        }
    }

    public void Shrink()
    {
        Vector3 ShrinkSize = new Vector3(0.5f, 0.5f, 0.5f);
        if (currentSize > SmallestSize)
        {
            ActualSticker.GetComponent<RectTransform>().localScale -= ShrinkSize;
            currentSize -= 1;
        }
    }

    public void Rotate()
    {
        ActualSticker.transform.localEulerAngles += new Vector3(0, 0, 45);
    }

    public void moveLayerUp()
    {
        int myIndex = editorRef.allStickers.IndexOf(this.gameObject);
        // can i actually go up?
        if (myIndex < editorRef.allStickers.Count - 1)
        {
            editorRef.allStickers.Remove(this.gameObject);
            editorRef.allStickers.Insert(myIndex + 1, this.gameObject);
            editorRef.RefreshStickerOrder();
        }
    }
    public void moveLayerDown()
    {
        int myIndex = editorRef.allStickers.IndexOf(this.gameObject);
        // can i actually go up?
        if (myIndex > 0)
        {
            editorRef.allStickers.Remove(this.gameObject);
            editorRef.allStickers.Insert(myIndex - 1, this.gameObject);
            editorRef.RefreshStickerOrder();
        }
    }

    public void FlipHorizontal()
    {
        if(isflipped == false)
        {
            ActualSticker.transform.localScale = new Vector3(transform.localScale.x * -1,
            transform.localScale.y,
            transform.localScale.z);
            isflipped = true;
        }
        else
        {
            ActualSticker.transform.localScale = new Vector3(transform.localScale.x * 1,
            transform.localScale.y,
            transform.localScale.z);
            isflipped = false;

        }



    }

}
