using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public  class VisionColider : Colider
{
    protected override void TriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            try
            {
                Debug.Log(other);
               var Player = other.GetComponentInParent<PLayer>();
               Player.kill();

               colliders.Remove(other);
            }
            catch (Exception e) 
            {
                Debug.Log(e);
            }        
        }
        
    }

    protected override void TriggerExit(Collider other)
    {
        Debug.Log("leave_" + other.name);
    }
}
