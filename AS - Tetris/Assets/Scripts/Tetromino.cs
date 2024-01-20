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
    public Vector3 rotationPoint;


    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, 90);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Vector3 convertedPoint = transform.TransformPoint(rotationPoint);
            transform.RotateAround(convertedPoint, Vector3.forward, -90);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.D))
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

    public bool ValidMove()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);
            if (x < 0 || x >= width)
            {
                return false;
            } 
          
            if (y < 0 || y >= height)
            {
                return false;
            } 
        }
        return true;

    }
    
}
