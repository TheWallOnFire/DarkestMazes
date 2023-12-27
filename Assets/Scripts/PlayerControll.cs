using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    public float speed, angle;
    public Transform goal, compass;
    private Vector3 movedirection;
    private float horizontalInput;
    private float verticalInput;
    public AudioSource walk;
    private Vector3 direction;
    public GameObject MazeGen;
    private void Start()
    {
        direction = goal.position - this.GetComponent<Transform>().position;
        angle = Vector2.SignedAngle(Vector2.right, direction);
        compass.rotation = Quaternion.Euler(0, 0, angle);
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        movedirection = new Vector3(horizontalInput , verticalInput , 0);
        direction = goal.position - this.GetComponent<Transform>().position;
        angle = Vector2.SignedAngle(Vector2.right, direction);
        compass.rotation = Quaternion.Euler(0, 0, angle - 90);
    }
    void FixedUpdate()
    {
        // Direction();
        MoveForward();
    }
    private void MoveForward()
    {
        this.GetComponent<Rigidbody2D>().AddForce(movedirection * speed  * Time.deltaTime);
        if (movedirection != Vector3.zero) walk.mute = false;
        else walk.mute = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "GOAL")
        { 
            MazeGen.GetComponent<GameState>().InitState("GAMEWIN");
        }
        if (other.gameObject.tag == "Enemy")
        { 
            MazeGen.GetComponent<GameState>().InitState("GAMEOVER");
        }
    }
}