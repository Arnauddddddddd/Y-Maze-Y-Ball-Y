using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{

    public float rotationSpeed = 50f;
    public float moveHeight = 0.3f;
    public float moveSpeed = 1.5f;

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        float newY = Mathf.Sin(Time.time * moveSpeed) * moveHeight;
        transform.localPosition = new Vector3(startPosition.x, startPosition.y + newY, startPosition.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            if (other.gameObject.TryGetComponent(out BallInteractions otherScript))
            {
                otherScript.Collectable();
                Destroy(gameObject);
            }
        }
    }
}
