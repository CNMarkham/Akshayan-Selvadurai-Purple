using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : Movement
{
    public GameObject body;
    public GameObject eyes;
    public GameObject blue;
    public GameObject white;
    public bool atHome;
    public float homeDuration;
    private bool frightened;

    private void Awake()
    {
        
    }

    protected void ChildUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D)
    {

    }

    private void OnTriggerEnter2D(Collision2D) 
    {
        
    }

    private void LeaveHome()
    {

    }
    
    public void Frighten()
    {

    }

    private void Flash()
    {

    }

    private void Reset()
    {
        
    }
}
