using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private AudioSource bonk;

    private void Start()
    {
        bonk = GetComponent<AudioSource>();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        bonk.Play();
        Destroy(gameObject);
        
    }
}
