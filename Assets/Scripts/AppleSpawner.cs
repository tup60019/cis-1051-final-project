using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;
    private float xVel;
    private float yVel = 300;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowApple());
    }



    IEnumerator ThrowApple()
    {
        for(int i = 0; i < 8; i++)
        {
            xVel = Random.Range(50, 300);
            GameObject ball = Instantiate(apple, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xVel, yVel));
            yield return new WaitForSeconds(2);
        }
        
    }
}
