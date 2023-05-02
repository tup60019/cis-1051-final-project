using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcAnim : MonoBehaviour
{
    private Animator animator;
    public VolcanoBossScript v;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("attacking", v.attacking);
        animator.SetBool("ded", v.ded);
    }
}
