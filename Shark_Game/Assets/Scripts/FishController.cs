using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class FishController : MonoBehaviour
{

    public Fish fish;
    public Transform[] WanderPositions;
    public Rigidbody m_Rb;



    void Start()
    {
        m_Rb = this.GetComponent<Rigidbody>();

        switch (this.tag)
        {
            case "BigPoisoned":
                fish = new BigPoisonedFish();

                fish.nav = this.GetComponent<NavMeshAgent>();
                break;
            case "Poisoned":
                fish = new PoisonedFish();
                fish.nav = this.GetComponent<NavMeshAgent>();
                break;

            case "Healthy":
                fish = new HealthyFish();
                fish.nav = this.GetComponent<NavMeshAgent>();
                break;
            default:
                break;
        }
    }


    void Update()
    {
       int i = fish.HangAround(WanderPositions,this.transform);
        transform.LookAt(WanderPositions[i]);
        transform.rotation *= Quaternion.Euler(0, 90, 0);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.layer == layerToIgnore)
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
    }

}
