using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class game : MonoBehaviour
{
    public GameObject prefab;
    public Bots bots;
    public MouseLocationMovementScript mouseLocationMovementScrip;

    private GameObject player;
    private PLayer playerscript;
    // Start is called before the first frame update
    void Start()
    {
        spawnprefab();
    }

    public void spawnprefab()
    {
        player = Instantiate(prefab, new Vector3(-53f, 0f, 21f), new Quaternion());
        mouseLocationMovementScrip.agent = player.GetComponentInChildren<NavMeshClient>();
        player.transform.parent = gameObject.transform;
        playerscript = player.GetComponent<PLayer>();
        playerscript.Game = this;
    }
    // Update is called once per frame
    void Update()
    {
        var ren = playerscript.body.GetComponent<Renderer>();
        if(bots.AllPLAYERinRange)
        {
           ren.material.color = Color.yellow;
        }
        else
        {
            ren.material.color = Color.gray;
        }
    }
}
