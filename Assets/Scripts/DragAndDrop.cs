using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler
{
    [SerializeField] private Canvas canvas;
    public RectTransform _transform;
    public CanvasGroup canvasGroup;
    public EditorMenu editorref;
    public bool Valid;
    public bool Addded;
    void Awake()
    {
        _transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        editorref = GameObject.FindObjectOfType<EditorMenu>();
    }
    private void FixedUpdate()
    {
        if(canvasGroup.alpha ==1)
        {
            Valid = true;
        }
        else
        {
            Valid = false;
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
        _transform.position += (Vector3)eventData.delta * canvas.transform.localScale.x /canvas.scaleFactor;
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
    public void OnDrop(PointerEventData eventData)
    {
        editorref.OnDrop(eventData);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
