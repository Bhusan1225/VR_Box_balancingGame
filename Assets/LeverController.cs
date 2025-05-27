using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    public Transform lever;
    [SerializeField] private float forwardBackwardTilt = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        forwardBackwardTilt =lever.rotation.eulerAngles.y;
        if (forwardBackwardTilt > 355 && forwardBackwardTilt >290)
        {
            forwardBackwardTilt =Mathf.Abs(forwardBackwardTilt- 360);
            Debug.Log("backward"+forwardBackwardTilt);
        }
        else if (forwardBackwardTilt > 5 && forwardBackwardTilt < 74)
        {
            Debug.Log("forward" + forwardBackwardTilt);
        }
       
        }
}
