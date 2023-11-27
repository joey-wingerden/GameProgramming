using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    public Material VisionConeMaterial;
    public float VisionRange;
    public float VisionAngle;
    public float Angle;

    public bool Rendering;
    public LayerMask VisionObstructingLayer;//layer with objects that obstruct the enemy view, like walls, for example
    public LayerMask VisionPLAYER;//layer with objects that PLAYER the enemy view, like walls, for example
    public int VisionConeResolution = 120;//the vision cone will be made up of triangles, the higher this value is the pretier the vision cone will be
    Mesh VisionConeMesh;
    MeshFilter MeshFilter_;


    //Create all of these variables, most of them are self explanatory, but for the ones that aren't i've added a comment to clue you in on what they do
    //for the ones that you dont understand dont worry, just follow along
    void Start()
    {
        Angle = VisionAngle;
        transform.AddComponent<MeshRenderer>().material = VisionConeMaterial;
        MeshFilter_ = transform.AddComponent<MeshFilter>();
        VisionConeMesh = new Mesh();
        VisionAngle *= Mathf.Deg2Rad;
        if(!Rendering)
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }

    
    void Update()
    {
        DrawVisionCone();//calling the vision cone function everyframe just so the cone is updated every frame
        
        Collider[] RANGECHECKS = Physics.OverlapSphere(transform.position, VisionRange, VisionPLAYER);
        colider.PLAYERinRange = false;
        
        if(RANGECHECKS.Length != 0)
        //foreach (var item in RANGECHECKS)
        {
            var item = RANGECHECKS[0];
            Transform target = item.transform;
            Vector3 directiontottatarget = (target.position - transform.position).normalized;
            
            if(Vector3.Angle(transform.forward, directiontottatarget) < Angle / 2){
                colider.PLAYERinRange = true;
                if(!colider.colliders.Any(a => a.name == item.name))
                {
                    colider.PLAYERinRange = true;
                }
            }
        }
        
    }
    public Colider colider;
    void DrawVisionCone()//this method creates the vision cone mesh
    {
        List<Collider> colliders = new();
	    int[] triangles = new int[(VisionConeResolution - 1) * 3];
    	Vector3[] Vertices = new Vector3[VisionConeResolution + 1];
        Vertices[0] = Vector3.zero;
        float Currentangle = -VisionAngle / 2;
        float angleIcrement = VisionAngle / (VisionConeResolution - 1);
        float Sine;
        float Cosine;

        //setvarriable
        colider.PLAYERinVision = false;
        for (int i = 0; i < VisionConeResolution; i++)
        {
            Sine = Mathf.Sin(Currentangle);
            Cosine = Mathf.Cos(Currentangle);
            Vector3 RaycastDirection = (transform.forward * Cosine) + (transform.right * Sine);
            Vector3 VertForward = (Vector3.forward * Cosine) + (Vector3.right * Sine);
            if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit, VisionRange, VisionObstructingLayer))
            {
                Vertices[i + 1] = VertForward * hit.distance;
            }
            else if (Physics.Raycast(transform.position, RaycastDirection, out RaycastHit hit2, VisionRange, VisionPLAYER))
            {
                colider.PLAYERinVision = true;
                Vertices[i + 1] = VertForward * hit2.distance;
                
                if (hit2.collider.tag != "Untagged")
                {
                    if(!colliders.Any(A => A.name == hit2.collider.name))
                    {
                        colider.OnTriggerEnter(hit2.collider);
                        colliders.Add(hit2.collider);
                    }
                }
            }
            else
            {
                Vertices[i + 1] = VertForward * VisionRange;
            }
            
            Currentangle += angleIcrement;
        }
        for (int i = 0, j = 0; i < triangles.Length; i += 3, j++)
        {
            triangles[i] = 0;
            triangles[i + 1] = j + 1;
            triangles[i + 2] = j + 2;
        }
        VisionConeMesh.Clear();
        VisionConeMesh.vertices = Vertices;
        VisionConeMesh.triangles = triangles;
        MeshFilter_.mesh = VisionConeMesh;
        
        try{
            if(colider != null)
            {
                foreach (var item in colider.colliders)
                {
                    if(!colliders.Any(B => B.name == item.name))
                    {
                        colider.OnTriggerExit(item);
                    }
                    
                }
            }
        }
        catch (Exception e) 
        {

        }
       
    }


}