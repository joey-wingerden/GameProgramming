using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Field field;
    private List<FieldModel> fieldModels = new List<FieldModel>();

    private int Counter
    {
        get 
            {
                if(Generaties.value > fieldModels.Count() - 1)
                {
                    Counter = 0;
                    return 0;
                }
                return (int)Generaties.value;
            }
        set 
            {
                Generaties.maxValue = fieldModels.Count() - 1;
                Generaties.value += value; 
                
            }
    }


    public InputField Rows;
    public InputField Colums;

    public Slider Generaties;

    public void Start(){
        Rows.text = "" + field.Rows;
        Colums.text = "" + field.Colums;

        field.start();

        NewField();
    }

    private bool timerLoopt = false;
    private float time = 0;
    private float timer = 0;
    public void Update(){
        if(timerLoopt){
            time += Time.deltaTime;
            if(time > timer){
                time -= timer;
                nextGeneratie();
            }
        }
    }



    public void nextGeneratie()
    {
        AddField(field.GetFieldModel());
        AddField(field.newGeneratie());
        Counter = fieldModels.Count() - 1;
        
        field.SetBuildField(fieldModels[Counter]);
    }
    public void GoBack()
    {
        Counter--;
        if(Counter < 0){Counter = 0;}
        else{
             field.SetBuildField(fieldModels[Counter]);
        }
    }
    public void Next()
    {
        Counter ++;
        if(Counter >= fieldModels.Count()){nextGeneratie();}
        else{
             field.SetBuildField(fieldModels[Counter]);
        }
    }

    public void NewField(){
        AddField(FieldModel.getBlank(float.Parse(Rows.text), float.Parse(Colums.text)));
        Counter = fieldModels.Count() - 1;
        field.SetBuildField(fieldModels[Counter]);
    }
    private bool AddField(FieldModel newfield){
        if(fieldModels.Count() == 0){
            fieldModels.Add(newfield);
            return true;
        }
        var old = fieldModels[fieldModels.Count() -1];
        if(old.Colum == newfield.Colum && old.Row == newfield.Row){
            for (int i = 0; i < newfield.list.Count(); i++)
            {
                if(newfield.list[i] != old.list[i]){
                    fieldModels.Add(newfield);
                    return true;
                }
            }
            return false;
        }
        fieldModels.Add(newfield);
        return true;
    }

    public void SliderChange(float value){
        field.SetBuildField(fieldModels[Counter]);
    }

    public void ClearHistory(){
        var F = fieldModels[Counter];
        fieldModels.Clear();
        fieldModels.Add(F);
        Counter = fieldModels.Count();
    }

    public Text AutomatischT;
    private float setting = 0;

    public void Automatisch(){
        setting ++;
        switch (setting)
        {
            case 1: 
                AutomatischT.text = "Automatisch (1S)";
                timerLoopt = true;
                timer = 1;
                break;
            case 2: 
                AutomatischT.text = "Automatisch (2S)";
                timer = 2;
                break;
            case 3: 
                AutomatischT.text = "Automatisch (5S)";
                timer = 5;
                break;
            case 4: 
                AutomatischT.text = "Automatisch (10S)";
                timer = 10;
                break;
            default: 
                AutomatischT.text = "Automatisch (off)";
                timerLoopt = false;
                time = 0;
                setting = 0;
                break;
        }
        
    }



 
    

    
}