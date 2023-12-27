using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMove : MonoBehaviour
{
    public float speed;
    // private float horizontalInput = 0.0f;
    // private float verticalInput = 1.0f;
    // private Vector3 movedirection = new Vector3(0f , 1f, 0f);
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down};
    public int currentMoveDirection, previousMoveDirection, randomMoveDirection;
    private float randomX, randomY;
    private void Start() 
    {
        RandomSpawnPosition();
        ChooseMoveDirection();
        previousMoveDirection = currentMoveDirection;
    }
    private void RandomSpawnPosition()
    {
        randomX = Mathf.FloorToInt(Random.Range(-15, 15)) - 0.5f;
        randomY = Mathf.FloorToInt(Random.Range(-5, 5)) - 0.5f; 
        this.transform.position = new Vector3( randomX , randomY , 0);
    }
    void Update()
    {
        MoveForward();
    }
    private void MoveForward()
    {
        // this.GetComponent<Rigidbody2D>().AddForce(moveDirections[currentMoveDirection] * speed  * Time.deltaTime);
        this.transform.position += moveDirections[currentMoveDirection] * speed * Time.deltaTime;
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Wall")
        { 
            // this.GetComponent<Rigidbody2D>().AddForce(moveDirections[currentMoveDirection] * speed  * Time.deltaTime * (-1));
            // this.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            // this.transform.Rotate(0, 0, Random.Range(-1,1) * 90);
            this.transform.position -= moveDirections[currentMoveDirection] * speed * speed * Time.deltaTime;
            ChooseMoveDirection();
        }
    }
    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        randomMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
        if (randomMoveDirection != currentMoveDirection || randomMoveDirection != previousMoveDirection) 
        {
            previousMoveDirection = currentMoveDirection;
            currentMoveDirection = randomMoveDirection;
        }
        else ChooseMoveDirection();
    }
}