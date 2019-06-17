using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Windshield windshield;
    public GameObject player;
    public GameObject body;
    public GameObject rightController;

    public float velocity = 2f;
    public bool walking = false;

    [SerializeField]
    private CharacterController controller;
    private SteamVR_Action_Boolean act;
    private Clicker cliker = new Clicker();

    private Vector3 moveDirection = Vector3.zero;
    public string sceneName;

    void Start()
    {
        act = SteamVR_Input.GetBooleanAction("GrabPinch");
        sceneName = SceneManager.GetActiveScene().name;
        LocatePlayer();
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!BoolStates.isCount)
        {
            //if (cliker.clicked())
            if (act.GetStateUp(SteamVR_Input_Sources.RightHand))
                walking = !walking;
        }

        if (walking)
            moveDirection = rightController.transform.rotation * Vector3.forward * velocity;
        else
            moveDirection = Vector3.zero;

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
        if (sceneName == "Stage1")
            player.transform.position = Spot.spots[0];
        else if (sceneName == "Stage2")
            player.transform.position = Spot.spots[1];
        else if (sceneName == "Stage3")
            player.transform.position = Spot.spots[2];
        else if (sceneName == "Stage4")
            player.transform.position = Spot.spots[3];
    }

    private void CollideTrophy(Collider other) //트로피 얻었을 때
    {
        walking = !walking;
        Destroy(other.gameObject);
        StartCoroutine(windshield.GoToTheNextStage(3f));
    }

    private void CollideTallerItem(Collider other) //키커지는 아이템
    {
        Destroy(other.gameObject);
        body.transform.position = new Vector3(player.transform.position.x, 6f, player.transform.position.z);
        windshield.StartItemCoroutine("TallerItem");
    }

    private void CollideSpeedUpItem(Collider other) //속도업 아이템
    {
        Destroy(other.gameObject);
        windshield.StartItemCoroutine("SpeedUpItem");
    }
}