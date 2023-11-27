using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class ShafePoint : MonoBehaviour
{
    public LayerMask VisionPLAYER;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
        Collider[] RANGECHECKS = Physics.OverlapBox(transform.position, transform.localScale / 2, transform.rotation, VisionPLAYER);

        
        if(RANGECHECKS.Length != 0)
        //foreach (var item in RANGECHECKS)
        {
            //var item = RANGECHECKS[0];
            //Transform target = item.transform;
            //Vector3 directiontottatarget = (target.position - transform.position).normalized;

            foreach (var item in RANGECHECKS)
            {
                var PLayer = item.gameObject.GetComponentInParent<PLayer>();
                //Debug.Log(PLayer.body.position);
                if(PLayer != null)
                {
                    PLayer.SetCheckpoint(transform.position + new Vector3(0f,2f,0f), gameObject.name);
                }
                
            }

        }
        
    }
    private void OnTriggerEnter (Collider other) {
        if (other.tag != "Untagged")
        {
            Debug.Log(false);
        }
    }

    private void OnTriggerExit (Collider other) {
        if (other.tag != "Untagged")
        {
            Debug.Log(true);
        }
    }
}
