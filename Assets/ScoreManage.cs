using UnityEngine;
using TMPro; // Required to control TextMeshPro elements

public class ScoreManager : MonoBehaviour
{
    // This public static instance makes a Singleton to invoke elsewhere
    public static ScoreManager Instance { get; private set; }

    // Drag your TextMeshPro object into this slot in the Unity Inspector
    [SerializeField] private TextMeshProUGUI scoreText; 
    
    private int score = 100;  //begin the game with 100 points

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

    void Start()
    {
        UpdateScoreDisplay();
    }

    // Call this public function when the player loses points
    // Looks like this from another class > ScoreManager.Instance.LosePoints()
    public void LosePoints()
    {
        score -= 10;
        // prevent negative score
        if (score < 0)
        {
            score = 0;
        }
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
