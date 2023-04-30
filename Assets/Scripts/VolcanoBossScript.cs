using System.Collections;
using System.Collections.Generic;
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
    }
    public IEnumerator TrackingLava()
    {
        //play telegraph animation here to signal attack
        yield return new WaitForSeconds(1);
        GameObject wall = Instantiate(lavaHitbox, climber.transform.position + new Vector3(0, 50, -7), climber.transform.rotation);
        yield return new WaitForSeconds(5);
        
        Destroy(wall);
    }

    public IEnumerator Fireballs()
    {
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

    }
}
