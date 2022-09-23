using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharController : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;
    // private Quaternion playerForward;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (move != Vector3.zero)
        {
            // gameObject.transform.forward = move;
            // playerForward=transform.rotation;
            // controller.Move(move * Time.deltaTime * playerSpeed);
            // Debug.Log(move);
            // Camera.main.transform.eulerAngles.y
            Vector3 inputDirection = transform.right * move.x + transform.forward * move.z;
            controller.Move(inputDirection * Time.deltaTime * playerSpeed);
            // transform.Translate(move * Time.deltaTime * playerSpeed);
        }

        // Changes the height position of the player..
        // if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        // playerVelocity.y += gravityValue * Time.deltaTime;
        // controller.Move(playerVelocity * Time.deltaTime);
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// [RequireComponent(typeof(CharacterController))]
// public class CharController : MonoBehaviour
// {
//     public float playerSpeed = 2.0f;
//     public float jumpHeight = 1.0f;
//     private CharacterController controller;
//     private Vector3 playerVelocity;
//     private bool groundedPlayer;
//     private float gravityValue = -9.81f;

//     private void Start()
//     {
//         controller = gameObject.GetComponent<CharacterController>();
//     }

//     void Update()
//     {
//         groundedPlayer = controller.isGrounded;
//         if (groundedPlayer && playerVelocity.y < 0)
//         {
//             playerVelocity.y = 0f;
//         }

//         var horizontal = Input.GetAxis("Horizontal");
//         var vertical = Input.GetAxis("Vertical");
//         // transform.Translate(new Vector3(horizontal, 0, vertical)*Time.deltaTime);// * (playerSpeed * Time.deltaTime));

//         // Vector3 move = new Vector3(horizontal, 0, vertical);
//         // // // transform.localRotation = Quaternion.Euler(transform.rotation.x,turn,transform.rotation.x);
//         // // transform.Rotate(transform.rotation.x,horizontal,transform.rotation.x);
//         // controller.Move(move * Time.deltaTime * playerSpeed);

//         // if (move != Vector3.zero)
//         // {
//         //     // gameObject.transform.forward = move;
//         // }

//         // // Changes the height position of the player..
//         // if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
//         // {
//         //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
//         // }

//         // playerVelocity.y += gravityValue * Time.deltaTime;
//         // controller.Move(playerVelocity * Time.deltaTime);

// 	        Vector3 inputDirection = new Vector3(horizontal, 0.0f, vertical).normalized;

// 			// note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
// 			// if there is a move input rotate player when the player is moving
// 			if (inputDirection != Vector3.zero)
// 			{
// 				// move
// 				inputDirection = transform.right * vertical + transform.forward * horizontal;
// 			}

// 			// move the player
// 			controller.Move(inputDirection.normalized * (playerSpeed * Time.deltaTime) + new Vector3(0.0f, 0, 0.0f) * Time.deltaTime);
		

//     }
// }