using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafix : MonoBehaviour
{
    public GameObject MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
       MainCamera.transform.localEulerAngles = new Vector3(MainCamera.transform.localEulerAngles.x, 0, 0);

    }
}
