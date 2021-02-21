using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveRocket : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotateSpeed = 2f;
    [SerializeField] private Rigidbody rocketRb;
    [SerializeField] private ParticleSystem fireParticle;

    private Rigidbody _RocketRb;



    // Start is called before the first frame update
    void Start()
    {
        if (rocketRb == null)
        {
            _RocketRb = this.gameObject.GetComponent<Rigidbody>();
        }
        else
        {
            _RocketRb = rocketRb;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            TurnLeft();
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            TurnRight();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            RocketActive();
        }
        else
        {
            fireParticle.Stop();
        }
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fuel"))
        {
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene(0);
        }
    }

    */

    private void TurnRight()
    {
        transform.Rotate(Vector3.right * (Time.deltaTime * rotateSpeed));
    }

    private void TurnLeft()
    {
        transform.Rotate(Vector3.left * (Time.deltaTime * rotateSpeed));
    }


    private void RocketActive()
    {
        

        _RocketRb.AddRelativeForce(Vector3.up * (speed * Time.deltaTime));

        fireParticle.Play();
    }


}
