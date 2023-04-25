using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MountainClimberController : MonoBehaviour
{
    public ClimberController climber;
    public MainManager mainManager;
    public float horizInput;
    private int climbSpeed = 10000;
    private float rBound = 4.5f;
    private float lBound = -4.5f;
    public string climberPos = "C";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizInput = Input.GetAxis("Horizontal");
        if (climber.climberIsAlive)
        {

            transform.Translate(horizInput * Vector2.right * climbSpeed * Time.deltaTime);
            if (transform.position.x >= rBound)
            {
                transform.position = new Vector3(rBound, transform.position.y, transform.position.z);
                climberPos = "R";
            }

            if (transform.position.x <= lBound)
            {
                transform.position = new Vector3(lBound, transform.position.y, transform.position.z);
                climberPos = "L";
            }


        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Boulder(Clone)")
        {
            mainManager.mistakes++;
        }
    }
}
