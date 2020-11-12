using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public GameObject model;
    Animator animator;

    private void Start()
    {
        animator = model.GetComponent<Animator>();
    }

    public void BeginAnimation()
    {
        //animator.SetInteger("State", 0);
        animator.Play("Standing Up", -1, 0f);
    }

    public void StopAnimation()
    {
        //animator.SetInteger("State", 0);
        //audioSource.Stop();
        //audioSource.PlayOneShot(targetLost);
    }
}
