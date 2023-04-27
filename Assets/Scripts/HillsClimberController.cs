using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillsClimberController : MonoBehaviour
{
    public float cooldown;
    public ClimberController climber;
    public Animation duck;
    public MainManager mainManager;
    public float redTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        cooldown = -1;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (climber.climberIsAlive)
        {
            
            if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
            {
                GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0, 1000));
                cooldown = 0.71f;
                
            }
            if (cooldown > 0)
            {
                cooldown -= Time.deltaTime;
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                duck.Play();
            }
            
        }
        //on hit red effect REMEMBER TO INCLUDE i IN COLLISION
        if (redTime > 0)
        {
            Color c = GetComponent<SpriteRenderer>().color = Color.red;
            
        }
        redTime -= Time.deltaTime;
        if (redTime <= 0)
        {
            Color g = GetComponent<SpriteRenderer>().color = Color.white;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("HillsEnemy"))
        {
            mainManager.mistakes++;
            redTime = 0.7f;
        }
    }
}
