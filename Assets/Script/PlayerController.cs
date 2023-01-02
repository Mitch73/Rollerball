using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;    
    public int playerIndex;

    private Transform respawnPoint;
    private MenuController menuController;
    private ScoreHandler scoreHandler;
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = GameObject.Find("RespawnPoint").transform;
        menuController = GameObject.Find("Canvas").GetComponent<MenuController>();
        scoreHandler = GameObject.Find("Canvas/CountPanel").GetComponent<ScoreHandler>();
        // get the reference from the rigidbody
        rb = GetComponent<Rigidbody>();
        count = 0;

        setCountText();
        //winTextOject.SetActive(false);
    }

    private void Update()
    {
/*check to see if the player has fallen threshold if so respawn*/
        if(transform.position.y < -10)
        {
            Respawn();
        }
    }

    // InputValue = different type of variable
    // movementValue = value used in the function
    // movementValue store data from the x and y direction of input visise
    void OnMove(InputValue movementValue)
    {
        // vector2 gets data from the movementValue and stores in momentVector variable
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void setCountText()
    {
        menuController.AddCountText(playerIndex, count);
        if(scoreHandler.Score >= 12)
        {
            //winTextOject.SetActive(true);
            menuController.WinGame();
        }
    }

    // call and add force on the object
    void FixedUpdate()
    {
        // F = float value
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            scoreHandler.Score += 1;

            setCountText();
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*respawn the player in case the enemy and player collide*/
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Respawn();
            EndGame();
        }
    }

    void Respawn()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.Sleep();
        transform.position = respawnPoint.position;
    }

    void EndGame()
    {
        menuController.LoseGame();
        gameObject.SetActive(false);
    }
}
