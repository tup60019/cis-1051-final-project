using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimberController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizInput;
    public GameObject basket;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizInput = Input.GetAxis("Horizontal");
        transform.Translate(horizInput * Vector2.right * speed * Time.deltaTime);
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spriteRenderer.color = Color.yellow;
            GameObject bascet = Instantiate(basket, transform.position, transform.rotation);
            StartCoroutine(Colorer());

        }


    }
    IEnumerator Colorer()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = Color.green;
        GameObject bascet = GameObject.Find("Basket(Clone)");
        Destroy(bascet);
    }
}
