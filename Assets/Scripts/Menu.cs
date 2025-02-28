using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeSceneStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Quit()
    {
    #if UNITY_EDITOR
        EditorApplication.isPlaying = false; // Arrête le mode Play dans l'éditeur
    #else
        Application.Quit(); // Ferme le jeu dans une build
    #endif
    }
}
