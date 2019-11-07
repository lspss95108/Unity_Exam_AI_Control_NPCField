﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BALL : MonoBehaviour {
    Rigidbody AAA;
    [Header("速度")]
    [Range(1, 270)]
    public float speed = 1;
    [Header("跳躍")]
    [Range(1, 2000)]
    public float jump = 1;
    [Header("有沒有接觸地面")]
    public bool isGround;


    // Use this for initialization
    void Start()
    {
        AAA = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGround = true;
       
    }

    private void Walk()
    {
        AAA.AddForce(new Vector3(speed * Input.GetAxis("Horizontal"), 0, 0));
        AAA.AddForce(new Vector3(0, 0, speed * Input.GetAxis("Vertical")));

    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround == true)
        {
            isGround = false;
            AAA.AddForce(new Vector3(0, jump, 0));
        }

    }
}
