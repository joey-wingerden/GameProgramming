using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Clicked : MonoBehaviour
{
    private bool alive = false;
    public bool Alive
        {
            get 
            {
                return alive;
            }
            set 
            {
                alive = value; 
                SetColor();
            }
        }



    private bool Grey;

    public float Row;
    public float Colum;

    
    public Clicked Setup(Vector3 Position, Vector2 Scale, bool Grey, float Row, float Colum){
        this.Grey = Grey;
        this.Row = Row;
        this.Colum = Colum;

        return Setup(Position, Scale);
    }

    public Clicked Setup(Vector3 Position, Vector2 Scale){
        var T = GetComponent<RectTransform>();

        T.sizeDelta = Scale;
        T.localPosition = Position;

        SetColor();
        return this;
    }

    public void SwitchAlive(){
        if(Alive){
            Alive = false;
        }else{
             Alive = true;
        }
    }

    private void SetColor(){
        var matrial = GetComponent<Image>();
        if(!Alive){
            if(Grey){
                matrial.color = new Color(0.9f, 0.9f, 0.9f, 1);
            }else{
                matrial.color = Color.white;
            }
        }else{
            if(Grey){
                matrial.color = new Color(0.1f, 0.1f, 0.1f, 1);
            }else{
               matrial.color = Color.black;
            }
        }
    }

    public bool newGeneratie(List<bool> list){
        float Alive = list.Count(a => a);

        if(alive){
            //solitude
            if(Alive <= 1){ return  false;}

            //overpopulation
            if(Alive >= 4){ return  false;}

            return true;
        }else{
            //populate
            if(Alive == 3){ return  true;}

            return false;
        }
        
    }
    

    public void delete(){
        Destroy(gameObject);
    }

    

  
}
