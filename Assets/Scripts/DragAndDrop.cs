using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    public RectTransform _transform;
    public CanvasGroup canvasGroup;
    void Awake()
    {
        _transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        _transform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stopped Drag");
        canvasGroup.blocksRaycasts = true;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("MouseDown");
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
