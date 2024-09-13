using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    Animator PlayerAnimator;

    private void Awake()
    {
        PlayerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        PlayerAnimator.SetBool("Walk", Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D));

        PlayerAnimator.SetBool("Running", Input.GetKey(KeyCode.LeftShift));

        PlayerAnimator.SetBool("Jump", Input.GetKey(KeyCode.Space));

        PlayerAnimator.SetBool("JumpAnimation", PlayerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"));

        

    }
}
