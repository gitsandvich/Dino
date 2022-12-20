using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiableScript : MonoBehaviour
{
    public float delayTime;
    private float timePassed;
    public bool isCollected = false;
    public GameObject target;
    public float speed = 5;
    public GameObject DirtManager;
    // Start is called before the first frame update
    void Start()
    {
        DirtManager = GameObject.Find("Dirt_Manager");
    }

    // Update is called once per frame
    void Update()
    {
        if(isCollected == true)
        {
            if(delayTime > timePassed )
            {
                timePassed += Time.deltaTime;
                return;
            }
            var step = Time.deltaTime * speed;
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
            if(Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                isCollected = false;
                timePassed = 0;
                DirtManager.GetComponent<DirtManager>().howManyIsCollected += 1;
                this.gameObject.SetActive(false);
            }
        }

    }
    
}
