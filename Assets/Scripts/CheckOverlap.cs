using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckOverlap : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ATransform;
    public Transform BTransform;
   
    public Collider2D[] overlapcircleResults;

    public int objectsDetected;

    float detectionRadius = 0.5f;

    public ContactFilter2D contactFilter = new ContactFilter2D();

    bool Saveable;
    public Button saveLayoutbutton;

    ScreenController screenref;
    void Start()
    {
        screenref = GameObject.FindObjectOfType<ScreenController>();

    }
    
    public void checkOverlaps()
    {
        objectsDetected = 0;
        float step = detectionRadius * 0.7f;
        for (float x = ATransform.transform.position.x; x < BTransform.transform.position.x; x+= step)
        {
            for(float y = ATransform.transform.position.y; y < BTransform.transform.position.y; y+= step)
            {
                Vector2 testpos = new Vector2(x, y);
                Debug.DrawLine(testpos + new Vector2(-0.1f, -0.1f), testpos + new Vector2(0.1f, 0.1f), Color.red, 2.0f);
                Debug.DrawLine(testpos + new Vector2(-0.1f, 0.1f), testpos + new Vector2(0.1f, -0.1f), Color.red, 2.0f);
                overlapcircleResults = new Collider2D[5];
                int objectsHit = Physics2D.OverlapCircle(testpos, detectionRadius, contactFilter, overlapcircleResults);
                //check if objects hit is > 1
                // make new list of comboscript
                if(objectsHit>=1)
                {
                    List<IAmACombo> allCombs = new List<IAmACombo>();
                    for (int i = 0; i < overlapcircleResults.Length; i++)
                    {
                        IAmACombo currentStickerCont = overlapcircleResults[i].gameObject.transform.parent.GetComponent<IAmACombo>();
                        if(currentStickerCont!=null)
                        {
                            if (!allCombs.Contains(currentStickerCont))
                            {
                                allCombs.Add(currentStickerCont);
                            }
                        }

                    }
                    objectsDetected = allCombs.Count;
                    foreach (IAmACombo combo in allCombs)
                    {
                        foreach(Transform child in combo.gameObject.transform)
                        {
                            GameObject Image = child.transform.GetChild(0).gameObject;
                            ChangeColor(Image, Color.red);

                        }
                    }
                }
                else
                {
                    foreach (Transform child in overlapcircleResults[0].gameObject.transform)
                    {
                        GameObject Image = child.transform.GetChild(0).gameObject;
                        ChangeColor(Image, Color.white);
                    }
                        
                }

                //loop from 0 to objects hit in overlapcircle results
                // each item in item in overlapcircle results getcomponent in parent of comboscript
                // if comboscript list doesnt contains the current comboscript, add to list
                //size of list is how many are overlapping, the contents is what stickercombos need to be modified
                //if (objectsHit > objectsDetected)
                //{
                //    objectsDetected = objectsHit;
                    
                //}
            }
        }
        if(objectsDetected >1)
        {
            Debug.Log("more than 1 object here");
        }
        

    }
    // Update is called once per frame
    void Update()
    {

        if (Saveable == true)
        {
            saveLayoutbutton.interactable = true;
        }
        else
        {
            saveLayoutbutton.interactable = false;
        }
    }

    void ChangeColor(GameObject sticker, Color color)
    {
        sticker.GetComponent<Image>().material.color = color;
    }

    void saveLayout()
    {
        //if all objects are white && if(EEOO.ComboStickers[i].GetComponent<DragAndDrop>().Valid == true)
        Saveable = true;
        //else
        Saveable = false;
    }

    public void switchBacktoEditor()
    {
        //get all objects and set them inactive then...

        screenref.TurnonEditorScreen();
    }
}
