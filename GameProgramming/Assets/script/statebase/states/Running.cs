using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running : State
{
    public Context context;
   public override void Start(Context context){
        this.context = context;
    }
    public override void run(){
         look(context);
    }

}
