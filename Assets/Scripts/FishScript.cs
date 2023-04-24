using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject fish;
    public MainManager mainManager;
    // Start is called before the first frame update
    void Start()
    {
        GameObject m = GameObject.Find("Logic Manager");
        mainManager = m.GetComponent<MainManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 8)
        {
            Destroy(fish);
        }
        if (transform.position.y < -2)
        {
            Destroy(fish);
            if (gameObject.name == "Fish(Clone)")
            {
                mainManager.mistakes++;
            }
        }
    }
}
