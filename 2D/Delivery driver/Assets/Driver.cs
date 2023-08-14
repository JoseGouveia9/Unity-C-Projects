using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 0.3f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 10f;
    [SerializeField] float boostSpeed = 25f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = 0;

        transform.Translate(0, speedAmount, 0);

        if(speedAmount != 0)
        {
            steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            if(speedAmount > 0) {
                transform.Rotate(0, 0, -steerAmount);
            } else if (speedAmount < 0) {
                transform.Rotate(0, 0, steerAmount);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        } 
    }
}
