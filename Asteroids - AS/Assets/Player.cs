using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float lookSpeed;
    public float moveSpeed;
    public float maxSpeed;
    private Rigidbody2D rb;
    public GameObject bulletPrefab;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * lookSpeed);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * Time.deltaTime * lookSpeed);
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 velocity = rb.velocity;
            velocity = velocity + transform.right * Time.deltaTime * moveSpeed;
            rb.velocity = velocity;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, transform.rotation);
        }
    }
}