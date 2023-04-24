using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FishThrower : MonoBehaviour
{
    public int fishType = 0;
    
    public GameObject Fish;
    public GameObject Bombfish;
    public MainManager mainManager;
    public GameObject mountains;
    public GameObject waterfall;

    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(ThrowFish());
    }


    IEnumerator ThrowFish()
    {
        GameObject[] possibleFish = { Fish, Bombfish };
        for (int i = 0; i < 32; i++)
        {
            fishType = Random.Range(0, 2);
            GameObject chosenFish = Instantiate(possibleFish[fishType], transform.position, transform.rotation);
            chosenFish.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-400, 300));
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1);
        mainManager.cameraPos = 20f;
        yield return new WaitForSeconds(3);
        waterfall.SetActive(false);
        mountains.SetActive(true);
    }
}
