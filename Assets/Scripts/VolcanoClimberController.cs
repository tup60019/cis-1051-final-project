using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoClimberController : MonoBehaviour
{
    public ClimberController climber;
    private bool CtoL;
    private bool LtoC;
    private bool Left;
    private bool Right;
    private bool Center;
    private Animator animator;
    private float timer;
    public MainManager mainManager;
    public float immunity = 0;
    public GameObject deadClimber;
    public float redTime;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("CtoL", CtoL);
        animator.SetBool("LtoC", LtoC);
        animator.SetBool("Left", Left);
        animator.SetBool("Right", Right);
        animator.SetBool("Center", Center);
        if (climber.climberIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CtoL = true;
                Left = true;
                timer = 0.2f;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0)
            {
                CtoL = false;
                Left = false;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                CtoL = false;
                Left = false;
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                LtoC = true;
                Center = true;
                timer = 0.2f;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0)
            {
                LtoC = false;
                Center = false;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                LtoC = false;
                Center = false;
            }
            if (immunity > 0)
            {
                immunity -= Time.deltaTime;
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
        if (!climber.climberIsAlive)
        {
            for (int i = 0; i<1; i++)
            {
                Instantiate(deadClimber, transform.position, transform.rotation);
            }
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("VolcanoAttack") && immunity <= 0)
        {
            mainManager.mistakes++;
            immunity = 1.5f;
            redTime = 1.5f;
        }


    }
}
