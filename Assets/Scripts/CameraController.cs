using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    Vector3 rotation = Vector3.zero;


    public GameObject player;
    Transform playerBody;

    float mouseSensitivity = 600f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerBody = player.transform;
    }

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

        playerBody.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(rotation);
    }
}
