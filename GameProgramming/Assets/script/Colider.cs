using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider : MonoBehaviour
{
    private void OnTriggerEnter (Collider other) {
        Debug.Log(true);
    }

    private void OnTriggerExit (Collider other) {
        Debug.Log(false);
    }
}
