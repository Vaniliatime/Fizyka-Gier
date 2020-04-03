using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    [SerializeField] Transform topMarker;
    [SerializeField] Transform bottomMarker;
    [SerializeField] Transform lift;
    [SerializeField] Transform player;

    public float speed = 1.0f;

    private float startTime;
    private float distanceDifference;
    private bool tFlipFlop;

    [HideInInspector]
    public float jumpSpeedMultiplier;

    void Start()
    {
        // set the initial value of lift movement direction switcher
        tFlipFlop = true;

        // set the initial value of jump impulse power multiplier
        jumpSpeedMultiplier = 1.0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            // keep a note of the time the movement started
            startTime = Time.time;

            // calculate the difference between origin point and destination point
            distanceDifference = Vector3.Distance(bottomMarker.position, topMarker.position);

            // set the jump impulse power multiplier to 0.2
            jumpSpeedMultiplier = 0.8f;

            // parent player to the lift
            player.transform.parent = lift.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        // check if player is the object inside the trigger
        if (other.tag.Equals("Player"))
        {
            float elapsedTime = Time.time - startTime;
            float distanceFraction = elapsedTime / distanceDifference;

            // proceed to the desired destination point
            if (tFlipFlop)
                lift.position = Vector3.Lerp(bottomMarker.position, topMarker.position, 1 - distanceFraction);
            else
                lift.position = Vector3.Lerp(topMarker.position, bottomMarker.position, 1 - distanceFraction);
        }
    }
    void OnTriggerExit()
    {
        // reverse the lift movement direction
        tFlipFlop = !tFlipFlop;

        // restore the default value of jump impulse power multiplier
        jumpSpeedMultiplier = 1.0f;

        // undo parenting player to the lift
        player.transform.parent = null;
    }
}
