using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishThrower : MonoBehaviour
{
    public int fishType = 0;
    
    public GameObject Fish;
    public GameObject Bombfish;


    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ThrowFish());
    }


    IEnumerator ThrowFish()
    {
        GameObject[] possibleFish = { Fish, Bombfish };
        for (int i = 0; i < 10; i++)
        {
            fishType = Random.Range(0, 2);
            GameObject chosenFish = Instantiate(possibleFish[fishType], transform.position, transform.rotation);
            chosenFish.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-400, 300));
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
