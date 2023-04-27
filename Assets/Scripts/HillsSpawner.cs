using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class HillsSpawner : MonoBehaviour
{
    private MainManager mainManager;
    public GameObject hills;
    public GameObject waterfall;
    public GameObject birdL;
    public GameObject birdR;
    private float[] xSpawn;
    public GameObject[] birds;
    private int z;
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        xSpawn = new float[2];
        xSpawn[0] = transform.position.x;
        xSpawn[1] = transform.position.x * -1;
        birds = new GameObject[2];
        birds[0] = birdL;
        birds[1] = birdR;
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
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 9; i++) 
        {
            y = Random.Range(0, 2);
            if (y == 0)
            {
                z = 0;
            }
            else if (y == 1)
            {
                z = 1;
            }
            Instantiate(birds[z], new Vector3(xSpawn[y], transform.position.y, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(4.5f);
        }


        //everything after this is transition



        yield return new WaitForSeconds(1);
        mainManager.cameraPos = 11f;
        yield return new WaitForSeconds(3);
        waterfall.SetActive(true);
        hills.SetActive(false);

    }
}
