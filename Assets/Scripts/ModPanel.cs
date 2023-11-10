using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ModPanel : MonoBehaviour
{
   public GameObject SelectedSticker;
    private Canvas _canvas;
    // Start is called before the first frame update
    void Start()
    {
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        setSticker();
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
    }
    public void setSticker()
    {
        SelectedSticker = gameObject.transform.parent.gameObject;
    }
    public void unParentModChannel()
    {
  
        GameObject Container = gameObject.transform.GetChild(0).gameObject;
        Container.SetActive(false);
        gameObject.transform.SetParent(_canvas.gameObject.transform);
        
    }

    public void ChangeSize()
    {
        SelectedSticker.GetComponentInChildren<Sticker>().Grow();
    }
    public void SmallSize()
    {
        SelectedSticker.GetComponent<Sticker>().Shrink();
    }
    public void RotateSticker()
    {
        SelectedSticker.GetComponent<Sticker>().Rotate();
    }

    public void layerUP()
    {
        SelectedSticker.GetComponent<Sticker>().moveLayerUp();
    }
    public void layerDOWN()
    {
        SelectedSticker.GetComponent<Sticker>().moveLayerDown();
    }

    public void Flip()
    {
        SelectedSticker.GetComponent<Sticker>().FlipHorizontal();
    }
}
