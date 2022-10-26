using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float velocity;
    public float x;
    public float sides;
    public float impulseZ;
    public float impulseY;
    public bool left;
    public bool right;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void ButtonRightDown()
    {
        right = true; sides = +x;
    }
    public void ButtonRightUp()
    {
        right = false; sides = 0;
    }
    public void ButtonLeftDown()
    {
        left = true; sides =- x;
    }
    public void ButtonLefttUp()
    {
        left = false; sides = 0;
    }

    public void Move()
    {

        Vector3 direction = new Vector3(transform.position.x + sides, transform.position.y, transform.position.z + velocity);

        //transform.position = new Vector3(direction.x, transform.position.y, direction.y);
        rb.position = direction;
        //rb.AddForce(direction.x, transform.position.y, direction.y, ForceMode.Force);
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Impulsores"))
        {
            Debug.Log("ds");
            rb.AddForce(transform.position.x, transform.position.y + impulseY, transform.position.z * impulseZ, ForceMode.Impulse);
        }
    }
}