using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Nicholas Easterby - EAS12337350
//This script gives the player control over their own movement

public class PlayerMovement : MonoBehaviour
{

    CharacterController charController;
    
    [SerializeField] float jumpSpeed = 20.0f;
    [SerializeField] float gravity = 1.0f;
    float yVelocity = 0.0f;
    [SerializeField] float moveSpeed = 5.0f;

    public float h;
    public float v;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Takes the two dimensional inputs to calculate direction to move in
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

        //Checks to see if on the ground to allow jumping, or implement gravity
        if (charController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpSpeed;
            }
        }
        else
        {
            yVelocity -= gravity;
            Mathf.Clamp(yVelocity, -20f, 100f);
        }
        velocity.y = yVelocity;

        velocity = transform.TransformDirection(velocity);

        //Increases speed for Sprint function, using either shift input
        if ((Input.GetKey(KeyCode.LeftShift)|| Input.GetKey(KeyCode.RightShift)) &&charController.isGrounded)
        {
            charController.Move(velocity * Time.deltaTime * 4);
        }
        else
        {
            charController.Move(velocity * Time.deltaTime);
        }
    }
}
