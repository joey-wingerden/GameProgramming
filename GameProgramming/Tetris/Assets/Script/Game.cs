using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    
    public List<GameObject> prefabs = new List<GameObject>(); // Reference to the prefab you want to spawn
    public Transform spawnPoint; // Reference to the position where the prefab should be spawned
    public Transform Table; // Reference to the position where the prefab get below than the game resets
    public Transform GameTransform; // Reference to the position where game takes place
    private List<PlayerMovement> Blocks = new List<PlayerMovement>();
    private List<GameObject> GameObjects = new List<GameObject>();
    
    private List<Color> spawnColors = new List<Color>() {Color.blue, Color.green, Color.red}; // Color to apply to the spawned prefab


    // Start is called before the first frame update
    void Start()
    {
        SpawnPrefab();
    }
    public void SpawnPrefab()
    {
        // Instantiate the prefab at the specified spawn point
        var prefab = prefabs[UnityEngine.Random.Range(0, prefabs.Count)];
        var gameobject = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        // Change the color of the spawned prefab
        ChangePrefabColor(gameobject);

        GameObjects.Add(gameobject);
        Blocks.Add(gameobject.GetComponent<PlayerMovement>());  
    }

    private void ChangePrefabColor(GameObject prefab)
    {
        // Get all Renderer components of the prefab
        Renderer[] renderers = prefab.GetComponentsInChildren<Renderer>();
        var color = spawnColors[UnityEngine.Random.Range(0, spawnColors.Count)];
        // Change the color of each Renderer component
        foreach (Renderer renderer in renderers)
        {
            renderer.material.color = color; //spawnColors[UnityEngine.Random.Range(0, spawnColors.Count)];
        }
    }
    // Update is called once per frame
    void Update()
    {
        //set camara
        if(Blocks.Any())
        {
            var maxheigt = Blocks.Max(A => A.Getheigt());
            GameTransform.position = new Vector3(0, maxheigt); 
        }else
        {
            GameTransform.position = new Vector3(0, 0); 
        }
        
        
        //spawn new block
        if(!Blocks.Any(A => !A.isGrounded))
        {
            SpawnPrefab();
        }
        

        if(Blocks.Any(A => A.GetBelow(Table.position.y)))
        {
            //ResetGame();
        }
    }

    public void ResetGame()
    {
        GameObjects.ForEach(A => Destroy(A));
        Blocks = new List<PlayerMovement>();
        GameObjects = new List<GameObject>();
    }

}
