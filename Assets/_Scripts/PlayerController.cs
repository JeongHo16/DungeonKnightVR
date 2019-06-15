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

    //public float gravity = 9.8f;

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
        MovePlayer();
    }

    private void MovePlayer()
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
        CollideTrophy(other);
        //CollideGhost(other);
        CollideTallerItem(other);
    }

    private void CollideTrophy(Collider other)
    {
        if (other.gameObject.CompareTag("Trophy"))
        {
            walking = !walking;
            //controller.Move(Spot.firstSpot);
            //controller.Move(new Vector3(3.0f, 0.5f, 3.0f));
            Destroy(other.gameObject);
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

    //private IEnumerator EventTime()
    //{

    //}
}
