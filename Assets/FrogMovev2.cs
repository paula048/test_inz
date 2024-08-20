using UnityEngine;

public class FrogMovev2 : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        int randomRotation = Random.Range(0, 361); // Generates a random degree between 0 and 360
        animator.SetInteger("RotationDegree", randomRotation);

        // Use Random.Range to get a random number between 0 and 2 (inclusive)
        int choice = Random.Range(0, 3);

        if (choice == 0)
        {
            animator.SetTrigger("Idle");
        }
        else if (choice == 1)
        {
            animator.SetTrigger("TurnLeft");
        }
        else
        {
            animator.SetTrigger("TurnRight");
        }
       
    }



    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    // override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {
    //     // Use Random.Range to get a random number between 0 and 2 (inclusive)
    //     int choice = Random.Range(0, 3);

    //     if (choice == 0)
    //     {
    //         animator.SetTrigger("Idle");
    //     }
    //     else if (choice == 1)
    //     {
    //         animator.SetTrigger("TurnLeft");
    //     }
    //     else
    //     {
    //         animator.SetTrigger("TurnRight");
    //     }
    // }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
