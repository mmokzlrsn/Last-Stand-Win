using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private float speed = 2.0f;
    private GameObject centerPoint;
    private float powerUpStrength = 10.0f;
    private bool hasPowerUp = false;
    private float powerUpTime = 7;
    public GameObject powerUpIndicatior;
    private Vector3 powerUpIndicatiorPos = new Vector3(0, -0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        centerPoint = GameObject.Find("CenterPoint");

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        PowerUpDisplay();
    }

    void Move()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRB.AddForce(centerPoint.transform.forward * forwardInput * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PowerUp"))
        {
            powerUp(other);
        }
    }

    void powerUp(Collider other)
    {
        hasPowerUp = true;
        powerUpIndicatior.gameObject.SetActive(true);
        Destroy(other.gameObject);
        StartCoroutine(PowerupCountdownRoutine());
    }


    void PowerUpDisplay()
    {
        powerUpIndicatior.transform.position = transform.position + powerUpIndicatiorPos;
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(powerUpTime);
        powerUpIndicatior.gameObject.SetActive(false);
        hasPowerUp = false;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") & hasPowerUp)
        {
            powerUpPush(collision);
        
        }
    }

    void powerUpPush(Collision collision)
    {
        Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

        enemyRB.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
    }
}
