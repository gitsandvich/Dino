using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Ray : MonoBehaviour
{

    
    public Camera Main;
    private Collider2D ColliderHit;
    public float x_offset;
    public float y_offset;
    public LayerMask Dirt;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if(x_offset <=0)
        {
            x_offset = 0.01f;
        }
        
        if (Input.GetMouseButton(0))
        {
            /*
            // if left button pressed...
            Ray ray = Main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("button_pressed");
            if (Physics.Raycast(ray, out hit))
            {
                // the object identified by hit.transform was clicked
                // do whatever you want
                
                Debug.Log("hit");
            }
            */
             //Debug.Log(Input.mousePosition);
             Vector2 pos1=Input.mousePosition;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos3 = GetNewPos(pos1);
            Debug.Log("Mouse At"+pos1 +"=OLD=>"+pos);
            Debug.Log("Mouse At"+pos1 +"=NEW=>"+GetNewPos(pos1));

            ColliderHit = Physics2D.OverlapPoint(pos3, Dirt);

            Debug.Log(ColliderHit);
            if(ColliderHit != null)
            {
                ColliderHit.GetComponent<new_scratch>().PixelAlter(pos3);
            }
           
            

        }



    }

    private Vector2 GetNewPos(Vector2 pos)
    {
        Vector2 result = new Vector2(0,0);

        //result.x = (pos.x-960)/108*x_offset;
        //result.y = (pos.y-540)/108*x_offset;

        result.x = (pos.x - (Screen.width / 2)) / 90 * x_offset;
        result.y = (pos.y - (Screen.height / 2)) / 90 * y_offset;

        return result;
    }

}
