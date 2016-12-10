using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menurules : MonoBehaviour
{
    public Button ExitButton;
    public Button ContinueButton;
    public Control control;


    void Start()
    {
        ExitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Menu");
        });
        ContinueButton.onClick.AddListener(() =>
        {
            control.Checkpaused();
        });
    }

    public void Rules()
    {

    }
}
