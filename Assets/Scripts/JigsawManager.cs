using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JigsawManager : MonoBehaviour
{
    public GameObject jigsaw_1,jigsaw_2,jigsaw_3;
    public GameObject holder_1,holder_2,holder_3;
    public Sprite[] Trex,Triceptor,LongNeck;
    public Sprite[] Trex_Back,Triceptor_Back,LongNeck_Back;
    public Vector3[] Trex_HolderPlace,Triceptor_HolderPlace,LongNeck_HolderPlace;
    public int whichDino = 0; // 0 = triceptor, 1 = Trex , 2 =LongNeck;
    public int jigsawProgress = 0; // 0 =no progress 3 = complete;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CheckJigsawComplete()
    {
        jigsawProgress += 1;
        if(jigsawProgress == 3)
        {
            // 0 = triceptor, 1 = Trex , 2 =LongNeck;
            if (whichDino ==0)
            {
                GameCache.Triceptor += 1;
            }
            else if(whichDino == 1)
            {
                GameCache.Trex += 1;
            }
            else if(whichDino == 2)
            {
                GameCache.LongNeck += 1;
            }
            Debug.Log(GameCache.Triceptor + "GameCache.Triceptor");
            Debug.Log(GameCache.Trex + "GameCache.Trex");
            Debug.Log(GameCache.LongNeck + "GameCache.LongNeck");
        }
    }
    public void reloadPosition()
    {
        jigsawProgress = 0;
        jigsaw_1.GetComponent<Drag>().Reset();
        jigsaw_2.GetComponent<Drag>().Reset();
        jigsaw_3.GetComponent<Drag>().Reset();
    }
    public void loadTriceptor()
    {
        whichDino = 0;
        reloadPosition();
        jigsaw_1.GetComponent<SpriteRenderer>().sprite = Triceptor[0];
        jigsaw_2.GetComponent<SpriteRenderer>().sprite = Triceptor[1];
        jigsaw_3.GetComponent<SpriteRenderer>().sprite = Triceptor[2];
        holder_1.GetComponent<SpriteRenderer>().sprite = Triceptor_Back[0];
        holder_2.GetComponent<SpriteRenderer>().sprite = Triceptor_Back[1];
        holder_3.GetComponent<SpriteRenderer>().sprite = Triceptor_Back[2];
        holder_1.transform.position = Triceptor_HolderPlace[0];
        holder_2.transform.position = Triceptor_HolderPlace[1];
        holder_3.transform.position = Triceptor_HolderPlace[2];
    }
    public void loadTrex()
    {
        whichDino = 1;
        reloadPosition();
        jigsaw_1.GetComponent<SpriteRenderer>().sprite = Trex[0];
        jigsaw_2.GetComponent<SpriteRenderer>().sprite = Trex[1];
        jigsaw_3.GetComponent<SpriteRenderer>().sprite = Trex[2];
        holder_1.GetComponent<SpriteRenderer>().sprite = Trex_Back[0];
        holder_2.GetComponent<SpriteRenderer>().sprite = Trex_Back[1];
        holder_3.GetComponent<SpriteRenderer>().sprite = Trex_Back[2];
        holder_1.transform.position = Trex_HolderPlace[0];
        holder_2.transform.position = Trex_HolderPlace[1];
        holder_3.transform.position = Trex_HolderPlace[2];
    }
    public void loadLongNeck()
    {
        whichDino = 2;
        reloadPosition();
        jigsaw_1.GetComponent<SpriteRenderer>().sprite = LongNeck[0];
        jigsaw_2.GetComponent<SpriteRenderer>().sprite = LongNeck[1];
        jigsaw_3.GetComponent<SpriteRenderer>().sprite = LongNeck[2];
        holder_1.GetComponent<SpriteRenderer>().sprite = LongNeck_Back[0];
        holder_2.GetComponent<SpriteRenderer>().sprite = LongNeck_Back[1];
        holder_3.GetComponent<SpriteRenderer>().sprite = LongNeck_Back[2];
        holder_1.transform.position = LongNeck_HolderPlace[0];
        holder_2.transform.position = LongNeck_HolderPlace[1];
        holder_3.transform.position = LongNeck_HolderPlace[2];
    }
}
