using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shark : MonoBehaviour
{

    int Health =100;
    
    public float speed = 8.0f;
    public Camera followCamera;

    private Rigidbody m_Rb;
    private Vector3 m_CameraPos;

    public Text Healthtxt;
    void Awake()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_CameraPos = followCamera.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(movement);

        targetRotation.eulerAngles += new Vector3(0, 90, 0);
        targetRotation = Quaternion.RotateTowards(
            transform.rotation,
            targetRotation,
            360 * Time.fixedDeltaTime);

        m_Rb.MovePosition(m_Rb.position + movement * speed * Time.fixedDeltaTime);

        
        m_Rb.MoveRotation(targetRotation);
    }

    private void LateUpdate()
    {
        followCamera.transform.position = m_Rb.position + m_CameraPos;
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.GetComponent<BoxCollider>().tag == "Poisoned" || other.GetComponent<BoxCollider>().tag == "BigPoisoned" || other.GetComponent<BoxCollider>().tag == "Healthy")
        {
            if (Mathf.Abs(other.GetComponent<FishController>().fish.ValueofFish) >= this.Health)
            {
                Health = 0;
                Debug.Log("GAME OVER");
            }
            else
            {
                this.Health += other.GetComponent<FishController>().fish.ValueofFish;
                if (this.Health<50)
                    Healthtxt.color = Color.red;
                Healthtxt.text = "HEALTH : " + this.Health.ToString();
            }

            Destroy(other.gameObject);
        }


    }
}
