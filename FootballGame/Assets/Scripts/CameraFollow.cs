using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 offset;
   
    void Start()
    {
        //camera distance from the player
        offset = new Vector3(0, 12, -10);
    }

    // Update is called once per frame
    void Update()
    {

     
        //Lurp(initial position, desired position, delay) just makes camera following a little smoother
        transform.position = Vector3.Lerp(transform.position, (transform.position = player.transform.position + offset), 0.25f);

       

   
    }
}
