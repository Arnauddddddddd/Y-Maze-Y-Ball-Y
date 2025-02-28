using UnityEngine;

public class LevelManager : MonoBehaviour
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
    

    public void SwitchLevel()
    {
        playground.transform.Find("Level " + currentlevel.ToString()).gameObject.SetActive(false);
        GetComponent<BallInteractions>().Respawn();
        currentlevel++;

        if (currentlevel > 3)
        {
            Application.Quit();
        }

        playground.transform.Find("Level " + currentlevel.ToString()).gameObject.SetActive(true);
    }
}
