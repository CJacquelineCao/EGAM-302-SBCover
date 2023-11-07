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
    public EEOO comboref;
    public bool Valid;
    public bool Addded;

    GameObject ModPanel;

    void Awake()
    {
        _transform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        editorref = GameObject.FindObjectOfType<EditorMenu>();

    }
    private void FixedUpdate()
    {

        if (canvasGroup.alpha ==1)
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
        ModPanel = GameObject.FindGameObjectWithTag("mod");
        comboref = GameObject.FindObjectOfType<EEOO>();
        if (ModPanel !=null)
        {
            ModPanel.GetComponent<ModPanel>().unParentModChannel();
        }

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
        if(editorref !=null)
        {
            editorref.OnDrop(eventData);
        }

        if(comboref !=null)
        {
            comboref.OnDrop(eventData);
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
