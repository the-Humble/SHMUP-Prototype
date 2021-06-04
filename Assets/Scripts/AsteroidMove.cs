using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    // Speed of the asteroid's movement
    [SerializeField] private float moveSpeed = 3f;

    // Horizontal direction
    [Range(-1, 0)]
    [SerializeField] private float directionX = 1f;

    // Vertical direction
    [Range(-1, 1)]
    [SerializeField] private float directionY = 0f;

    // assign starting direction to move
    protected Vector3 direction;

    private void Awake()
    {
        float randomPos = Random.Range(-1, 2);
        float randomSpeed = Random.Range(0, 3);

        moveSpeed += randomSpeed;

        // Initialize direction vector
        direction = new Vector3(directionX, randomPos, 0);

    }

    private void Start()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = direction.normalized * moveSpeed;
    }
}
