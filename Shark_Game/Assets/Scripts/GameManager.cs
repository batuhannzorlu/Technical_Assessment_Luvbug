using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public bool IsGameOver = false;

    public GameObject[] Fishes;
    public GameObject[] SpawnLocations;

    float fishspawntimer = 5;
    float currenttime = 0;

    public GameObject mytext;
    public GameObject mybutton;

    

    GameObject player;

    private void Start()
    {

        mytext.SetActive(false);
        mybutton.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }


    private void Update()
    {
        if (!IsGameOver)
        {
            if (player.GetComponent<Shark>().Health <= 0)
            {
                IsGameOver = true;
                mytext.SetActive(true);
                mybutton.SetActive(true);
            }

            FishSpawner();
            currenttime += Time.deltaTime;
        }

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

    public void Restart()
    {
        mytext.SetActive(false);
        mybutton.SetActive(false);
        IsGameOver = false;
        player.GetComponent<Shark>().Health = 100;
        player.GetComponent<Shark>().Healthtxt.text = "HEALTH : " + player.GetComponent<Shark>().Health.ToString();
    }
  
        }

