using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LeverController : MonoBehaviour
{
    public XRLever lever;
    public ForkliftController forklift;

    public GearStatus gearStaus = GearStatus.nutral;



    // Start is called before the first frame update
    void Start()
    {
        
    }

   
    void Update()
    {

        float gearStaus = lever.value ? 1 : 0;



        if(gearStaus == 1)
        {
            forklift.setReverseMode(false);
        }
        else
        {
            forklift.setReverseMode(true);
        }
    }
}
