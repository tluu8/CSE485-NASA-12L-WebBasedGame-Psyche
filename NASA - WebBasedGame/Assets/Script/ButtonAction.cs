using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{   

    // Click this button to move to the first game scene
    public void StartGameButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Click this button to move to the credit scene
    public void CreditButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Click this button to move back to the menu scene
    public void BackButton() { 

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    
}
