using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float horizAxis;
    float vertAxis;

    float moveDist;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        moveDist = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

        Translate();
        vertAxis = Input.GetAxisRaw("Vertical");
        horizAxis = Input.GetAxisRaw("Horizontal");
    }

    void Translate()
    {
        //Go up
        if(vertAxis > 0)
        {
            this.transform.Translate((Vector2.up * vertAxis) * moveDist * Time.deltaTime);
            animator.ResetTrigger("MoveRight");
            animator.ResetTrigger("MoveLeft");
            animator.ResetTrigger("MovingDown");
            animator.SetTrigger("MovingUp");
        }

        //Go right
        if(horizAxis > 0)
        {
            this.transform.Translate((Vector2.right * horizAxis) * moveDist * Time.deltaTime);
            animator.ResetTrigger("MoveLeft");
            animator.ResetTrigger("MovingUp");
            animator.ResetTrigger("MovingDown");
            animator.SetTrigger("MoveRight");
        }

        //Go Down
        if(vertAxis < 0)
        {
            this.transform.Translate((Vector2.down * -vertAxis) * moveDist * Time.deltaTime);
            animator.ResetTrigger("MoveRight");
            animator.ResetTrigger("MoveLeft");
            animator.ResetTrigger("MovingUp");
            animator.SetTrigger("MovingDown");
        }

        //Go left
        if(horizAxis < 0)
        {
            this.transform.Translate((Vector2.left * -horizAxis) * moveDist * Time.deltaTime);
            animator.ResetTrigger("MovingUp");
            animator.ResetTrigger("MovingDown");
            animator.ResetTrigger("MoveRight");
            animator.SetTrigger("MoveLeft");
        }
    }
}
