using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DinoHolder : MonoBehaviour
{
    public GameObject triceptor, trex, longneck;
    public GameObject holder;
    public int temp_Count_Triceptor, temp_Count_Trex, temp_Count_Longneck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void resetCount()
    {
        GameCache.Triceptor += temp_Count_Triceptor;
        GameCache.Trex += temp_Count_Trex;
        GameCache.LongNeck += temp_Count_Longneck;
        temp_Count_Longneck = 0;
        temp_Count_Trex = 0;
        temp_Count_Triceptor = 0;
        foreach (Transform child in holder.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }
    public void SummonTriceptor()
    {
        if(GameCache.Triceptor >0)
        {
            GameCache.Triceptor -= 1;
            temp_Count_Triceptor++;
            GameObject obj1 = Instantiate(triceptor, new Vector3(Random.Range(-4f, 4f), Random.Range(2f, -1f), 0) , Quaternion.identity);
            obj1.transform.parent = holder.transform;
        }
    }
    public void SummonTrex()
    {
        if (GameCache.Trex > 0)
        {
            GameCache.Trex -= 1;
            temp_Count_Trex++;
            GameObject obj1 = Instantiate(trex, new Vector3(Random.Range(-4f, 4f), Random.Range(2f, -1f), 0), Quaternion.identity);
            obj1.transform.parent = holder.transform;
        }
    }
    public void SummonLongNeck()
    {
        if (GameCache.LongNeck > 0)
        {
            GameCache.LongNeck -= 1;
            temp_Count_Longneck++;
            GameObject obj1 = Instantiate(longneck, new Vector3(Random.Range(-4f, 4f), Random.Range(2f, -1f), 0), Quaternion.identity);
            obj1.transform.parent = holder.transform;
        }
    }
}
