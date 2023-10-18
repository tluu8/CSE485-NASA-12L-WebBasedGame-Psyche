using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{   

    // Start game function
    public void StartGameButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Credit button function
    public void CreditButton() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Bakc button function
    public void BackButton()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }

}
