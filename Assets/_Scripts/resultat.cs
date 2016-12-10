using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class resultat : MonoBehaviour
{

    public Button ReplayButton;
    public Button ExitButton;

    void Start()
    {
        ReplayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gomoku");
        });
        ExitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu");
        });

        if (Control.player == 1)

    }
}
