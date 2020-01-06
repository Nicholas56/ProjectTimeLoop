using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);
        Vector3 velocity = direction * moveSpeed;

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

        if (Input.GetKey(KeyCode.LeftShift)&&charController.isGrounded)
        {
            charController.Move(velocity * Time.deltaTime * 4);
        }
        else
        {
            charController.Move(velocity * Time.deltaTime);
        }
    }
}
