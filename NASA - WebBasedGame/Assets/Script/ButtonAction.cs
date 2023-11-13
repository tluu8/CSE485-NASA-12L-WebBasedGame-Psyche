using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{   

    // Click this button (menu scene) to move to the first game scene
    public void StartGameButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Click this button (menu scene) to move to the credit scene
    public void CreditButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Click this button (credit scene) to move back to the menu scene
    public void BackButton() { 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

    // Click this button (intro scene) to move to the game scene
    public void ContinueButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
