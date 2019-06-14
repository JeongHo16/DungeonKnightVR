﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    public float velocity = 0.7f;
    public bool walking = false;

    public float gravity = 9.8f;

    private CharacterController controller;
    private Clicker cliker = new Clicker();

    //private float verticalVelocity = 0.0f;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (cliker.clicked())
        {
            walking = !walking;
        }

        if (walking)
        {
            moveDirection = Camera.main.transform.forward * velocity;
        }
        else
            moveDirection = Vector3.zero;

        //if (controller.isGrounded)
        //    verticalVelocity = 0.0f;

        //moveDirection.y = verticalVelocity;
        //verticalVelocity -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            walking = !walking;
            //controller.Move(Spot.firstSpot);
            controller.Move(new Vector3(3.0f, 0.5f, 3.0f));
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Ghost"))
        {

        }

    }
}
