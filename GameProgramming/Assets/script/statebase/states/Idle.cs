using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
    public Context context;


    public override void Start(Context context){
        this.context = context;

        if(Cursor.visible){
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    
    public override void run(){
       if(checkmovement()){
            context.Change(new Movement());
        }
        if(jump()){
            context.Change(new Jumping());
        }
        if(!isGrounded(context.controller)){
            context.Change(new Falling());
        }
        look(context);
    }
    
}
