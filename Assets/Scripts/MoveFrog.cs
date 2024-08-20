using UnityEngine;

public class MoveFrog : MonoBehaviour
{
    public float speed = 2.0f;

	private Vector3 destination;

    private Animator animator;

    private string turnLeftStateName = "Left";

	void Start () {
		// Set the destination to be the object's position so it will not start off moving
		SetDestination (gameObject.transform.position);


        animator = GetComponent<Animator>();
	}
	
	void Update () {



        // bool isMoving = animator.GetBool("isMoving");

        // // If 'isMoving' is true, move the Frog forward
        // if (isMoving)
        // {
        //     MoveFrog();
        // }





        // Check if the current state is 'TurnLeft'
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool isTurningLeft = stateInfo.IsName(turnLeftStateName);

        // If 'isMoving' is true and the Frog is in the 'TurnLeft' state, move the Frog forward
        if (isTurningLeft)
        {
            // MoveFrog();
            IncrementPosition();
            Debug.Log("Move Frog");
        }





		// // If the object is not at the target destination
		// if (destination != gameObject.transform.position) {
		// 	// Move towards the destination each frame until the object reaches it
		// 	IncrementPosition ();
		// }
	}

	void IncrementPosition ()
	{
		// Calculate the next position
		float delta = speed * Time.deltaTime;
		Vector3 currentPosition = gameObject.transform.position;
		Vector3 nextPosition = Vector3.MoveTowards (currentPosition, destination, delta);

		// Move the object to the next position
		gameObject.transform.position = nextPosition;
	}

	// Set the destination to cause the object to smoothly glide to the specified location
	public void SetDestination (Vector3 value) {
		// destination = value;
        		destination = new Vector3(value.x, value.y, value.z+2.0f);


	}

}
