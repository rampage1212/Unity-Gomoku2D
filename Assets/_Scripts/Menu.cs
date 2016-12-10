using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{ 
    public Button StartButton;
    public Button ExitButton;
    public Button Startia;

    // Use this for initialization
    void Start()
    {
        StartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gomoku");
            //Application.LoadLevel("Gomoku");
        });
        ExitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
