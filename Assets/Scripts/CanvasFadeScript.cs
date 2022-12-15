using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFadeScript : MonoBehaviour
{
    public float time;
    public float fadeOutTime;
    public float fadeInTime;
    public float onHoldTime;
    public GameObject MainMenu;
    public GameObject ARCamera;
    public GameObject ARMenu;
    public GameObject PuzzleMenu;
    public GameObject PuzzleWorkSpace;
    [SerializeField]
    private float timePassed;
    private Image image;
    [SerializeField]
    private bool callingMainMenuOff = false;
    private bool callingARCameraOn = false;
    // 0 = No Action, 1 = Turn On, 2 = Turn On;
    [SerializeField]
    private int fadingState = 0;
    // 0 = No Action, 1 = transparent To Black, 2 = Black To Transparent, 3 = OnHold[Automatic];
    private int callingARCamera = 0;
    private int callingMainMenu = 0;
    private int callingPuzzleMenu = 0;
    // Start is called before the first frame update
    void Start()
    {
        image = this.gameObject.GetComponent<Image>();
        image.color = new Vector4(0, 0, 0, 0);
       

    }

    // Update is called once per frame
    void Update()
    {
        
        if (fadingState != 0)
        {
            if (timePassed < time)
            {
                timePassed += Time.deltaTime;
            }
            else if (timePassed > time)
            {
                timePassed = time;
            }

            // 0 = No Action, 1 = transparent To Black, 2 = Black To Transparent, 3 = OnHold[Automatic];
            if (fadingState == 1)
            {
                image.color = new Vector4(0, 0, 0, timePassed / time);
            }
            else if (fadingState == 2)
            {
                image.color = new Vector4(0, 0, 0, 1 - (timePassed / time));
            }
            

            if(timePassed == time)
            {
               
                CanvasEvent();
            }
        }

        
    }
    public void CanvasEvent()
    {
        // 0 = No Action, 1 = Turn On, 2 = Turn On;
        //Turn off
        if (callingMainMenu == 2)
        {           
            MainMenu.SetActive(false);
        }
        if(callingARCamera == 2)
        {
            
            ARCamera.SetActive(false);           
            ARMenu.SetActive(false);
        }
        if(callingPuzzleMenu == 2)
        {  
            PuzzleWorkSpace.SetActive(false);            
            PuzzleMenu.SetActive(false);
        }

        if(fadingState == 1 )
        {
            fadingState = 3;
            timePassed = 0;
            time = onHoldTime;
            return;
        }

        //Turn On
        if (callingMainMenu == 1)
        {            
            MainMenu.SetActive(true);
            StartFadeIn(0);
        }
        if (callingARCamera == 1)
        {            
            ARMenu.SetActive(true);
            ARCamera.SetActive(true);
            StartFadeIn(0);
        }
        if(callingPuzzleMenu == 1)
        {   
            PuzzleWorkSpace.SetActive(true);         
            PuzzleMenu.SetActive(true);
            StartFadeIn(0);
        }
        callingMainMenu = 0;
        callingARCamera = 0;
        callingPuzzleMenu = 0;
        //Check Menu State

    }
    public void Transparent()
    {
        image.color = new Vector4(0,0,0,0);
        timePassed = 0;
    }
    public void StartFadeOut()
    {
        //transparent to black
        image.color = new Vector4(0, 0, 0, 0);
      
        fadingState = 1;
        timePassed = 0;
        time = fadeOutTime;
    }
    public void StartFadeIn(float extra)
    {
        //black to transparent
        image.color = new Vector4(0, 0, 0, 1);
       
        fadingState = 2;
        timePassed = 0;
        time = fadeInTime + extra;
    }
    // 0 = No Action, 1 = Turn On, 2 = Turn On;
    public void MainMenuOn()
    {
        callingMainMenu = 1;
    }
    public void MainMenuOff()
    {
        callingMainMenu = 2;
    }
    public void ARCameraOn()
    {
        callingARCamera = 1;
    }
    public void ARCameraOff()
    {
        callingARCamera = 2;
    }
    public void PuzzleMenuOn()
    {
        callingPuzzleMenu = 1;
    }
    public void PuzzleMenuOff()
    {
        callingPuzzleMenu = 2;
    }
}
