using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshClient : MonoBehaviour
{
    private NavMeshAgent Agent;

    //private List<Vector3> cords = new List<Vector3>() {new Vector3(0, 0 ,0), new Vector3(0, 0 ,0)};
    private int counter = 0;
    public List<GameObject> position = new List<GameObject>();

    public Material ColorActive;
    public Material NotActive;
    
    public bool spanner = false;
    public GameObject agent;
    public bool Moventdirect;
    public void SetCordinates(Vector3 Cords)
    {
        if(Moventdirect)
        {
             Agent.SetDestination(Cords);
             position[counter].transform.position = Cords;
        }
        else
        {
            if(!spanner){
                //cords[counter] = Cords;
                //Agent.SetDestination(cords[counter]);
                //position[counter].transform.position = cords[counter];
                position[counter].transform.position = Cords;
            }else
            {
                Instantiate(agent, Cords, Quaternion.identity);
            }
        }
    }

    public void SetActive(bool active)
    {
        if(!spanner){
            position.Select(A => A.GetComponent<MeshRenderer>()).ToList().ForEach(A => A.enabled = active);
        }
        gameObject.GetComponent<MeshRenderer>().material = active ? ColorActive : NotActive;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(true);
        if(!spanner){
            Agent = gameObject.GetComponent<NavMeshAgent>();
        }
    }

    private float time = 0.0f;
    public float interpolationPeriod = 5f;
    // Update is called once per frame
    void Update()
    {
        if(!spanner && !Moventdirect)
            {
            //if(transform.position.x == cords[counter].x && transform.position.z == cords[counter].z)
            if(transform.position.x == position[counter].transform.position.x && transform.position.z == position[counter].transform.position.z)
            {
            counter++;
                if (counter >= position.Count)
                {
                    counter = 0;
                }
                position[counter].transform.position = position[counter].transform.position;
            }
            else
            {
                time += Time.deltaTime;

                if (time >= interpolationPeriod) {
                    time = 0.0f;

                    // execute block of code here
                    Agent.SetDestination(position[counter].transform.position);
                }
            
            }
        }
        //Agent.SetDestination(cords);        
    }

    
}
