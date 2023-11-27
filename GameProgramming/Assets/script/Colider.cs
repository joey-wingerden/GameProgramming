using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class Colider : MonoBehaviour
{
    
    public bool PLAYERinVision;
    public bool PLAYERinRange;
    public List<Collider> colliders = new();
    public void OnTriggerEnter (Collider other) {
        if(!colliders.Any(A => A.name == other.name))
        {
            colliders.Add(other);
            TriggerEnter(other);
        }
        
    }
    protected abstract void TriggerEnter(Collider other);

    public void OnTriggerExit (Collider other) {
        colliders.Remove(other);
        TriggerExit(other);
    }
    protected abstract void TriggerExit(Collider other);
}
