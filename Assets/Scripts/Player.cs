using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            thisAnimation.Play(); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bottom") || collision.gameObject.tag.Equals("Obstacle"))
        {
            GameManager.thisManager.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Score"))
        {
            GameManager.thisManager.UpdateScore(1);
        }
    }
}
