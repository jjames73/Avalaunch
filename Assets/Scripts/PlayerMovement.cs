using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 3f;
    public float jumpHeight = 3f;
    private bool touchGround;
    private Rigidbody rbPlayer;
    private TrailRenderer tr;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        tr = GetComponent<TrailRenderer>(); // Initialize tr
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space) && touchGround)
        {
            rbPlayer.AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        Vector3 velocity = rbPlayer.velocity;
        Vector3 flatVelocity = new Vector3(velocity.x, 0, velocity.z);

        if (flatVelocity.magnitude > speed)
        {
            flatVelocity = flatVelocity.normalized * speed;
        }

        rbPlayer.velocity = new Vector3(flatVelocity.x, velocity.y, flatVelocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGround = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            tr.gameObject.SetActive(false);

            if (StarAttributes.starCount == 3)
            {
                SceneManager.LoadScene("YouWon");
                StarAttributes.starCount = 0;
            }
            else if (StarAttributes.starCount == 2 || StarAttributes.starCount == 1)
            {
                SceneManager.LoadScene("DoBetter");
                StarAttributes.starCount = 0;
            }
            else if (StarAttributes.starCount == 0)
            {
                SceneManager.LoadScene("Survived");
                StarAttributes.starCount = 0;
            }
        }
    }
}
