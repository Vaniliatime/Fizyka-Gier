using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControll : MonoBehaviour
{



    public Rigidbody rb;
    public void AddForce(Vector3 direction, float power)
    {
        rb.AddForce(direction * power, ForceMode.Impulse);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision other)
    {
        var rb = other.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            var joint = rb.gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = this.rb;
        }
    }
}