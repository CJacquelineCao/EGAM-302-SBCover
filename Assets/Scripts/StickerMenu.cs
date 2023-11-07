using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StickerMenu : MonoBehaviour, IDropHandler
{
    [System.Serializable]
    public class MenuItem
    {
        public Vector3 Location;
        public Sprite stickerSprite;
        public GameObject MenuSlot;
    }
    public List<MenuItem> allItems = new List<MenuItem>();
    public GameObject ItemPrefab;
    private Canvas _canvas;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<DragAndDrop>().canvasGroup.alpha = 1;
            Destroy(eventData.pointerDrag.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        CreateItemBar();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateItemBar()
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            allItems[i].MenuSlot = Instantiate(ItemPrefab, allItems[i].Location, Quaternion.identity);
            allItems[i].MenuSlot.transform.SetParent(gameObject.transform, false);
            allItems[i].MenuSlot.GetComponent<Image>().sprite = allItems[i].stickerSprite;
        }
    }

}

