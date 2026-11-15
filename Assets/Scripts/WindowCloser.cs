using UnityEngine;

/*
This class is used when clicking on a button should close a window
*/
public class WindowCloser : MonoBehaviour
{
    // UI Window Canvas/Panel object that should close. 
    // The initial value is set in the Inspector window
    [SerializeField] private GameObject window;

    /*
    This runs automatically when the button containing this code is clicked.
    It will close the window stored in the window field
    */
    public void CloseWindow()
    {
        if (window != null) // assures window object was assigned in inspector
        {
            window.SetActive(false); 
        }
    }
}
