using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewPlayerMovement : MonoBehaviour
{
    public GameObject[] pauseObjects;

    Vector3 boxExtents;
    public Rigidbody rb;
    public Transform Cam;

    public float moveSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float stamina = 1f;
    public float staminaDepleteTime = 5f;
    public float staminaRegenTime = 3f;

    public float jumpForce = 8.0f;
    public float airControlForce = 10.0f;
    public float airControlMax = 1.5f;

    public float strength;

    public bool resume;
    public bool running = false;
    public bool OnGround = true;

    // Start is called before the first frame update
    void Start()
    {
        //Controller = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        boxExtents = GetComponent<CapsuleCollider>().bounds.extents;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //MOVEMENT
        float Horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

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


        //PAUSE

        if (Input.GetKeyDown("p") || resume == true)
        {
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0;

                resume = false;

                showPaused();

            }
            else if (Time.timeScale == 0)
            {
                Cursor.visible = false;

                Time.timeScale = 1;

                resume = false;

                hidePaused();
            }
        }
        //STAMINA

        running = false;

        if (Input.GetButton("Fire2"))
        {
            stamina -= Time.deltaTime / staminaDepleteTime;
            if (stamina > 0f)
            {
                running = true;
            }
        }
        else
        {
            stamina += Time.deltaTime / staminaRegenTime;
        }

        stamina = Mathf.Clamp01(stamina);

        if (running)
        {
            moveSpeed = runSpeed;
        }
        else
        {
            moveSpeed = walkSpeed;
        }

        // JUMP
        if (Input.GetButtonDown("Jump") && OnGround == true || Input.GetButton("Jump") && OnGround == true)
        {
            Debug.Log("jump");
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);

            OnGround = false;
        }
    }

    private void showPaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(true);
        }
    }

    private void hidePaused()
    {
        foreach (GameObject g in pauseObjects)
        {
            g.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("hit floor");
            OnGround = true;
        }

        if (collision.gameObject.tag == "Improve")
        {
            Debug.Log("hit improve tag");
            OnGround = true;
        }

        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("hit improve tag");
            OnGround = true;
        }
    }
}

