using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    public float speed;
    private float previousTime;
    public float fallTime;
    public static int width = 10;
    public static int height = 20;
    public Vector3 rotationPoint;


    public static Transform[,] grid = new Transform[width, height];

    public void CheckForLines()
    {
        for (int i = height - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                DeleteLine(i);
                RowDown(i);
            }
        }
    }

    public bool HasLine(int i)
    {
        for (int j=0; j < width; j++)
        {
            if (grid[j,i] == null)
            {
                return false;
            }
        }
        return true;
    }



    public void DeleteLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(grid[j, i].gameObject);
            grid[j, i] = null;
        }
    }

    public void RowDown(int i)
    {
        for (int y = i; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].transform.position += Vector3.down;
                }
            }
        }
    }

    public void AddToGrid()
    {
        foreach (Transform child in transform)
        {
            int x = Mathf.RoundToInt(child.transform.position.x);
            int y = Mathf.RoundToInt(child.transform.position.y);

            grid[x, y] = child;
        }

    }



    // Update is called once per frame
    void Update()
    {
        CheckForLines();

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
            transform.position = transform.position + Vector3.left;
            if (!ValidMove())
            {
                transform.position += Vector3.right;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + Vector3.right;
            if (!ValidMove())
            {
                transform.position += Vector3.left;
            }
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
            if (!ValidMove())
            {
                
                transform.position += Vector3.up;
                this.enabled = false;
                AddToGrid();
                FindObjectOfType<Spawner>().SpawnTetromino();
            }
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
            if (grid[x, y] != null)
            {
                return false;
            }
        }
        return true;

    }
    
}
 