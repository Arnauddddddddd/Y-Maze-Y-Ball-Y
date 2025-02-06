
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BallInteractions : MonoBehaviour
{

    private Rigidbody rb;
    private GameObject[] levels;
    private int currentlevel = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        levels = GameObject.FindGameObjectsWithTag("level");
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(true);
        }
        levels[currentlevel].SetActive(false);
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
                levels[currentlevel].SetActive(true);
                Respawn();
                currentlevel++;
                levels[currentlevel].SetActive(false);
                break;
        }
    }
}
