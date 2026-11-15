using UnityEngine;
using TMPro;

/*
This class is used for the buttons that the user clicks to label emails as
safe or a scam. It will check whether the answer is correct, change the user's points
accordingly, and also make a pop-up telling the user how they did.
*/
public class ScoreButtonHandler : MonoBehaviour
{
    // Text object that should pop up with feedback
    // The initial value is set in the Inspector window
    [SerializeField] private TextMeshProUGUI popupText; 

    // UI Window Canvas/Panel object that ccontains the feedback text
    // The initial value is set in the Inspector window
    [SerializeField] private GameObject popupWindow; 

    // Holds which answer type this button signifies. 0 for scam, 1 for safe
    // The initial value is set in the Inspector window
    [SerializeField] private int buttonStatus;

    /*
    This method runs when the button is clicked. It will check the correctness of the answer
    and then handle the resulting score change and pop-up window with feedback
    */
    public void OnButtonClicked()
    {
        int currentIndex = GameData.getCurrentEmailIndex(); // store to reuse more easily

        // Case where no email has been selected
        if (currentIndex < 0)
        {
            // display window with feedback
            makePopUp("Please select an email from the inbox");
        }
        // Case where user already finished this email
        else if(ProgressTracker.IsComplete(currentIndex))
        {
            // display window with feedback
            makePopUp("You have already completed this email");
        }
        // Case where answer is correct
        else if(buttonStatus ==  GameData.getEmailStatus(currentIndex))
        {
            // display window with feedback
            makePopUp("That's correct! Good job.");

            // Mark this location complete
            ProgressTracker.MarkComplete(currentIndex);
            
        // Case where answer is incorrect
        } else {
            // display window with feedback
            makePopUp("Incorrect. Check the notepad for tips!");
            
            // user loses points
            ScoreManager.Instance.LosePoints();

            // Mark this location complete
            ProgressTracker.MarkComplete(currentIndex);
        }        
    }

    /*
    This method sets a new message for the pop-up window and displays it
    */
    private void makePopUp(string message)
    {
        // set text for window
        popupText.text = message;
        // show pop-up
        if (popupWindow != null)
        {
            popupWindow.SetActive(true);
        }
    }
}
