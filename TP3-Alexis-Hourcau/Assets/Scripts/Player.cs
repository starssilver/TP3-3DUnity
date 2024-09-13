using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rb;
    public float speed;
    public float running = 2.0f;
    public float jumpForce;
    public bool onGround;


    private const string SOL = "sol";
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private const string JUMP = "Jump";


    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis(HORIZONTAL);
        float moveVertical = Input.GetAxis(VERTICAL);

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);

        // Gérer le saut
        if (onGround && Input.GetButtonDown(JUMP))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            onGround = false;
        }

        // Sprint or Not

        float currentSpeed = speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= running;
        }

        transform.Translate(movement * currentSpeed * Time.deltaTime);
    }

    // Détection des collisions avec le sol
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(SOL))
        {
            onGround = true;
        }
    }
}
