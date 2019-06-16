﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Windshield windshield;
    public GameObject player;
    public GameObject body;
    public GameObject cube;

    public float velocity = 1f;
    public bool walking = false;

    //private float verticalVelocity =0f;
    //private float gravity = 9.8f;

    private CharacterController controller;
    private Clicker cliker = new Clicker();

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!BoolStates.isCount)
        {
            if (cliker.clicked())
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
            CollideTrophy(other);

        if (other.gameObject.CompareTag("TallerItem"))
            CollideTallerItem(other);
        else if (other.gameObject.CompareTag("SpeedItem"))
            CollideSpeedUpItem(other);
    }

    private void LocatePlayer()
    {
        cube.transform.position = Spot.spots[windshield.stageNumber - 1];
        Debug.Log(windshield.stageNumber);
    }

    private void CollideTrophy(Collider other) //트로피 얻었을 때
    {
        walking = !walking; //수정필요
        Destroy(other.gameObject);
        StartCoroutine(windshield.GoToTheNextStage(3f, "<b>Stage Claer</b>"));
        LocatePlayer();
    }

    private void CollideTallerItem(Collider other) //키커지는 아이템
    {
        Destroy(other.gameObject);
        body.transform.position = new Vector3(player.transform.position.x, 5f, player.transform.position.z);
        windshield.StartItemCoroutine("TallerItem");
    }

    private void CollideSpeedUpItem(Collider other) //속도업 아이템
    {
        Destroy(other.gameObject);
        windshield.StartItemCoroutine("SpeedUpItem");
    }

    //if (other.gameObject.CompareTag("Item"))
    //{
    //    if (GetItemType().Equals("TallerItem"))
    //        CollideTallerItem(other);
    //    else
    //        CollideSpeedUpItem(other);
    //}

    //private string GetItemType()
    //{
    //    if (Random.Range(0f, 1f) > 0.5)
    //    {
    //        Debug.Log("Get TallerItem");
    //        return "TallerItem";
    //    }
    //    else
    //    {
    //        Debug.Log("Get SpeedUpItem");
    //        return "SpeedUpItem";
    //    }
    //}
}