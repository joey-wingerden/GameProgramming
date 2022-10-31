using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Field : MonoBehaviour
{
    public GameObject Prefab;


    public float Rows = 20;
    public float Colums = 20;

    public RectTransform FieldObject;

    private float With;
    private float Height;

    private RectTransform T;


    

    private List<Clicked> field = new List<Clicked>();

    // Start is called before the first frame update
    public void start()
    {
        T = GetComponent<RectTransform>();
        Setup();

        BuildField();
    }

    private void Setup(){
        With = T.sizeDelta.x - FieldObject.localPosition.x * 2;
        Height = T.sizeDelta.y;
    }
    void Update()
    {
        if (With != T.sizeDelta.x || Height != T.sizeDelta.y){ 
                Setup();
                BuildFieldResize();
            }
    }
    

    private void BuildField(){
        bool Grey = false;

        for (int X = 0; X < Rows; X++)
        {
             for (int Y = 0; Y < Colums; Y++)
                {
                    field.Add(CreateMesh(getPosition(X,Y), getScale(), Grey, X, Y));
                    if(Grey){ Grey = false;}
                    else{Grey = true;}
                }
            if(Grey){ Grey = false;}
            else{Grey = true;}
        }
    }

    private void BuildFieldResize(){
        foreach(var item in field)
        {
            item.Setup(getPosition( item.Row, item.Colum), getScale());
        }
    }
    
    public FieldModel newGeneratie(){
        var list = new List<bool>();
        foreach(var item in field)
        {
            list.Add( item.newGeneratie(getAliveList( item.Row, item.Colum)));
        }
        return new FieldModel(Rows, Colums, list);
    }

    private List<bool> getAliveList(float Row, float Colum){
        List<bool> list = new List<bool>();
        for (int X = -1; X < 2; X++)
        {
             for (int Y = -1; Y < 2; Y++)
                {
                    if(X != 0 || Y != 0){
                        list.Add (GetAlive(Row + X, Colum + Y));
                    }
                }
        }
        return list;
    }

    private bool GetAlive(float Row, float Colum){
        if(Row >= Rows || Colum >= Colums  || Row < 0 || Colum < 0){
            return false;
        }
        float index = (Row*  (Colums) + Colum);
        return field[(int)index].Alive;
    }


    public void SetBuildField(FieldModel model){
        if(this.Rows != model.Row || this.Colums != model.Colum)
        {
            this.Rows = model.Row;
            this.Colums = model.Colum;
            DestroyField();
            BuildField();
        }
    

        for (int i = 0; i < field.Count(); i++)
        {
            field[i].Alive = model.list[i];
        }
    }

    public FieldModel GetFieldModel(){
        var list = new List<bool>();
        foreach(var item in field)
        {
            list.Add(item.Alive);
        }
        return new FieldModel(Rows, Colums, list);
    }

    public void DestroyField(){
        foreach(var item in field)
        {
            item.delete();
        }
        field.Clear();
    }

    private Vector3 getPosition(float X, float Y){
        return new Vector3(
            (X - (Rows - 1) / 2) * getScaleX(), 
            (Y - (Colums - 1) / 2) * getScaleY());
    }
    private Vector2 getScale(){
        return new Vector2(getScaleX(), getScaleY());
    }
    private float getScaleX(){
        return With / Rows;
    }
    private float getScaleY(){
        return Height / Colums;
    }

    private Clicked CreateMesh(Vector3 Position, Vector2 Scale, bool Grey, float Rows, float Colum){
        var mesh = Instantiate(Prefab, Position, transform.rotation);  
        mesh.transform.SetParent(FieldObject); 
        return mesh.GetComponent<Clicked>().Setup(Position, Scale, Grey, Rows, Colum);
    }


}
