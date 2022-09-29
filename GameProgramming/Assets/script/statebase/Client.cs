using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Cinemachine;

public class Client : MonoBehaviour
{
    private Context context;

    public Camera camera;
    public CharacterController characterController;
    // CinemachineVirtuakCamara cinemachineVirtuakCamara;'

    public Text tekst;


    public string contextname;
    // Start is called before the first frame update
    void Start()
    {
        context = new Context(new Idle(),  characterController,  transform, camera);
        context.Start();
    }

    // Update is called once per frame
    void Update()
    {
        context.run();

        tekst.text = "state = " + context.state.ToString();
    }
}
