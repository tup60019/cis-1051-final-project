using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class VolcanoBossScript : MonoBehaviour
{
    public GameObject lavaHitbox;
    public GameObject climber;
    public GameObject fireBall;
    private float xVel;
    private float yVel = 400;
    public int direction;
    public GameObject tooltip;
    public ClimberController climberController;
    public bool ded = false;
    public GameObject volc;
    private float dedSpeed = 4;
    public bool attacking;
    public GameObject win;
    void Start()
    {

        StartCoroutine(AttackSequence());
    }


    void Update()
    {
        if (!climberController.climberIsAlive)
        {
            StopAllCoroutines();
        }
        if (ded)
        {
            volc.transform.Translate(Vector2.down * Time.deltaTime * dedSpeed);
        }
    }

    IEnumerator AttackSequence()
    {
        tooltip.SetActive(true);
        yield return new WaitForSeconds(5);
        tooltip.SetActive(false);
        
        StartCoroutine(Fireballs());
        yield return new WaitForSeconds(6);
        StartCoroutine(TrackingLava());
        yield return new WaitForSeconds(5);
        /*
        StartCoroutine(Fireballs());
        yield return new WaitForSeconds(6);
        StartCoroutine(TrackingLava());
        yield return new WaitForSeconds(5);
        StartCoroutine(Fireballs());
        yield return new WaitForSeconds(6);
        StartCoroutine(TrackingLava());
        yield return new WaitForSeconds(5);
        StartCoroutine(Fireballs());
        yield return new WaitForSeconds(6);
        StartCoroutine(TrackingLava());
        yield return new WaitForSeconds(5);
        */
        ded = true;
        yield return new WaitForSeconds(7);
        win.SetActive(true);
    }
    public IEnumerator TrackingLava()
    {
        
        yield return new WaitForSeconds(1);
        attacking = true;
        GameObject wall = Instantiate(lavaHitbox, climber.transform.position + new Vector3(0, 50, -7), climber.transform.rotation);
        yield return new WaitForSeconds(3);
        attacking = false;
        yield return new WaitForSeconds(2);
        
        Destroy(wall);
    }

    public IEnumerator Fireballs()
    {
        attacking = true;
        //int direction 0 = L 1=C 2=R
        for (int i = 0; i < 10; i++)
        {
            direction = Random.Range(0, 3);
            if (direction == 0)
            {
                xVel = -250;
            }
            else if (direction == 1)
            {
                xVel = 0;
            }
            else if (direction == 2)
            {
                xVel = 250;
            }

            GameObject ball = Instantiate(fireBall, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xVel, yVel));
            yield return new WaitForSeconds(0.5f);

        }
        attacking = false;

    }
}
