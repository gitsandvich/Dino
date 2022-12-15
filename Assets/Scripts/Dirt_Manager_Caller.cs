using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirt_Manager_Caller : MonoBehaviour
{
    public DirtManager DM;
    public void DM_Fossile()
    {
        ///<summary>
        ///this code is for when the dirt is being placed
        ///and is playing the expanding animation
        ///but during the process the collectiable should not be visible
        ///there's a single Dirt call """Dirt_Main""" after finish plaing expanding 
        ///will call this code to make collectiable visible
        ///</summary>
        DM.Fossile_Active();
    }
}
