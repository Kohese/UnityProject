using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class MoveAlongSpline : MonoBehaviour
{
    public SplineContainer spline;
    public TrainSeatController seat;
    // public TrainStop SecondRoom;
    public float maxSpeed = 150f;  // Max train speed
    public float acceleration = 20f; // How fast the train accelerates
    public float baseDeceleration = 5f; // Minimum deceleration when slowing down
    public float minSpeed = 1f; // Prevents full stop unless needed
    public float raycastDistance = 25f; // Detection range for obstacles
    public float rotationSpeed = 5f; // Rotation smoothing
    public float smoothDecelerationFactor = 0.1f; 
    public GameObject wall;
    public GameObject[] rooms;

    private float moveSpeed = 0f;
    private float currentDistance = 0f;
    private Vector3 targetDirection;
    private bool moving = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("No Rigidbody found! Please add one to the train.");
        }
        else
        {
            rb.interpolation = RigidbodyInterpolation.Interpolate;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.useGravity = true;  // Ensure gravity is enabled
        }
                // Find all the GameObjects with the "Room" tag at the start
        rooms = GameObject.FindGameObjectsWithTag("Room");
    }

    void FixedUpdate()
    {
        HandleObstacleCheck();
        HandleMovement();
    }

    void HandleObstacleCheck()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, raycastDistance))
        {
            if (hit.collider.gameObject == wall) return;
            if (hit.collider.gameObject == GameObject.FindWithTag("enemy")) return;
            if (hit.collider.gameObject == GameObject.FindWithTag("Tracks")) return;

            Debug.Log(hit.collider.gameObject);
            Debug.Log(GameObject.FindWithTag("Tracks"));

                        // Check if the hit object is in the rooms array
            foreach (var room in rooms)
            {
                if (hit.collider.gameObject == room)
                {
                    // If the hit object is in the rooms array, return and do nothing
                    return;
                }
            }

            // Calculate the distance to the obstacle
            float distanceToObstacle = hit.distance;

            // Calculate the deceleration factor based on distance
            float slowdownFactor = Mathf.Clamp01(distanceToObstacle / raycastDistance);

            // Smooth deceleration as the train gets closer
            float dynamicDeceleration = Mathf.Lerp(baseDeceleration, baseDeceleration * 10, (1 - slowdownFactor) * smoothDecelerationFactor);

            // Apply deceleration but keep it smooth
            moveSpeed = Mathf.Max(moveSpeed - dynamicDeceleration * Time.fixedDeltaTime, 0);

            // Debug.Log($"Obstacle detected: {hit.collider.gameObject.name} at {distanceToObstacle} meters. Speed: {moveSpeed}");
        }
    }

    void HandleMovement()
    {
        if (seat.inCart) // Player is inside, allow acceleration/deceleration
        {
            if (Input.GetKey(KeyCode.W))
            {
                moving = true;
                moveSpeed = Mathf.Min(moveSpeed + acceleration * Time.fixedDeltaTime, maxSpeed);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveSpeed = Mathf.Max(moveSpeed - baseDeceleration * Time.fixedDeltaTime, minSpeed);
            }
        }

        if (!moving || moveSpeed <= minSpeed)
        {
            moving = false;
        }

        if (moveSpeed <= 0)
        {
            moveSpeed = 0;
            return;
        }

        float splineLength = spline.CalculateLength();
        float movement = moveSpeed * Time.fixedDeltaTime / splineLength;
        currentDistance += movement;
        currentDistance = Mathf.Clamp01(currentDistance);

        Vector3 targetPosition = spline.EvaluatePosition(currentDistance);  // Get the new position along the spline
        targetDirection = spline.EvaluateTangent(currentDistance);  // Get the direction (tangent) of the spline at the current distance

        if (rb != null)
        {
            // Move the rigidbody using MovePosition to respect physics and collisions
            rb.MovePosition(targetPosition);

            // Calculate velocity from the target position
            Vector3 direction = (targetPosition - rb.position).normalized;  // Direction to target

            // Apply velocity in the direction of the spline path, preserving gravity (y velocity)
            rb.linearVelocity = new Vector3(direction.x * moveSpeed, rb.linearVelocity.y, direction.z * moveSpeed);

            // Rotation to align with spline direction (avoiding flipping)
            if (targetDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            transform.position = targetPosition;
        }
    }
}
