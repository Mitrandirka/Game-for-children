using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UI_Manager : MonoBehaviour
{
    private GameObject UI;

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex > 0)
        {
            UI = GameObject.FindWithTag("UI");
            UI.SetActive(false);
        }
    }
    private void Update()
    {
        if (Game_Controller_ABC.vin == true)
        {
            UI.SetActive(true);
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Meny()
    {
        SceneManager.LoadScene(0);
    }
    public void Next()
    {
        SceneManager.LoadScene(1);
    }
}
