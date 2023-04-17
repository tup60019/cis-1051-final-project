using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClimberController : MonoBehaviour
{
    public float speed = 5.0f;
    public float horizInput;
    public GameObject basket;
    public bool climberIsAlive = true;
    public MainManager mainManager;
    public bool onCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        horizInput = Input.GetAxis("Horizontal");
        if (climberIsAlive)
        {
            transform.Translate(horizInput * Vector2.right * speed * Time.deltaTime);
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

            if (Input.GetKeyDown(KeyCode.Space) && onCooldown == false)
            {

                GameObject bascet = Instantiate(basket, transform.position, transform.rotation);
                StartCoroutine(Basket());
                StartCoroutine(BasketCooldown());

            }
        }



    }
    IEnumerator Basket()
    {

        yield return new WaitForSeconds(0.5f);

        GameObject bascet = GameObject.Find("Basket(Clone)");
        Destroy(bascet);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Apple(Clone)")
        {

            mainManager.mistakes++;

        }
    }
    IEnumerator BasketCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(0.7f);
        onCooldown = false;
    }
}
