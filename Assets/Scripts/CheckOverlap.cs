using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckOverlap : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform ATransform;
    public Transform BTransform;
   
    public Collider2D[] overlapcircleResults;

    public int objectsDetected;

    float detectionRadius = 5;
    public ContactFilter2D contactFilter = new ContactFilter2D();
    void Start()
    {
        //two X transforms y transforms
        //use debug drawline
        //step size
        //overlap circle 
        checkOverlaps();
    }
    
    void checkOverlaps()
    {
        for (int i =0; i<ATransform.transform.position.x; i++)
        {
            for(int f = 0; f < BTransform.transform.position.y; f++)
            {
                gameObject.transform.position += new Vector3(1, 1, 0);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        overlapcircleResults = new Collider2D[5];
        objectsDetected = Physics2D.OverlapCircle(transform.position, detectionRadius, contactFilter, overlapcircleResults);
        if (objectsDetected > 1)
        {
            Debug.Log("more than 1 object here");
        }
    }
}
