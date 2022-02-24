using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class CrystalSpawner : MonoBehaviour
{

    [SerializeField] private GameObject crystals;

    public ObservableCollection<GameObject> crystalCollection = new ObservableCollection<GameObject>();


    private Collider[] colliders;
    private Vector3 sizeCol;

    private bool checkSpawPos;
    private float timeSpawCrys;
    private int crCount;

    private void OnEnable() => GameManager.spawOption += InitAttributes;

    private void OnDisable() => GameManager.spawOption -= InitAttributes;


    private void InitAttributes(float densitySpawCrystals, float timeSpawCrystal, int crystalCount) 
    {

        sizeCol = new Vector3(densitySpawCrystals, 0.35f, densitySpawCrystals);
        timeSpawCrys = timeSpawCrystal;
        crCount = crystalCount;
        
         
        SpawCrystals();

    }
    private float x()
    {
        float x = Random.Range(-9, 9);
        return x;
    }
    private float z()
    {
        float z = Random.Range(-9, 9);
        return z;
    }
    IEnumerator SpawnerCrystals() 
    {
        //int ch=0;
        //crystalCollection[5].SetActive(false);
        //print(crystalCollection.Count);
        //while (true)
        //{
        //    float rnd = Random.Range(5, 10);
        //    int rndNumb = Random.Range(5,15);
        //    for (int i = 0; i < 10; i++ )
        //    {
        //        print("WTF");



        //    }

        yield return new WaitForSeconds(1f);

        //}

    }




    private void SpawCrystals() 
    {
        int checkLoop=0;
        
            for (int i = 0; i < crCount;)
            {

                gameObject.transform.position = new Vector3(x(), 0.5f, z());
                checkSpawPos = CheckSpawnPoint(gameObject.transform.position);


                if (checkSpawPos)
                {
                    Instantiate(crystals, gameObject.transform.position, Quaternion.identity);
                    crystalCollection.Add(crystals);
                    i++;
                }
                else
                {
                    checkLoop++;
                    if (checkLoop >= 999)
                    {
                        Debug.Log("Increase the density of crystals or increase the size of the map");
                        break;
                    }


                }
            }
        StartCoroutine(SpawnerCrystals());
        tesrt();
    }



    void tesrt() 
    {
        for (int i = 0; i < 10; i++)
        {
            crystalCollection[i].SetActive(true);
        }
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
}
