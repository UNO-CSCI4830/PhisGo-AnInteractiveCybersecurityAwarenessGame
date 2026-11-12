using UnityEngine;

/*
This class is used for the buttons that the user clicks to label emails as
safe or a scam. It will check whether the answer is correct, change the user's points
accordingly, and also make a pop-up telling the user how they did.
*/
public class ScoreButtonHandler : MonoBehaviour
{
    // UI Window Canvas/Panel object that should pop up. There is one for correct and one
    // for incorrect answers. 
    // The initial value is set in the Inspector window
    //[SerializeField] private GameObject popupForCorrect; 
    //[SerializeField] private GameObject popupForInorrect; 

    // Holds which answer type this button signifies. 0 for scam, 1 for safe
    // The initial value is set in the Inspector window
    [SerializeField] private int buttonStatus;

    /*
    This method runs when the button is clicked. It will check the correctness of the answer
    and then handle the resulting score change and pop-up window
    */
    public void OnButtonClicked()
    {
        // Case where no email has been selected
        if (GameData.getCurrentEmailIndex() < 0)
        {
            // do nothing
        }
        // Case where answer is correct
        else if(buttonStatus ==  GameData.emailStatus[GameData.getCurrentEmailIndex()])
        {
            // show pop-up for correct
            /* TO ADD LATER
            if (popupForCorrect != null)
            {
                popupForCorrect.SetActive(true);
            }
            */
        // Case where answer is incorrect
        } else {
            // show pop-up for incorrect
            /* TO ADD LATER
            if (popupForInorrect != null)
            {
                popupForInorrect.SetActive(true);
            }
            */
            // user loses points
            ScoreManager.Instance.LosePoints();
        }        
    }
}
