using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : State
{
    public Context context;
    

    public override void Start(Context context){
        this.context = context;
        
        jump(3);
    }
    public override void run(){
       context.Change(new Falling());
    }

    
    public void jump(float jumpHeigt){  
        context.velocity.y = (float)Math.Sqrt(jumpHeigt * -2f * context.gravity);  
        context.controller.Move(context.velocity * Time.deltaTime); 
    }


    
    

}
