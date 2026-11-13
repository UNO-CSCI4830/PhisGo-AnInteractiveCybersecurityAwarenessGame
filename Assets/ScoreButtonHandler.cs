using UnityEngine;

/*
This class is used for the buttons that the user clicks to label emails as
safe or a scam. It will check whether the answer is correct, change the user's points
accordingly, and also make a pop-up telling the user how they did.
*/
public class ScoreButtonHandler : MonoBehaviour
{
    // Text object that should pop up with feedback
    // The initial value is set in the Inspector window
    //[SerializeField] private TextMeshProUGUI popupText; 

    // UI Window Canvas/Panel object that ccontains the feedback text
    // The initial value is set in the Inspector window
    //[SerializeField] private GameObject popupWindow; 

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
            // add pop-up window
        }
        // Case where use already finished this email
        else if(ProgressTracker.IsComplete(currentIndex))
        {
            // add pop-up window
        }
        // Case where answer is correct
        else if(buttonStatus ==  GameData.getEmailStatus(currentIndex))
        {
            // set text for correct

            // show pop-up 
            /* TO ADD LATER
            if (popupWindow != null)
            {
                popupWindow.SetActive(true);
            }
            */

            // Mark this location complete
            ProgressTracker.MarkComplete(currentIndex);
            
        // Case where answer is incorrect
        } else {
            // set text for incorrect

            // show pop-up
            /* TO ADD LATER
            if (popupWindow != null)
            {
                popupWindow.SetActive(true);
            }
            */
            // user loses points
            ScoreManager.Instance.LosePoints();

            // Mark this location complete
            ProgressTracker.MarkComplete(currentIndex);
        }        
    }
}
