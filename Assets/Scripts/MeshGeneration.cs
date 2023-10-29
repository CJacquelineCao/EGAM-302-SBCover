using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGeneration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void generateMesh()
    {
        var stickerCorners = new Vector3[4];
        gameObject.GetComponent<RectTransform>().GetWorldCorners(stickerCorners);
        RectTransformUtility.WorldToScreenPoint(Camera.main, stickerCorners[0]);
    }
}
