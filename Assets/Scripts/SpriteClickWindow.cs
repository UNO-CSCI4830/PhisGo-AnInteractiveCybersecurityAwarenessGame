using UnityEngine;

/*
This class is used when clicking on a sprite should open a new window
*/
public class SpriteClickWindow : MonoBehaviour
{
    // UI Window Canvas/Panel object that should pop up. 
    // The initial value is set in the Inspector window
    [SerializeField] private GameObject uiWindow; 

    /*
    This runs automatically when the sprite containing this code is clicked.
    It will show the window stored in uiWindow
    */
    private void OnMouseDown()
    {
        if (uiWindow != null) // assures uiWindow object was assigned in inspector
        {
            uiWindow.SetActive(true);           
        }
    }
}
