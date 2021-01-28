using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    //CharacterController Controller;
    public Rigidbody rb;

    public float Speed;

    public Transform Cam;

    // Start is called before the first frame update
    void Start()
    {
       //Controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        bool restartkey = Input.GetKeyDown(KeyCode.R);

        float Horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 Movement = Cam.transform.right * Horizontal + Cam.transform.forward * Vertical;
        Movement.y = 0f;

        transform.Translate(Horizontal, 0, Vertical);

        if (Movement.magnitude != 0f)
        {
            transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Cam.GetComponent<NewCameraController>().sensivity * Time.deltaTime);

            Quaternion CamRotation = Cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);
        }


        //CONTROLS

        if (restartkey == true)
        {
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.tag == "NPC")
            {
                other.attachedRigidbody.AddForce(300, 300, 5);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (other.gameObject.tag == "NPC")
            {
                other.attachedRigidbody.AddForce(300, 300, 5);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (other.gameObject.tag == "NPC")
            {
                other.attachedRigidbody.AddForce(300, 300, 5);
            }
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (other.gameObject.tag == "NPC")
            {
                other.attachedRigidbody.AddForce(300, 300, 5);
            }
        }
    }

}

