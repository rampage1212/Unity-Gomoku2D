using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class resultat : MonoBehaviour
{

    public Button ReplayButton;
    public Button ExitButton;
    public Control control;
    public Text Winner;

    void Start()
    {
        Winner.text = ("Le Joueur " + control.playerwin + " gagne");
        ExitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu");
        });
        ReplayButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Gomoku");
        });
    }
}
