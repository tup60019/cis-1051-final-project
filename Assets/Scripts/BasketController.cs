using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public GameObject Climber;
    // Start is called before the first frame update
    void Start()
    {
        Climber = GameObject.Find("Climber");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        transform.position = Climber.transform.position + new Vector3(0, 0.7f, 0);
    }
}
