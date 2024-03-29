using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public string sceneName; // Name of the scene to transition to
    
    private InventorySystem inventory; // The backend inventory variable

    private void Start()
    {
        inventory = FindObjectOfType<InventorySystem>();
        if (inventory == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && inventory.findItem("Solar Electric Propulsion") && sceneName == "GameScene2")
        {
            if (GameObject.Find("HintText"))
            {
                GameObject.Find("HintText").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("HintText2").GetComponent<TextMeshProUGUI>().enabled = false;
            }
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (other.CompareTag("Player") && sceneName == "GameScene2")
            {
                if (GameObject.Find("HintText"))
                {
                    GameObject.Find("HintText2").GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("HintText").GetComponent<TextMeshProUGUI>().enabled = true;
                }
            }
        }
        if (other.CompareTag("Player") && inventory.findItem("Gamma Ray Spectrometer") && sceneName == "GameScene3")
        {
            if (GameObject.Find("HintText2"))
            {
                GameObject.Find("HintText").GetComponent<TextMeshProUGUI>().enabled = false;
                GameObject.Find("HintText2").GetComponent<TextMeshProUGUI>().enabled = false;
            }
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            if (other.CompareTag("Player") && sceneName == "GameScene3")
            {
                if (GameObject.Find("HintText2"))
                {
                    GameObject.Find("HintText").GetComponent<TextMeshProUGUI>().enabled = false;
                    GameObject.Find("HintText2").GetComponent<TextMeshProUGUI>().enabled = true;
                }
            }
        }
    }
}
