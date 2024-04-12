using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int speed = 5;
    int jumpCount = 1;

    [SerializeField] GameObject mainCamera;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            movement += mainCamera.transform.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            movement -= mainCamera.transform.forward;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            movement += mainCamera.transform.right;
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            movement -= mainCamera.transform.right;
        }
        // TODO: Finish this goddamn shit
        // if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift) 
        // {
        //     
        // }
       // if (Input.GetKey(KeyCode.Space)) 
       // {
       //     rb.AddForce(movement);
       // }
        movement.Normalize();
        rb.velocity = new Vector3(movement.x * speed, rb.velocity.y, movement.z * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground" && jumpCount < 1) 
        {
            jumpCount++;
        }
    }
}
