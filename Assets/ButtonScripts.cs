using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScripts : MonoBehaviour {

    public GameObject panel;

    public void QuitButton()
    {
        panel.SetActive(true);
    }

    public void CancelQuit()
    {
        panel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
	
    public void LoadLevel()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Test");
    }
}
