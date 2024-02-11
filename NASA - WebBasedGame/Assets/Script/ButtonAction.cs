using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    public GameObject PausePanel;   // Create object shown on Unity inspector

    // Move from menu scene to the first game scene
    public void StartGameButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Move from menu scene to the credit scene
    public void CreditButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //Move from credit scene to the menu scene
    public void BackButton() { 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    //Move from intro scene to the game scene
    public void ContinueButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Move from game scene 1 to title menu scene
    public void BackButton1() {

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }

    // Show pause menu after clicking on pause button
    public void Pause() { 

        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    // Close the pause menu and continue the game after clicking on resume button
    public void Resume() {

        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

}
