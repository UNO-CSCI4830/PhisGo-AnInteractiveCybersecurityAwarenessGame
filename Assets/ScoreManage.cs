using UnityEngine;
using TMPro; // Required to control TextMeshPro elements

/*
This class stores the player's score and has methods to handle displaying and changing the
score during the game
*/
public class ScoreManager : MonoBehaviour
{
    // This public static instance of this class makes a Singleton that can be invoked later
    public static ScoreManager Instance { get; private set; }

    // Text object to display the score. The initial value is set in the Inspector window
    [SerializeField] private TextMeshProUGUI scoreText; 
    
    private int score = 100;  // begin the game with 100 points

    /*
    The Awake method runs automatically once at the beginning when the game is played.
    It sets up a single instance of this class.
    */
    void Awake()
    {
        // Establish the Singleton instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);  // prevent duplicates
        }
    }

    /*
    The Start method runs automatically once at the beginning after the awake method finishes.
    It displays the initial score text on the screen
    */
    void Start()
    {
        UpdateScoreDisplay();
    }

    /*
    This method decreases the player's score
    Example use from outside class: ScoreManager.Instance.LosePoints()
    */
    public void LosePoints()
    {
        score -= 10;        
        if (score < 0) // prevent negative score
        {
            score = 0;
        }
        UpdateScoreDisplay();
    }

    /*
    This method increases the player's score
    Example use from outside class: ScoreManager.Instance.GainPoints()
    */
    public void GainPoints()
    {
        score += 10;        
        UpdateScoreDisplay();
    }

    /*
    This method assigns the text with the current score value to the scoreText object. 
    */
    private void UpdateScoreDisplay()
    {
        if (scoreText != null) // assures scoreText object was assigned in inspector
        {
            scoreText.text = "Score: " + score;
        }
    }
}
