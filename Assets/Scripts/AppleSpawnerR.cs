using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawnerR : MonoBehaviour
{
    private float xVelR;
    private float yVelR = 300;
    public GameObject apple;
    void Start()
    {
        StartCoroutine(ThrowAppleR());
    }


    IEnumerator ThrowAppleR()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            
            xVelR = Random.Range(50, 300);
            xVelR *= -1;
            GameObject ball = Instantiate(apple, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xVelR, yVelR));
            yield return new WaitForSeconds(2);
        }

    }
}
