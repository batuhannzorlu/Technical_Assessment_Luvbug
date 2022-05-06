using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Fish 
{
   public int speed = 10;
   public NavMeshAgent nav;
   int i = 0;
   public int ValueofFish;
   
    public int HangAround(Transform[] locations,Transform fish_position)
    {
        
        nav.enabled = true;
        if (nav.isOnNavMesh)
        {

            if (Vector3.Distance(fish_position.position,locations[i].position)<5)
            {

                if (locations.Length - 1 == i)
                    i = 0;
                else
                    i++;/* = Random.Range(0,locations.Length);*/                   

            }
            else
            {
                nav.SetDestination(locations[i].position);
            }
        }

        return i;
    }



}
