using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform tr;
    [SerializeField] private GameObject obj;
    public static Action<int> pathId; 
    

    private void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            Instantiate(obj, tr.position , Quaternion.identity);
            
        }
    }

    public void St(int id) 
    {
    
    }
}
