
using UnityEngine;

public class BallInteractions : MonoBehaviour
{

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.transform.position.y < -20) {
            Respawn();
        }
    }

    public void Respawn() {
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
                GetComponent<LevelManager>().SwitchLevel();
                break;
        }
    }

    public void Collectable()
    {
        Debug.Log("OUIIII GG MA COUILLE !!");
    }
}
