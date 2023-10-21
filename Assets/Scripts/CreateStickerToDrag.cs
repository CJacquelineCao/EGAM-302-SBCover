using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateStickerToDrag : MonoBehaviour, IInitializePotentialDragHandler, IDragHandler
{
    public GameObject testUI;
    public GameObject parentCanvas;
    public RectTransform _transform;
    public GameObject createdsticker;
    private Canvas _canvas;
    void Awake()
    {
        _canvas = parentCanvas.GetComponent<Canvas>();
        _transform = GetComponent<RectTransform>();
    }

    public void OnInitializePotentialDrag(PointerEventData eventData)
    {
        Debug.Log("" + _transform.anchoredPosition);
        createdsticker = Instantiate(testUI, _transform.anchoredPosition, Quaternion.identity);
        createdsticker.transform.SetParent(parentCanvas.transform, false);
        eventData.pointerDrag = createdsticker;
    }
    public void OnDrag(PointerEventData eventData)
    {
       
    }




}
