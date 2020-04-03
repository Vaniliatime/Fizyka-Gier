using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField] private ballControll ballPrefab;
    [SerializeField] private KeyCode keyShoot;

    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyShoot))
            Shoot();
    }

    private void Shoot()
    {
        var ballInstance = Instantiate(ballPrefab);
        ballInstance.transform.position = spawn.position;
        ballInstance.AddForce(spawn.forward, 50f);
    }
}