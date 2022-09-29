using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : State
{
    public Context context;
  
    
    public override void Start(Context context){
        this.context = context;
        
    }
    public override void run(){
        if(!checkmovement()){
            context.Change(new Idle());
        }
        if(jump()){
            context.Change(new Jumping());
        }
        if(!isGrounded(context.controller)){
            context.Change(new Falling());
        }
        move();
        look(context);
    }
    public void move(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = context.transform.right * x + context.transform.forward * z ;
        

        context.controller.Move(move * context.speed * Time.deltaTime);
    }

}
