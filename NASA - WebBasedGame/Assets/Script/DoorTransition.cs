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
        if (other.CompareTag("Player") && inventory.findItem("Xenon Rocket Engines") && sceneName == "GameScene2")
        {
            SceneManager.LoadScene(sceneName);
        }
        else if (other.CompareTag("Player") && inventory.findItem("Gamma Ray Spectrometer") && sceneName == "GameScene3")
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
