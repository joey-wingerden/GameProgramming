using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bots : MonoBehaviour
{
    public bool AllPLAYERinVision;
    public bool AllPLAYERinRange;

    public List<VisionColider> VisionColider = new();
    void Start()
    {
        VisionColider = gameObject.GetComponentsInChildren<VisionColider>().ToList();
    }
    void Update()
    {
        this.AllPLAYERinVision = VisionColider.Any(Colider => Colider.PLAYERinVision);
        this.AllPLAYERinRange = VisionColider.Any(Colider => Colider.PLAYERinRange);
    }
}
