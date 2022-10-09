using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : State
{
    private Context context;
    
  


    public override void Start(Context context){
        this.context = context;
        
        
    }
    public override void run(){
        if(isGrounded((context.controller))){
            context.velocity.y = 0;
            context.Change(context.idle);
        }

        setgravity();
        move();
        look(context);
    }
    public void move(){
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = context.transform.right * x + context.transform.forward * z ;
        

        context.controller.Move(move * context.speed * Time.deltaTime);
    }

    public void setgravity(){
        context.velocity.y += context.gravity * Time.deltaTime;
        context.controller.Move(context.velocity * Time.deltaTime);
    }
    
  
}
