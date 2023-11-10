using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenController : MonoBehaviour
{
    public GameObject EditorScreen;
    public GameObject ComboScreen;

    public EditorMenu editorref;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    public void TurnonComboScreen()
    {
        editorref.CreateStickerCombo();
        ComboScreen.SetActive(true);
        EditorScreen.SetActive(false);
    }
    public void TurnonEditorScreen()
    {
        ComboScreen.SetActive(false);
        EditorScreen.SetActive(true);
    }
}
