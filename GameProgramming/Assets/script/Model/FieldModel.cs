using System;
using System.Collections.Generic;

public class FieldModel
{
    private float Counter = 0f;
    public readonly float id;
    public readonly float Row;
    public readonly float Colum;
    public readonly List<bool> list;
    public FieldModel(float Row, float Colum, List<bool> list)
    {
        id = Counter;
        Counter++;
        
        this.Row = Row;
        this.Colum = Colum;
        this.list = list;
    }
    private FieldModel(float Row, float Colum, List<bool> list, float id)
    {
        this.id = id;
        this.Row = Row;
        this.Colum = Colum;
        this.list = list;
    }

    public static FieldModel getBlank(float Row, float Colum)
    {
        List<bool> list = new List<bool>();
        for (int i = 0; i < Math.Round(Row * Colum, 0); i++)
        {
            list.Add(false);
        }
        return new FieldModel( (float)Math.Round(Row, 0),   (float)Math.Round(Colum, 0),  list, -1);
    }
}