using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public abstract  class State 
{
    public abstract  void Start(Context context);
    public abstract  void run();


     protected bool checkmovement(){
        bool x = Input.GetAxis("Horizontal")== 0;
        bool z = Input.GetAxis("Vertical") == 0;
       if(x && z){
        return false;
       }
       return true;
    }

    
    protected bool jump(){
         if(Input.GetButtonDown("Jump") ){
            return true;
        }
        return false;
    }
    protected bool isGrounded(CharacterController controller){
        if(Physics.Raycast(controller.transform.position, Vector3.down, 1.09f)){ return true;}

        float extentie = 0.5f;
        if(Physics.Raycast(controller.transform.position - new Vector3(extentie, 0, 0), Vector3.down, 1.09f)){ return true;}
        if(Physics.Raycast(controller.transform.position - new Vector3(-extentie, 0, 0), Vector3.down, 1.09f)){ return true;}

        if(Physics.Raycast(controller.transform.position - new Vector3(0, 0, extentie), Vector3.down, 1.09f)){ return true;}
        if(Physics.Raycast(controller.transform.position - new Vector3(0, 0, -extentie), Vector3.down, 1.09f)){ return true;}
        return false;
    }


   

    protected void look(Context context)
    {
        
        float mouseX = Input.GetAxis("Mouse X") * context.mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * context.mouseSensitivity * Time.deltaTime;

        //context.xRotation -= mouseY;
        //context.xRotation = Mathf.Clamp(context.xRotation, -90f, 90f);
           
        //context.camera.transform.localRotation = Quaternion.Euler(context.xRotation, 0f, 0f);
        
        context.transform.Rotate(Vector3.up * mouseX);
        
      
        
    }
    
}
