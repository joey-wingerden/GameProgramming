using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Context 
{
    public State state {get; set;}
    public CharacterController controller;
    public Transform transform;

     //public  float xRotation = 0f;
     public Camera camera;
     public float mouseSensitivity;

    public float gravity;
    public  Vector3 velocity;
    public float speed;


    //states
    public State falling = new Falling();
    public State jumping = new Jumping();
    public State idle = new Idle();
    public State movement = new Movement();
    public State running = new Running();
     

    
    public Context(State Start, CharacterController controller, Transform transform, Camera camera)
    {
        mouseSensitivity = 1000f;
        gravity = -21;
        velocity = new Vector3();
        speed = 10f;


        this.controller = controller;
        this.transform = transform;
        this.camera = camera;


        state = Start;
    }

    public void Change(State state)
    {
        this.state = state;
        Start();
    }

    public void Start(){
        state.Start(this);
    }
    public void run(){
        state.run();
    }
}
