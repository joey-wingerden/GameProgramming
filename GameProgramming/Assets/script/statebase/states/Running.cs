using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : State
{
    public Context context;
    float speedboost;
   public override void Start(Context context){
        this.context = context;
        speedboost = 5;
    }
    public override void run(){
        if(Input.GetKeyUp(KeyCode.LeftShift)){
            context.Change(context.movement);
        }
        
        if(!isGrounded(context.controller)){
            context.Change(context.falling);
        }
        move();
        look(context);
    }
      public void move(){
        float x = Input.GetAxis("Horizontal");
    

        Vector3 move = context.transform.right * x + context.transform.forward * speedboost;
        

        context.controller.Move(move * context.speed * Time.deltaTime);
    }

}
