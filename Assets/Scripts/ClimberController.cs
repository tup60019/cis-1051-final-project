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
    public float redTime = 0;
    public bool Left = false;
    public bool Right = false;
    public bool Space = false;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // basic character controller from Unity Learn Junior Programmer pathway
        animator.SetBool("Left", Left);
        animator.SetBool("Right", Right);
        animator.SetBool("Space", Space);
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
            if (Input.GetKeyDown(KeyCode.A))
            {
                Left = true;
            }
             if (Input.GetKeyUp(KeyCode.A))
            {
                Left = false;
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Right = true;
            }
             if (Input.GetKeyUp(KeyCode.D))
            {
                Right = false;
            }
            
        }
        if (redTime > 0)
        {
            Color c = GetComponent<SpriteRenderer>().color = Color.red;

        }
        redTime -= Time.deltaTime;
        if (redTime <= 0)
        {
            Color g = GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    

    }
    IEnumerator Basket()
    {
        Space = true;
        yield return new WaitForSeconds(0.5f);
        Space = false;
        GameObject bascet = GameObject.Find("Basket(Clone)");
        Destroy(bascet);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Apple(Clone)")
        {

            mainManager.mistakes++;
            redTime = 0.7f;
        }
    }
    IEnumerator BasketCooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(0.7f);
        onCooldown = false;
        
    }
}
