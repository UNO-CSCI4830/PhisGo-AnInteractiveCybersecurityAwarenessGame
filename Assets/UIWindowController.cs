using UnityEngine;

public class UIWindowController : MonoBehaviour
{
    // Reference to the window GameObject
    [SerializeField] private GameObject window;

    // This function will be called when the close button is clicked
    public void CloseWindow()
    {
        if (window != null)
        {
            window.SetActive(false); // Hides the window
        }
    }
}
