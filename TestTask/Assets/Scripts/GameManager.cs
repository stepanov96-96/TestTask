using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static Action<float, int, int> playerOption;
    public static Action<float, float,int> spawOption;


    [Range(2, 5)]
    [SerializeField] private float speedPlayer;
    [SerializeField] private int Health;
    [SerializeField] private int score;


    [Header("crystal settings")]
    [Range(.2f, 1f)]
    [SerializeField] float densitySpawCrystals;
    [SerializeField] float timeSpawCrystal;
    [Range(5f, 50f)]
    [SerializeField] int crystalCount;




    // Start is called before the first frame update
    void Start()
    {
        Option();
        SpawnObj();
        
    }
    private void Option() 
    {
        playerOption?.Invoke(speedPlayer, Health, score);
        spawOption?.Invoke(densitySpawCrystals, timeSpawCrystal, crystalCount);
    }

    private void SpawnObj() 
    {

    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
