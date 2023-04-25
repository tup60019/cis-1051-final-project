using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject L;
    public GameObject R;
    public GameObject boulder;
    public MountainMover mountainMover;
    public GameObject mountains;
    public GameObject volcano;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBoulders());
    }

    // Update is called once per frame

    IEnumerator SpawnBoulders()
    {
        for (int y = 0; y < 32; y++)
        {
            GameObject[] spawnLoc = { L, R,};
            int i = Random.Range(0, 2);
            Instantiate(boulder, spawnLoc[i].transform.position, spawnLoc[i].transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1);
        mountainMover.mountainSpeed = 1.6f;
        yield return new WaitForSeconds(10);
        
        
        volcano.SetActive(true);
        mountains.SetActive(false);
    }
}