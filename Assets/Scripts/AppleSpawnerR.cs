using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppleSpawnerR : MonoBehaviour
{
    private float xVelR;
    private float yVelR = 300;
    public GameObject apple;
    public MainManager mainManager;
    void Start()
    {
        StartCoroutine(ThrowAppleR());
        
    }


    IEnumerator ThrowAppleR()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < 8; i++)
        {
            
            xVelR = Random.Range(50, 300);
            xVelR *= -1;
            GameObject ball = Instantiate(apple, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xVelR, yVelR));
            yield return new WaitForSeconds(2);
        }
        yield return new WaitForSeconds(1);
        //do stuff to transition
        mainManager.cameraPos = -2.2f;
        yield return new WaitForSeconds(3);
        GameObject[] toDelete = GameObject.FindGameObjectsWithTag("AppleBasket");
        for (int i = 0; i < toDelete.Length; i++)
        {
            Destroy(toDelete[i]);
        }
        
        
        
    }
}
