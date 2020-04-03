using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    float speed = 4;
    float gravity = 9;
    float rotation = 0f;
    float rotationSpeed = 80;


    Vector3 moveDir = Vector3.zero;

    CharacterController controller;
    Animator anim;








    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();

        anim = GetComponent<Animator>();



    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded)

        {
            if(Input.GetKey(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 1);
                moveDir *= speed;
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDir = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.S))
            {
                moveDir = new Vector3(0, 0, -1);
                moveDir *= speed;
            }
            if (Input.GetKeyUp(KeyCode.S))
            {
                moveDir = new Vector3(0, 0, 0);
            }

        }

        rotation += Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rotation, 0);

        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }
}
