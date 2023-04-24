using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : MonoBehaviour
{
    public MainManager mainManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Fish(Clone)")
        {
            GameObject hit = collision.gameObject;
            hit.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(300, 900));
        }
        else if (collision.gameObject.name == "Bombfish(Clone)")
        {
            Destroy(collision.gameObject);
            mainManager.mistakes++;
            //explode
        }
    }
}
