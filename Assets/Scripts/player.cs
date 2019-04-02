﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed = 10f;
    public float tilt = 360.0f;
    float tiltMe = 0;
    float moveMe = 0;

    //Declare a new delegate type
    public delegate void WeaponFireDelegate();
    //Create the actual delegate
    public WeaponFireDelegate fireDelegate;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");
        if (Input.GetKey("right") || Input.GetKey("left"))
        {
            tiltMe += -xAxis * 3;
        }
      
        if (Input.GetKey("up"))
        {
            moveMe += yAxis;
        }



        Vector3 pos = transform.position;
        Quaternion target = Quaternion.Euler(0, 0, tiltMe);


       
        transform.position = transform.up * Time.deltaTime * speed * moveMe;

        transform.rotation = target;


        if (Input.GetAxis("Jump") == 1 && fireDelegate != null)
        {
            fireDelegate();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
    }
}
