using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DirtManager : MonoBehaviour
{
    public GameObject[] Dirts; //How many Dirt On Scene
    public GameObject[] Spawn_Range; // Spawn Range Object
    public float Range_X, Range_Y; // Range Value
    public List<GameObject> Collectiable = new List<GameObject>(); //Collectiable Count
    public int Collet_Count; // request how many collectiable
    public List<int> Temp_Int = new List<int>(); // temporary int to determined collectiable hide behind which dirt
    private int Select_Collecti_Pos;
    public int howManyIsCollected = 0;
    public Button backPack;
    public float SpawnLimit;
    public GameObject TargetGroup;
    public GameObject greenDinoPic;
    public Vector3 minusTargetPos;
    public Vector3 defaultTarget;
    public int whichTarget; //0 = null, 1 = green;
    public GameObject ARCamera;
    public JigsawManager jigManager;
    
    void Start()
    {
       defaultTarget = new Vector3(1,1,1);
        //ResetPosition();
        //ResetCaller();

        //Debug.Log(Dirts.Length);
    }
    void Update()
    {
        ARCamera.transform.eulerAngles = new Vector3(0,0,0);
        ARCamera.transform.position = new Vector3(0,0,-10);
        if(whichTarget == 0)
        {
            minusTargetPos = defaultTarget;
        }
        else if(whichTarget == 1)
        {
            minusTargetPos = greenDinoPic.transform.position;
        }
        if(howManyIsCollected == Collet_Count)
        {
            howManyIsCollected = 0;
            backPack.interactable = true;
            
        }
       
    }

    public void ResetCaller()
    {
        TargetGroup.SetActive(false);
        ARCamera.transform.eulerAngles = new Vector3(0,0,0);
        ARCamera.transform.position = new Vector3(0,0,-10);
        //Hide Collectiable And Clearing Temp_Int List
        Temp_Int.Clear(); // clear List
        Fossile_Hide();
        ResetCollectCount();
        //ResetPosition();
        for (int i = 0; i < Dirts.Length;i++)
        {
            Dirts[i].GetComponent<new_scratch>().local_Collectiable = null;
            Dirts[i].transform.parent.gameObject.SetActive(true);
            Range_X = Spawn_Range[i].GetComponent<BoxCollider2D>().bounds.size.x / SpawnLimit;//��oBoxCollider X ����
            Range_Y = Spawn_Range[i].GetComponent<BoxCollider2D>().bounds.size.y / SpawnLimit;//��oBoxCollider Y ����
            var Transform = Spawn_Range[i].transform.position;
            Dirts[i].GetComponent<new_scratch>().ResetDirt();          
            
            Dirts[i].transform.parent.gameObject.transform.position = new Vector3(Random.Range((Transform.x + -Range_X) , (Transform.x + Range_X)), Random.Range(Transform.y + -Range_Y, Transform.y + Range_Y), 10);
        }
        //Check Collectiable Count Need
        
        //Set Collectiable Position
        for(int i =0; i < Collet_Count; i++)
        {
            Select_Collecti_Pos = Random.Range(0, 8);
            //Debug.Log(i + "Collect IN USE");
            //assigning which dirt should Collectiable hide 
            if (i == 0)
            {
                //first collectiable have no competitioner
                //no need to worry
                
            }
            else
            {
                //prevent the rest of the collectiable to hide behind same dirt 
                Debug.Log(i + "A");
                for (int a = 0; a < Temp_Int.Count; a++)
                {
                    if (Select_Collecti_Pos == Temp_Int[a]) //If same Number Re fetch
                    {
                        Debug.Log(i + "==" + Temp_Int[a]);
                        Select_Collecti_Pos = Random.Range(0, 8);//Re Fetch Number
                        a = -1; // Re Check If Same
                    }
                    
                }
            }
            //assign the position
            Collectiable[i].transform.position = Dirts[Select_Collecti_Pos].transform.parent.gameObject.transform.position;
            Dirts[Select_Collecti_Pos].GetComponent<new_scratch>().local_Collectiable = Collectiable[i];
            Temp_Int.Add(Select_Collecti_Pos); //add the assigned dirt Location to the list
            ARCamera.GetComponent<Camera_Ray>().enabled = false;
            ARCamera.GetComponent<Camera_Ray>().enabled = true;
        }
    }
    public void Fossile_Active()
    {
        for(int xx = 0; xx < Collet_Count; xx++)
        {
            Collectiable[xx].SetActive(true);
        }
    }
    public void Fossile_Hide()
    {
        for (int x = 0; x < Collet_Count; x++)
        {
            Collectiable[x].SetActive(false);
        }
    }
    public void Dirt_Hide()
    {
        for (int i = 0; i < Dirts.Length; i++)
        {
            Dirts[i].transform.parent.gameObject.SetActive(false);
            
        }
    }
    public void ResetCollectCount()
    {
        howManyIsCollected = 0;
        
    }
    public void InputGreen()
    {
        jigManager.loadLongNeck();
        whichTarget =1;
        ResetCaller(); 
    }
    public void InputTrex()
    {
        jigManager.loadTrex();
        whichTarget =0;
        ResetCaller(); 
    }
    public void InputTriceptor()
    {
        jigManager.loadTriceptor();
        whichTarget =0;
        ResetCaller(); 
    }
    /*
    public void ResetPosition()
    {
        for (int i = 0; i < Dirts.Length; i++)
        {
            Range_X = Spawn_Range[0].GetComponent<BoxCollider2D>().bounds.size.x / 2;
            Range_Y = Spawn_Range[0].GetComponent<BoxCollider2D>().bounds.size.y / 2;
            var Transform = Spawn_Range[0].transform.position;
            //Debug.Log(Transform.y + "and" +  );
            //Dirts[i].transform.parent.gameObject.transform.position = new Vector3(Transform.x - Random.Range(-Range_X, Range_X), Transform.y - Random.Range(-Range_Y, Range_Y),10);
            Dirts[i].transform.parent.gameObject.transform.position = new Vector3(Random.Range(Transform.x + -Range_X, Transform.x + Range_X), Random.Range(Transform.y + -Range_Y, Transform.y + Range_Y), 10);
        }
    }
    */
}
