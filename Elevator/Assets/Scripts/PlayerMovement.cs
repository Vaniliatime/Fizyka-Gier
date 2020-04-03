using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    LiftMovement liftMovementScript;

    [SerializeField] Transform player;
    [SerializeField] Rigidbody rb;
    [Range(.0f, 12.0f)] public float speed;
    [Range(.0f, 180.0f)] public float rotation;

    [HideInInspector]
    public float jumpSpeed = 4.0f;
    
    // bit shift the index of the 9th layer to get a bit mask
    private int layerMask = 1 << 9;

    void Start()
    {
        // allow the reference to the variables of objects bearing the LiftMovement script as a component
        liftMovementScript = GameObject.FindGameObjectWithTag("LiftTrigger").GetComponent<LiftMovement>();

        // invert a bit mask
        layerMask = ~layerMask;
    }

    void FixedUpdate()
    {
        // if W key pressed, move forward along the object's Z axis
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.fixedDeltaTime * speed;
        }

        // if S key pressed, move backward along the object's Z axis
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.fixedDeltaTime * speed;
        }

        // if D key pressed, rotate clockwise
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, rotation, 0) * Time.fixedDeltaTime);
        }

        // if D key pressed, rotate counterclockwise
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -rotation, 0) * Time.fixedDeltaTime);
        }

        // if SPACE ket pressed and player is grounded, thrust upward like a freaking rocket (bearing in mind the jump multiplier)
        if (Input.GetKey(KeyCode.Space))
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.6001f, layerMask))
            {
                rb.AddForce(Vector3.up * jumpSpeed * liftMovementScript.jumpSpeedMultiplier, ForceMode.Impulse);
            }
        }
    }
}
