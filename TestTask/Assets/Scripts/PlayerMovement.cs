using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    private Camera mainCamera;
    private NavMeshAgent agent;

    private float speedPlayer;
    private int healthPlayer;

    //public GameObject testdistance;


    private int currentScore;
    private int scorePl;

    private void Awake()
    {
        Instance = this;
        GameManager.playerOption += InitPlOption;
    }

    public void PlayerTreatment()
    {
        if (healthPlayer < 3)
            healthPlayer++;
        currentScore += scorePl;
        print(currentScore);
    }  

    private void Start()
    {
        mainCamera = Camera.main;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 3;// speedPlayer;

        //NavMesh.SamplePosition();
    }


    //private void OnEnable() => GameManager.playerOption += InitPlOption;

    private void OnDisable() => GameManager.playerOption -= InitPlOption;


    private void InitPlOption(float speed, int health, int score) 
    {
        speedPlayer = speed;
        healthPlayer = health;
        scorePl = score;
    }

    private void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            print("on");
            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                print("yes");
                agent.SetDestination(hit.point);
            }


        }
        // test dist
        //float dist = Vector3.Distance(testdistance.transform.position, transform.position);
        //print(dist);
    }
}
