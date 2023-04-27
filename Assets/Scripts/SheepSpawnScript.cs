using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepSpawnScript : MonoBehaviour
{
    public GameObject sheepL;
    public GameObject sheepR;
    private float[] xSpawn;
    public GameObject[] sheeps;
    private int z;
    private int y;
    // Start is called before the first frame update
    void Start()
    {
        xSpawn = new float[2];
        xSpawn[0] = transform.position.x;
        xSpawn[1] = transform.position.x * -1;
        sheeps = new GameObject[2];
        sheeps[0] = sheepL;
        sheeps[1] = sheepR;
        StartCoroutine(SheepSpawner());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SheepSpawner()
    {
        for (int i = 0;  i < 14; i++)
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
            Instantiate(sheeps[z], new Vector3(xSpawn[y], transform.position.y, transform.position.z), transform.rotation);
            yield return new WaitForSeconds(3);
        }

    }

}
