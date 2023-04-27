using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SheepMove : MonoBehaviour
{
    private float speed = 8f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }


}
