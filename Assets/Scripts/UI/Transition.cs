using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public Animator animator;

    public void AnimateIn() {
        animator.SetTrigger("In");
    }
}
