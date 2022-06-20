using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    CharacterController controller;

    Vector3 move;

    public float moveSpeed = 3f;
    public float sprintMulti = 1.5f;

    public Transform groundCheck;
    public LayerMask groundMask;
    bool isGrounded;
    float groundDistance = 0.4f;

    Vector3 rotation = Vector3.zero;

    float mouseSensitivity = 600f;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rotation.z > -.03f && rotation.z < .03f) {
            rotation.z = 0;
        }
        else if (rotation.z < 0f) {
            rotation.z += 40 * Time.deltaTime;
        }
        else if (rotation.z > 0f) {
            rotation.z -= 40 * Time.deltaTime;
        }

        rotation.y += Input.GetAxis ("Mouse X") * mouseSensitivity * Time.deltaTime;
		rotation.x += -Input.GetAxis ("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotation.x = Mathf.Clamp(rotation.x, -90f, 90f);

        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        

        if (x != 0 || z != 0) {
                if (Input.GetKey(KeyCode.LeftShift)) {
                    x *= sprintMulti;
                    z *= sprintMulti;
                    anim.SetInteger("WalkState", 2);
                }
                else {
                    anim.SetInteger("WalkState", 1);
                }
        }
        else {
            anim.SetInteger("WalkState", 0);
        }

        move = Vector3.ClampMagnitude(transform.right * x + transform.forward * z, 1f);

        // controller.Move(move * moveSpeed * Time.deltaTime);
        controller.SimpleMove(move * moveSpeed);
    }
}
