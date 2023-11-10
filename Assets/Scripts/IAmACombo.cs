using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IAmACombo : MonoBehaviour,IInitializePotentialDragHandler, IDragHandler
{
    public GameObject testUI;
    public GameObject parentCanvas;
    public RectTransform _transform;
    public GameObject createdsticker;
    void Awake()
    {
        parentCanvas = GameObject.FindGameObjectWithTag("Canvas");
        _transform = GetComponent<RectTransform>();
    }
    private void Start()
    {

        _transform = GetComponent<RectTransform>();
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("" + _transform.anchoredPosition);
        createdsticker = Instantiate(testUI, _transform.position, Quaternion.identity);
        if (createdsticker.activeSelf == false)
        {
            createdsticker.SetActive(true);

        }
        createdsticker.GetComponent<DragAndDrop>().enabled = true;
        if (createdsticker.GetComponent<CreateStickerToDrag>() != null)
        {
            createdsticker.GetComponent<CreateStickerToDrag>().enabled = false;
        }
        createdsticker.transform.SetParent(parentCanvas.transform, false);
        createdsticker.transform.position = _transform.position;
        eventData.pointerDrag = createdsticker;
    }
    public void OnDrag(PointerEventData eventData)
    {

    }
}
