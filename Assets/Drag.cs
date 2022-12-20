using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag : MonoBehaviour
{
    public GameObject detector;
    Vector3 fossil_awal, scale_awal;
    Vector3 fossile_Rotate;
    public Vector3[] position, rotation;
    bool on_fossil = false;
    public GameObject Manager;
    // Use this for initialization
    void Start()
    {
        fossile_Rotate = transform.eulerAngles;
        fossil_awal = transform.position;
        scale_awal = transform.localScale;
    }

    void OnMouseDrag()
    {
        Vector3 fossil_mouse = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        transform.position = new Vector3(fossil_mouse.x, fossil_mouse.y, -1f);
        transform.localScale = new Vector2(1f, 1f);
    }

    void OnMouseUp()
    {
        if (on_fossil)
        {
            transform.eulerAngles = detector.transform.eulerAngles;
            transform.position = detector.transform.position;
            transform.localScale = new Vector2(1f, 1f);
            Manager.GetComponent<JigsawManager>().CheckJigsawComplete();
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            transform.eulerAngles = fossile_Rotate;
            transform.position = fossil_awal;
            transform.localScale = scale_awal;
        }
    }
    void OnTriggerStay2D(Collider2D objek)
    {
        if (objek.gameObject == detector)
        {
            on_fossil = true;
        }
    }

    void OnTriggerExit2D(Collider2D objek)
    {
        if (objek.gameObject == detector)
        {
            on_fossil = false;
        }
    }
    public void Reset() 
    {   
            on_fossil = false;
            transform.eulerAngles = rotation[0];
            transform.position = position[0];
            transform.localScale = new Vector3(1,1,1);
            this.GetComponent<BoxCollider2D>().enabled = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
