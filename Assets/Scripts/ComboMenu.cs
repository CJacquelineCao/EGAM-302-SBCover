using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ComboMenu : MonoBehaviour
{
    [System.Serializable]
    public class ComboItem
    {
        public Vector3 Location;
        public GameObject stickerSprite;
        public GameObject MenuSlot;
    }
    public List<ComboItem> allCombos = new List<ComboItem>();

    public bool generated;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(generated == false)
        {
            if (gameObject.activeSelf == true)
            {
                CreateComboBar();
            }
        }

    }
    public void addToList(GameObject stickerCombo)
    {
        for (int i = 0; i < allCombos.Count; i++)
        {
            if(allCombos[i].stickerSprite == null)
            {
                allCombos[i].stickerSprite = stickerCombo;
            }
        }

    }
    void CreateComboBar()
    {
        for (int i = 0; i < allCombos.Count; i++)
        {
            allCombos[i].MenuSlot = Instantiate(allCombos[i].stickerSprite, allCombos[i].Location, Quaternion.identity);
            allCombos[i].MenuSlot.transform.SetParent(gameObject.transform, false);
            allCombos[i].MenuSlot.GetComponent<DragAndDrop>().enabled = false;
            allCombos[i].MenuSlot.SetActive(true);
        }
        generated = true;
    }
}
