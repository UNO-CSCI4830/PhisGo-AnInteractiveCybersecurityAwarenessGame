using UnityEngine;

public class WindowCloser : MonoBehaviour
{
    // Drag the UI Window Canvas/Panel into this slot in the Inspector
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
