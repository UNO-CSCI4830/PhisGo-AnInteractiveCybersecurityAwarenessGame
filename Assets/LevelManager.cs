using UnityEngine;
using TMPro; 

/*
This class stores the current level the game is on and has methods to display the level
Methods to update the level will be added later.
*/
public class LevelManager : MonoBehaviour
{
    // This public static instance of this class makes a Singleton that can be invoked later
    public static LevelManager Instance { get; private set; }

    // Text object to display the level. The initial value is set in the Inspector window
    [SerializeField] private TextMeshProUGUI levelText; 
    
    private int level = 1;  // begin the game at level 1

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
        UpdateLevelDisplay();
    }

    /*
    This method assigns the text with the current level to the levelText object. 
    */
    private void UpdateLevelDisplay()
    {
        if (levelText != null) // assures levelText object was assigned in inspector
        {
            levelText.text = "Level: " + level;
        }
    }    
}
