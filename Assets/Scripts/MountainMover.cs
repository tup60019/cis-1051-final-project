using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class MountainMover : MonoBehaviour
{
    public float mountainSpeed = 0.4f;
    public GameObject mountains;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        mountains.transform.Translate(Vector2.down * mountainSpeed * Time.deltaTime);
    }
}
