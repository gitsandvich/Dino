using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Manager : MonoBehaviour
{
    private int tutorial_Page;
    public Button btn_play;
    public Button btn_tutorial;
    public Button btn_quit;
    public Button btn_library;
    public Button btn_ARMenuBack;
    public Button btn_ARMenuBackPack;
    public Button btn_LibraryBack;
    public Button btn_PuzzleBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DisableNoneTutorialButton()
    {
        btn_play.interactable = false;
        btn_tutorial.interactable = false;
        btn_quit.interactable = false;
        btn_library.interactable = false;
    }
    public void ActivateNoneTutorialButton()
    {
        btn_play.interactable = true;
        btn_tutorial.interactable = true;
        btn_quit.interactable = true;
        btn_library.interactable = true;
    }
    public void DisableARMenuButton()
    {
        btn_ARMenuBackPack.interactable = false;
        btn_ARMenuBack.interactable = false;
    }
    public void ActivateARMenuButton()
    {
        btn_ARMenuBackPack.interactable = false;
        btn_ARMenuBack.interactable = true;
    }
    public void DisableLibraryButton()
    {
        btn_LibraryBack.interactable = false;
    }
    public void ActivateLibraryButton()
    {
        
        btn_LibraryBack.interactable = true;
    }
    public void DisablePuzzleButton()
    {
        btn_PuzzleBack.interactable = false;
    }
    public void ActivatePuzzleButton()
    {
        btn_PuzzleBack.interactable = true;
    }
}
