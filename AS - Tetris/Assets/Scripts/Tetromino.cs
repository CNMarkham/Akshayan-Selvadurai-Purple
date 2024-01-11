using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    private float previousTime;
    public float fallTime;
    public float width;
    public float height;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right * speed * Time.deltaTime;
        }

        float tempTime = fallTime;

        if (Input.GetKey(KeyCode.S))
        {
            tempTime = tempTime / 10;
        }
        
        if (Time.time - previousTime > tempTime)
        {
            transform.position = transform.position + Vector3.down;
            previousTime = Time.time;
        }
    }
}
