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
    public GameObject hills;
    public GameObject appleBasket;
    public ClimberController climber;
    void Start()
    {
        StartCoroutine(ThrowAppleR());
        
    }

    private void Update()
    {
        if (!climber.climberIsAlive)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator ThrowAppleR()
    {
        yield return new WaitForSeconds(4);
        
        for (int i = 0; i < 10; i++)
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
        yield return new WaitForSeconds(2);
        hills.SetActive(true);

        appleBasket.SetActive(false);
        
        
        /* OLD TRANSITION DO NOT USE IT'S BAD AND INEFFICIENT
        GameObject[] toActivate = GameObject.FindGameObjectsWithTag("Hills");
        for (int i = 0; i < toActivate.Length; i++)
        {
            toActivate[i].SetActive(true);
            Debug.Log("made it");
            Debug.Log(toActivate[i]);
        }
        mainManager.cameraPos = -2.2f;
        yield return new WaitForSeconds(3);
        GameObject[] toDelete = GameObject.FindGameObjectsWithTag("Apple Basket");
        for (int i = 0; i < toDelete.Length; i++)
        {
            Destroy(toDelete[i]);
        }
        */
        
        
    }
}
