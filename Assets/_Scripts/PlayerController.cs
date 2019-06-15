using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Windshield windshield;
    public GameObject player;
    public GameObject body;

    public float velocity = 0.7f;
    public bool walking = false;

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
        if (BoolStates.isCount)
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
        CollideTrophy(other);
        CollideTallerItem(other);
    }

    private void CollideTrophy(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            walking = !walking;
            Destroy(other.gameObject);
            StartCoroutine(windshield.ShowTextForShortTime(3f, "<b>Stage Claer</b>"));
        }
    }


    private void CollideTallerItem(Collider other)
    {
        if (other.gameObject.CompareTag("TallerItem"))
        {
            body.transform.position = new Vector3(player.transform.position.x, 3f, player.transform.position.z);
            Destroy(other.gameObject);
            StartCoroutine(windshield.TallerTime());
            body.transform.position = new Vector3(player.transform.position.x, 1f, player.transform.position.z);
        }
    }

    //private void CollideGhost(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Ghost"))
    //    {
    //        windshield.AttackedByGhost();
    //        Destroy(other.gameObject);
    //    }
    //}

    //private IEnumerator EventTime()
    //{

    //}
}
