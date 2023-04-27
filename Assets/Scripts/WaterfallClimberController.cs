using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterfallClimberController : MonoBehaviour
{
    public GameObject punchBox;
    public MainManager mainManager;
    private bool punchCooldown = false;
    public ClimberController climber;
    public float redTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (climber.climberIsAlive)
        {
            if (Input.GetKeyDown(KeyCode.Space) && punchCooldown == false)
            {
                StartCoroutine(Punch());
            }
        }
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
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
    }
    IEnumerator Punch()
    {
        punchBox.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        punchBox.SetActive(false);

    }
}
