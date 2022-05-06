using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject[] Fishes;
    public GameObject[] SpawnLocations;

    float fishspawntimer = 5;
    float currenttime = 0;

    private void Start()
    {

    }


    private void Update()
    {

        FishSpawner();
        currenttime += Time.deltaTime;
    }

    void FishSpawner()
    {
        if (currenttime > fishspawntimer)
        {
            int a = Random.Range(0, Fishes.Length);
            int b = Random.Range(0, SpawnLocations.Length);
            Instantiate(Fishes[a], SpawnLocations[b].transform.position+new Vector3(0,2,0), Quaternion.identity);
            currenttime = 0;
        }


    }
  
        }

