using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    void OnDrawGizmos()
    {

        float maxDistance = 10f;
        RaycastHit hit;

        bool isHit = Physics.Raycast(origin: transform.position, direction: transform.forward, out hit, maxDistance);

        if (isHit)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * hit.distance);


        }

        else
        {
            Gizmos.color = Color.green;
            Gizmos.DrawRay(from: transform.position, direction: transform.forward * maxDistance);
        }

    }
}
