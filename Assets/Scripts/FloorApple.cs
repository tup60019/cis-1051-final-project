using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorApple : MonoBehaviour
{
    public MainManager mainManager;
    public ClimberController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            mainManager.mistakes++;

        }

    }
}
