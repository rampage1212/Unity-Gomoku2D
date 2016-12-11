using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menurules : MonoBehaviour
{
    public Button ExitButton;
    public Button ContinueButton;
    public Button Threerules;
    public Control control;


    void Start()
    {
        Threerules.onClick.AddListener(() =>
        {
            control.b_three = !control.b_three;
        });
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
