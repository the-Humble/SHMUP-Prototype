using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    // Speed of the asteroid's movement
    [SerializeField] private float moveSpeed = 3f;

    // Time to elapse in order to change direction
    [SerializeField] private float moveTime = 1f;

    // Horizontal direction
    [Range(-1, 0)]
    [SerializeField] private float directionX = 1f;

    // Vertical direction
    [Range(-1, 1)]
    [SerializeField] private float directionY = 0f;

    // assign starting direction to move
    protected Vector3 direction;

    // bool change direction flag
    protected bool oppositeDir = false;

    private void Awake()
    {
        // Initialize direction vector
        direction = new Vector3(directionX, directionY, 0);

        // Start IEnumerator Coroutine
        StartCoroutine(isMoving());
    }

    private IEnumerator isMoving()
    {
        // Run always
        while (true)
        {
            // Check opposite direction flag to mirror the direction
            if (oppositeDir)
            {
                // mirror direction
                direction = new Vector3(directionX, -directionY, 0); ;
            }

            // start move coroutine passing the actual direction
            yield return StartCoroutine(MoveCoroutine(direction));

            // toggle flags
            oppositeDir = !oppositeDir;
        }
    }

    private IEnumerator MoveCoroutine(Vector3 moveDir)
    {
        // Elapsed time 
        float duration = 0;

        // check if elapsed time hasn't reached the move time
        while (duration < moveTime)
        {
            // increase elapsed time
            duration += Time.deltaTime;

            // update position
            transform.position += ((moveDir * Time.deltaTime) * moveSpeed);

            yield return null;
        }
    }
}
