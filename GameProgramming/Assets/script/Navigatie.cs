using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigatie : MonoBehaviour
{
    [SerializeField] private Transform Target;
    private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {   
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        var old = transform.position;
        if(Input.anyKey){
            Debug.Log("true");
            agent.destination = Target.position;
        }
        

        RaycastHit hit;
        if(!Physics.Raycast(transform.position, Vector3.down, out hit, 2)){
            
            agent.destination = old;
        }
    }
}
