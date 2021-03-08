using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    // needed for later use of .AddForce , which works only with RigidBody.
    private Rigidbody ballRb;
    private float speed = 20.0f;
    private float rotationSpeed = 700.0f;
    private float boundaryX = 21.0f;
    private float boundaryZ = 20.0f;
    //needed for getting access to animation controllers
    private Animator animPlayer;
   




    void Start()
    {
      
        animPlayer = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
        // up-down arrows press is stored in this variable
        float verticalInput = Input.GetAxis("Vertical");

        // left-right arrows press is stored in this variable
        float horizontalInput = Input.GetAxis("Horizontal");

        
        //setting direction for movement: x values from horizontalInput, z balues from verticalInput, y is 0 there is no vertical movement up-down
         Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
       

        //vector length after Normalizing equals to 1, the direction remains unchanged. Normalizing gives quick reaction to arroy keys, because the vector length is so short.
        movementDirection.Normalize();

        ///Space.World means relatively to the world
        ///applying direction and speed of movement to player
        transform.Translate(movementDirection * speed * Time.deltaTime, Space.World);

        //if there is a movement 
        if (movementDirection != Vector3.zero)
        {
            //setting new direction 
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            // applying rotation to the player from current position into toRaotation direction
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
        //boundaries for player movement, so dont fall off the fieled
        if(transform.position.x > boundaryX)
        {
            transform.position = new Vector3(boundaryX, 0, transform.position.z);
        }
        if(transform.position.x < -boundaryX)
        {
            transform.position = new Vector3(-boundaryX, 0, transform.position.z);
        }
        if (transform.position.z > boundaryZ)
        {
            transform.position = new Vector3(transform.position.x, 0, boundaryZ);
        }
        if (transform.position.z < -boundaryZ)
        {
            transform.position = new Vector3(transform.position.x, 0, -boundaryZ);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {  // is the collision object has tag "Ball", then make a variable and store in it it's physical properties  
            Debug.Log("Collided with Ball");
          
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            //get the direction opposite from the collider (player or another ball)
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;
           
            // apply this direction to the collision pbject (an object that was collided with)
            ballRb.AddForce(awayFromPlayer * speed, ForceMode.Impulse);
            
        }
    }


   
}
