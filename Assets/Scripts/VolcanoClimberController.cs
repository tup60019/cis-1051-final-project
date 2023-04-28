using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoClimberController : MonoBehaviour
{
    public ClimberController climber;
    private bool CtoL;
    private bool LtoC;
    private Animator animator;
    private float timer;
    public MainManager mainManager;
    public float immunity = 0;
    public GameObject deadClimber;
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
        if (climber.climberIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                CtoL = true;
                timer = 0.2f;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0)
            {
                CtoL = false;
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                CtoL = false;
            }
            
            if (Input.GetKeyDown(KeyCode.D))
            {
                LtoC = true;
                timer = 0.2f;
            }
            if (timer > 0)
            {
                timer -= Time.deltaTime;

            }
            else if (timer <= 0)
            {
                LtoC = false;
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                LtoC = false;
            }
            if (immunity > 0)
            {
                immunity -= Time.deltaTime;
            }

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
        }


    }
}
