using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class Game : MonoBehaviour
{
    
    public List<GameObject> prefabs = new List<GameObject>(); // Reference to the prefab you want to spawn
    public Transform spawnPoint; // Reference to the position where the prefab should be spawned
    public GameObject Table; // Reference to the position where the prefab get below than the game resets
    public Transform GameTransform; // Reference to the position where game takes place
    private List<PlayerMovement> Blocks = new List<PlayerMovement>();
    private List<GameObject> GameObjects = new List<GameObject>();
    
    public bool GameRunning = false;
    public bool gamePauze = false;

    public SceneSwapping Swapping;
    private List<Color> spawnColors = new List<Color>() {Color.blue, Color.green, Color.red, Color.yellow, Color.cyan, Color.magenta}; // Color to apply to the spawned prefab


    // Start is called before the first frame update
    void Start()
    {
         Instantiate(Table, spawnPoint.position, spawnPoint.rotation);
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
        if(Swapping.GameOverLay.enabled)
        {
            //set camar
            if(GameRunning)
            {
                if(Blocks.Any())
                {
                    var maxheigt = Blocks.Max(A => A.GetCamaraheigt());
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
                
                
                if (Input.GetKeyDown(KeyCode.Escape) )
                {
                    
                    if(!gamePauze)
                    {
                        TurnGameOff();
                        Swapping.PauzeMenuScreen();   
                        
                    }
                    else
                    {
                        Swapping.Resume();
                        
                    }
                    
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    
                    Swapping.ResetGame();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
                {
                    Swapping.ResetGame();
                    Debug.Log(true);
                    
                }
        }
    }
    public void TurnGameOff()
    {
        gamePauze = true;
        
        Blocks.ForEach(A => A.simulated(false));

    }
    public void TurnGameonn()
    {
        gamePauze = false;
        
        Blocks.ForEach(A => A.simulated(true));

    }

    public void ResetGame()
    {
        if(GameObjects.Count != 0)
        {
            GameObjects.ForEach(A => Destroy(A));
            
            
        }
        Blocks = new List<PlayerMovement>();
        GameObjects = new List<GameObject>();
        GameRunning = true;
        gamePauze = false;
    }

    public int GetMaxheigt()
    {
        if(Blocks.Count <= 1)
        {
            return 0;
        }
        return (int)Blocks.Take(Blocks.Count - 1).Max(A => A.Getheigt()) + 12;
    }
    public float GetTotalBlocks()
    {
        return Blocks.Count - 1;
    }

}
