using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class FrogMovementLimiter : MonoBehaviour
{
    public Vector3 minBounds; // Set these to your room's boundaries
    public Vector3 maxBounds;

    private Rigidbody rb;

    private Animator frogAnimator;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        frogAnimator = gameObject.GetComponent<Animator>();



        if (frogAnimator != null)
            {
                Debug.Log("Kill Frog");

            }
            else
            {
                Debug.LogError("Animator component not found.");
            }
    }

    void FixedUpdate()
    {
        Vector3 clampedPosition = rb.position;

        // Clamp position within the room bounds
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        // clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
                clampedPosition.y = 0.34f;

        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBounds.z, maxBounds.z);

        rb.position = clampedPosition;
    }


    void OnAnimatorMove()
    {
        // If you're using root motion, apply clamping here as well
        Vector3 clampedPosition = frogAnimator.rootPosition;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minBounds.x, maxBounds.x);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, minBounds.y, maxBounds.y);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minBounds.z, maxBounds.z);

        rb.MovePosition(clampedPosition);
    }


}
