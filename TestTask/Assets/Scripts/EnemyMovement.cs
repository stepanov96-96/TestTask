using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField]private GameObject path;

    private NavMeshAgent enemy;

    public static Func<int, Transform> paths;

    private int idEnemy;
    public void Init() 
    {
        //path = paths?.Invoke(idEnemy);
        print(path);
    }

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        Instantiate(path, this.transform.position, Quaternion.identity);
        //Init();
    }
    private void Update()
    {
        enemy.destination = this.path.transform.position;
    }

}
