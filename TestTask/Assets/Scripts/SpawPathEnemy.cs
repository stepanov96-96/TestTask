using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawPathEnemy : MonoBehaviour
{


    private Collider[] colliders;

    private Vector3 sizeCol = new Vector3(.5f, 0.35f,.5f );

    private bool checkSpawPos;
    private Transform enemypath;
    private int idPath;
    private void Awake()
    {
    }

    //private void OnDisable() => EnemyMovement.paths -= inits;
    //private void OnDisable() => EnemyMovement.paths -= inits;
    //private void OnEnable() => EnemyMovement.paths += inits;
    //private void OnEnable() => EnemyMovement.paths += inits;

    private Transform inits(int id) 
    {
        Transform tr = this.enemypath;
        return tr ;
    }

    private float x()
    {
        float x = Random.Range(-1, 1);
        return x;
    }
    private float z()
    {
        float z = Random.Range(-1, 1);
        return z;
    }

    private void Start()
    {
        SpawPath();

    }

    void SpawPath() 
    {
        gameObject.transform.position = new Vector3(x(), 0.5f, z());
        checkSpawPos = CheckSpawnPoint(gameObject.transform.position);

        if (checkSpawPos)
            SpawPath();
        
    }

    private bool CheckSpawnPoint(Vector3 spawnPos)
    {
        colliders = Physics.OverlapBox(spawnPos, sizeCol);

        if (colliders.Length > 0)
        {
            return false;
        }
        else
            return true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            SpawPath();
        }
    }
}
