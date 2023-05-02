using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BoulderSpawner : MonoBehaviour
{
    public GameObject L;
    public GameObject R;
    public GameObject boulder;
    public MountainMover mountainMover;
    public GameObject mountains;
    public GameObject volcano;
    public MainManager mainManager;
    public CameraMovement cam;
    public GameObject tooltip;
    public ClimberController climber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBoulders());
    }

    private void Update()
    {
        if (!climber.climberIsAlive)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator SpawnBoulders()
    {
        tooltip.SetActive(true);
        yield return new WaitForSeconds(3);
        tooltip.SetActive(false);

        for (int y = 0; y < 32; y++)
        {
            GameObject[] spawnLoc = { L, R,};
            int i = Random.Range(0, 2);
            Instantiate(boulder, spawnLoc[i].transform.position, spawnLoc[i].transform.rotation);
            yield return new WaitForSeconds(0.3f);
        }
        yield return new WaitForSeconds(1);
        mountainMover.mountainSpeed = 1.6f;
        mainManager.cameraPos = 24.8f;
        cam.camSpeed = 1.0f;   
        
        
        yield return new WaitForSeconds(7);
        volcano.SetActive(true);
        yield return new WaitForSeconds(3);

        mountains.SetActive(false);
        
    }
}