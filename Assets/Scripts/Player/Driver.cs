using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 300f;
    [SerializeField] float forwardSpeed = 20f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float alteredSpeedTimer = 0f;
    [SerializeField] bool isSpeedAltered;

    private void Start()
    {

    }

    private void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * forwardSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boost"))
        {
            forwardSpeed = boostSpeed;
            isSpeedAltered = true;
            alteredSpeedTimer += Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            forwardSpeed = slowSpeed;
            isSpeedAltered = true;
            alteredSpeedTimer += Time.deltaTime;
        }
    }

    private void ReturnSpeedToDefault()
    {
        if (alteredSpeedTimer >= 2f)
        {
            alteredSpeedTimer = 0f;
            isSpeedAltered = false;
            boostSpeed = 20f;
        }
    }
}
