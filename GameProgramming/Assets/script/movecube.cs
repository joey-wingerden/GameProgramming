using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movecube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.anyKeyDown){
        StartCoroutine(fade());
       } 
    }

    IEnumerator fade(){
        for(float R =1f; R >= 0f; R -= 0.1f){
            move(R, R * 10, R * 100);
            yield return new WaitForSeconds(5);
        }
            
        
    }
     public void move(float X, float Y, float Z){
        
        transform.position = new Vector3(X,Y,Z);
     }
}
