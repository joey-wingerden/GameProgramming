using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PLayer : MonoBehaviour
{
   public Transform body;
   public Checkpoint checkpoint;
   public Vector3 position;
   public game Game;
    // Start is called before the first frame update
    void Start()
    {
        checkpoint = new Checkpoint(body.position, "");
    }

    // Update is called once per frame
    void Update()
    {
         //kill();
        // Debug.Log(checkpoint.spawnpoint);
    }

    public void kill()
    {
        Game.spawnprefab();
        Destroy(gameObject);
    }
    public void SetCheckpoint(Vector3 spawnpoint, string name)
    {
        
        if(checkpoint != null)
        {
            if(checkpoint.name == name )
            {
                if(checkpoint.spawnpoint == body.position )
                {
                    return;
                }
                else
                {
                    //checkpoint.spawnpoint = body.position;
                    //position = checkpoint.spawnpoint;
                }
                return;
            }
            
        }
        //Debug.Log(position);
        //checkpoint = new Checkpoint(body.position, name);
        //Debug.Log("new spawn new " +checkpoint.spawnpoint +" vs old "+ body.position);
        //position = checkpoint.spawnpoint;
        //kill();
        
    }

 }
  public class Checkpoint
 {
    public Vector3 spawnpoint; 
    public string name;

    public Checkpoint(Vector3 spawnpoint, string name)
    {
        this.spawnpoint = spawnpoint;
        this.name = name;
    }
 }
