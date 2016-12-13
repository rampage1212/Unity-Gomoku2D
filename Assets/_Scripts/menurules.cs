using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menurules : MonoBehaviour
{
    public Button ExitButton;
    public Button ContinueButton;
    public Button Threerules;
    public Button Fiverules;
    public Control control;
    public Sprite croix;
    public Sprite box;


    void Start()
    {
        Threerules.onClick.AddListener(() =>
        {
            if (control.b_three == true)
            {
                Threerules.image.sprite = box;
                control.b_three = false;
            }
            else
            {
                Threerules.image.sprite = croix;
                control.b_three = true;
            }
        });
        Fiverules.onClick.AddListener(() =>
        {
            if (control.b_five == true)
            {
                Fiverules.image.sprite = box;
                control.b_five = false;
            }
            else
            {
                Fiverules.image.sprite = croix;
                control.b_five = true;
            }
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
