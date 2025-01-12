using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController characterController;
    public float MovementSpeed =1;
    public float Gravity = 9.8f;
    private float velocity = 0;
 
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
 
    void Update()
    {
        // player movement - forward, backward, left, right
        float horizontal = Input.GetAxis("Horizontal") * MovementSpeed;
        float vertical = Input.GetAxis("Vertical") * MovementSpeed;
        characterController.Move((transform.right * horizontal + transform.forward * vertical) * Time.deltaTime);
 
        // Gravity
        if(characterController.isGrounded)
        {
            velocity = 0;
        }
        else
        {
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }

        if(gameObject.transform.position.z > -11 && gameObject.transform.position.z < -7 && gameObject.transform.position.x <= -18.5 && SceneManager.GetActiveScene().name == "OutsideScene")
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
