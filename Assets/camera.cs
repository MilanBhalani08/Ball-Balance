using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public Transform ball;  // Assign the ball object in the inspector
    float followDistance = 10f;
    float followHeight = 3.5f;
    float smoothSpeed = 4f;
    float rotationSmoothSpeed = 5f;
    private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball == null) return;

        // Get ball's movement direction
        Vector3 ballVelocity = ball.GetComponent<Rigidbody>().velocity;

        if (ballVelocity.magnitude > 0.1f) // Only adjust if moving
        {
            Vector3 followPosition = ball.position - ballVelocity.normalized * followDistance;
            followPosition.y = ball.position.y + followHeight;

            // Smoothly move the camera
            transform.position = Vector3.SmoothDamp(transform.position, followPosition, ref velocity, smoothSpeed * Time.deltaTime);

            // Smoothly rotate the camera to align with ball movement direction
            Quaternion targetRotation = Quaternion.LookRotation(ballVelocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
        }
    }
}
