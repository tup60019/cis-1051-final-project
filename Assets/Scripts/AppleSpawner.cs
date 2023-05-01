using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;
    private float xVel;
    private float yVel = 300;
    public GameObject tooltip;
    public ClimberController climber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowApple());
    }

    private void Update()
    {

        if (!climber.climberIsAlive)
        {
            StopAllCoroutines();
        }
    }

    IEnumerator ThrowApple()
    {
        tooltip.SetActive(true);
        yield return new WaitForSeconds(3);
        tooltip.SetActive(false);

        for(int i = 0; i < 10; i++)
        {
            xVel = Random.Range(50, 300);
            GameObject ball = Instantiate(apple, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(xVel, yVel));
            yield return new WaitForSeconds(2);
        }
        
    }
}
