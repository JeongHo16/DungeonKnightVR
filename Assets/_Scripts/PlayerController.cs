using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerController : MonoBehaviour
{
    public Windshield windshield;
    public GameObject player;
    public GameObject body;
    public GameObject rightController;
    //public GameObject tester;

    public float velocity = 1f;
    public bool walking = false;

    private SteamVR_Action_Boolean act;
    [SerializeField]
    private CharacterController controller;
    private Clicker cliker = new Clicker();

    private Vector3 moveDirection = Vector3.zero;
    private int stageNum = 1;

    void Start()
    {
        //controller = GetComponent<CharacterController>();
        act = SteamVR_Input.GetBooleanAction("GrabPinch");
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
            //if (act.GetState(SteamVR_Input_Sources.RightHand))
            if (cliker.clicked())
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
        {
            //LocatePlayer();
            CollideTrophy(other);
        }

        if (other.gameObject.CompareTag("TallerItem"))
            CollideTallerItem(other);
        else if (other.gameObject.CompareTag("SpeedItem"))
            CollideSpeedUpItem(other);
    }

    public void LocatePlayer()
    {
        if (stageNum != 4)
        {
            //controller.transform.position = Spot.spots[stageNum - 1];
            player.transform.position = Spot.spots[stageNum - 1];
            stageNum += 1;
            Debug.Log(stageNum);
        }
    }

    private void CollideTrophy(Collider other) //트로피 얻었을 때
    {
        //LocatePlayer();
        walking = !walking;
        Destroy(other.gameObject);
        StartCoroutine(windshield.GoToTheNextStage(3f, "<b>Stage Claer</b>"));
        //LocatePlayer();
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

    //private void MovePlayer()
    //{
    //    Transform direction = rightController.transform;
    //    Ray ray;
    //    RaycastHit[] hits;
    //    GameObject hitObject;

    //    ray = new Ray(direction.position, direction.rotation * Vector3.forward * 100.0f);

    //    hits = Physics.RaycastAll(ray);

    //    RaycastHit hit = hits[0];
    //    hitObject = hit.collider.gameObject;
    //    if (hitObject != player)
    //    {
    //        Debug.Log(hitObject);
    //        if (/*act.GetState(SteamVR_Input_Sources.RightHand)*/walking)
    //        {
    //            float elapsedTime = 0f;
    //            while (elapsedTime < velocity)
    //            {
    //                Vector3 targetPos = new Vector3(hit.point.x, 1.5f, hit.point.z);
    //                elapsedTime += Time.deltaTime;
    //                player.transform.position = Vector3.Lerp(Vector3.zero, targetPos, elapsedTime / 10f);
    //            }
    //            //player.transform.position = new Vector3((Mathf.Lerp(player.transform.position.x, hit.point.x, player.transform.position.x / hit.point.x), 1.5f, hit.point.z);
    //            //if (player.transform.position.x < hit.point.x)
    //            //{
    //            //    player.transform.Translate(Vector3.right * velocity * Time.deltaTime);
    //            //}
    //            //else if (player.transform.position.x > hit.point.x)
    //            //{
    //            //    player.transform.Translate(Vector3.left * velocity * Time.deltaTime);
    //            //}

    //            //if (player.transform.position.z < hit.point.z)
    //            //{
    //            //    player.transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    //            //}
    //            //else if (player.transform.position.z > hit.point.z)
    //            //{
    //            //    player.transform.Translate(Vector3.back * velocity * Time.deltaTime);
    //            //}

    //            //letsgo.transform.position = new Vector3(hit.point.x, 0.01f, hit.point.z);
    //        }
    //        //else
    //        //{
    //        //    letsgo.transform.position = new Vector3(0.0f, -1.0f, 0.0f);
    //        //}
    //    }
    //}
    //private void MovePlayer()
    //{
    //    if (!BoolStates.isCount)
    //    {
    //        if (cliker.clicked())
    //            walking = !walking;
    //    }

    //    if (walking)
    //    {
    //        //moveDirection = Camera.main.transform.forward * velocity;
    //        moveDirection = rightController.transform.rotation * Vector3.forward * velocity;
    //    }
    //    else
    //        moveDirection = Vector3.zero;

    //    //if (controller.isGrounded)
    //    //    verticalVelocity = 0.0f;

    //    //moveDirection.y = verticalVelocity;
    //    //verticalVelocity -= gravity * Time.deltaTime;

    //    controller.Move(moveDirection * Time.deltaTime);
    //}

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