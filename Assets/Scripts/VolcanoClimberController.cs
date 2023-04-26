using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanoClimberController : MonoBehaviour
{
    public ClimberController climber;
    private bool CtoL;
    private Animator animator;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("CtoL", CtoL);
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
        }
    }
}
