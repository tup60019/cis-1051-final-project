using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillsSpawner : MonoBehaviour
{
    private MainManager mainManager;
    public GameObject hills;
    public GameObject waterfall;
    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.Find("Logic Manager");
        mainManager = m.GetComponent<MainManager>();
        StartCoroutine(BirdSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    IEnumerator BirdSpawner()
    {
        //spawn your birds here

        //everything after this is transition
        yield return new WaitForSeconds(1);
        mainManager.cameraPos = 11f;
        yield return new WaitForSeconds(3);
        waterfall.SetActive(true);
        hills.SetActive(false);
    }
}
