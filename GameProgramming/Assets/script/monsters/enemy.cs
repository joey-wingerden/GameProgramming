using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]public moster monster;

    public int currenthp;

    // Start is called before the first frame update
    void Start()
    {
        monster.hp -= currenthp;
        Debug.Log(monster.hp);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
