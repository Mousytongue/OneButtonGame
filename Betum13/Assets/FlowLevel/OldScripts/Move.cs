using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    const float MAX_TIME_HELD = 2f;
    const float MIN_FORCE = 1.25f;
    bool grounded = false; 
    float timeHeld;
    Rigidbody rb;
    Vector3 angle = new Vector3(1, 2, 0).normalized;

	void Start ()
    {
        timeHeld = 0f;
        rb = GetComponent<Rigidbody>();
	}

	void Update ()
    {
        if (grounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (timeHeld > MAX_TIME_HELD)
                    Launch();
                else
                    timeHeld += Time.deltaTime;
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                Launch();
            }
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = false;
    }

    void Launch()
    {
        if (timeHeld > MAX_TIME_HELD)
            timeHeld = MAX_TIME_HELD;
        rb.AddForce(angle * (timeHeld + MIN_FORCE), ForceMode.Impulse);
        timeHeld = 0f;
    }
}
