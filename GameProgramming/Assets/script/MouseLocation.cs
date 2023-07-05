using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MouseLocation : MonoBehaviour
{

    public Camera cam;
    public NavMeshClient agent;

    private RaycastHit hit;
    private GameObject Active;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                var agent2 = hit.transform.gameObject.GetComponent<NavMeshClient>();
                if (agent2 != null)
                {
                    if(agent != null)
                    {
                        agent.SetActive(false);
                    }
                    if(agent != agent2)
                    {
                        agent = agent2;
                        agent.SetActive(true);
                    }
                    else
                    {
                        agent = null;
                    }
                }
                
                else
                {
                    if(agent != null)
                    {
                        agent.SetCordinates(hit.point);
                    }
                    
                    //agent.SetDestination(hit.point);
                    //var test = agent.CalculatePath(hit.point, agent.path);
                }   
            }
        }
    }
}
