using UnityEngine;

public class SpriteClickWindow : MonoBehaviour
{
    // Drag the UI Window Canvas/Panel into this slot in the Inspector
    [SerializeField] private GameObject uiWindow; 

    // This runs automatically when the sprite is clicked
    private void OnMouseDown()
    {
        if (uiWindow != null)
        {
            uiWindow.SetActive(true); // Shows the window
        }
    }
}
