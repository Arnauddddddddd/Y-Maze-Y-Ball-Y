
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BallInteractions : MonoBehaviour
{

    private Rigidbody rb;
    private int currentlevel = 1;
    GameObject playground;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playground = GameObject.Find("Playground");
        playground.transform.Find("Level 1").gameObject.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.transform.position.y < -10) {
            Respawn();
        }
    }

    void Respawn() {
        rb.velocity = Vector3.zero;
        rb.transform.position = new Vector3(0, 50.0f, 0);
    }

    void RandomTeleportation() {
        rb.transform.position = new Vector3(Random.Range(-40, 40), 50.0f, Random.Range(-40, 40));
    }

    private void OnTriggerEnter(Collider other) {
        switch (other.gameObject.tag)
        {
            case "red":
                Respawn();
                break;
            case "purple":
                RandomTeleportation();
                break;
            case "yellow":
                playground.transform.Find("Level " + currentlevel.ToString()).gameObject.SetActive(false);
                Respawn();
                currentlevel++;
                playground.transform.Find("Level " + currentlevel.ToString()).gameObject.SetActive(true);
                break;
        }
    }
}
