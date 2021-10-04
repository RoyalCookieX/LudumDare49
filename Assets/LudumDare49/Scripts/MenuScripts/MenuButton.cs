using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] MenuButtonController menuButtonController;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorFunction animatorFunction;
    [SerializeField] int thisIndex;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (menuButtonController.index == thisIndex)
        {
            animator.SetBool("Selected", true);
            if (Input.GetAxis("Submit") == 1)
            {
                animator.SetBool("Pressed", true);
            }
            else if (animator.GetBool("Pressed"))
            {
                animator.SetBool("Pressed", false);
                animatorFunction.disableOnce = true;
            }
        }
    }
}
