using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TH_PlayerAnimatorController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }
}
