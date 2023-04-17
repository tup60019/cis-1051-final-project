using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public MainManager mainManager;
    public float camSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < mainManager.cameraPos)
        {
            transform.Translate(Vector3.forward * camSpeed * Time.deltaTime);
        }
        
    }
}
