using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Split : Obstacle
{
    private Animator animator;

    protected override void Start()
    {
        base.Start();
        animator = GetComponent<Animator>();
        StartCoroutine(SplitStart());
    }

    private IEnumerator SplitStart()
    {
        yield return new WaitForSeconds(1);
        animator.SetTrigger("Split");
    }
}
