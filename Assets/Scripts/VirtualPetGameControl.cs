//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/22/2025
/////////////////////////////////////////////

using TMPro;
using UnityEngine;


/// <summary>
/// Manages the user interface for the Virtual Pet game.
/// It updates the pet status bars, handles user interactions,
/// and manages game state.
/// </summary>
public class VirtualPetGameControl : MonoBehaviour
{
    // UI control
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private GameObject barOne;
    [SerializeField] private GameObject barTwo;
    [SerializeField] private GameObject barThree;
    [SerializeField] private GameObject playWithButton;
    [SerializeField] private GameObject feedButton;
    [SerializeField] private GameObject sleepButton;
    [SerializeField] private GameObject playAgainButton;
    private bool isGameOver;

    /// <summary>
    /// Sets up the initial UI on start.
    /// </summary>
    public void Start()
    {
        nameText.text = "Name: " + PetController.Instance.CurrentPet.Name;
        PetController.Instance.StartTimer();

        UpdateBar(barOne, PetController.Instance.CurrentPet.Happiness);
        UpdateBar(barTwo, PetController.Instance.CurrentPet.Fullness);
        UpdateBar(barThree, PetController.Instance.CurrentPet.Tiredness);

        isGameOver = false;
    }

    /// <summary>
    /// Updates the UI elements every frame based on the current stats.
    /// Displays warnings and handles game over conditions.
    /// </summary>
    private void Update()
    {
        if (!playAgainButton.activeSelf) // Stops game responses and updates when play again button is shown
        {
            if (PetController.Instance.CurrentPet.Happiness == 0)
            {
                resultText.color = Color.red;
                resultText.text = "Your pet was taken away because of sadness! Adopt a new virtual pet?";
                EndGame();
            }
            else if (PetController.Instance.CurrentPet.Fullness == 0)
            {
                resultText.color = Color.red;
                resultText.text = "Your pet was taken away because of hunger! Adopt a new virtual pet?";
                EndGame();
            }
            else if (PetController.Instance.CurrentPet.Tiredness == 10) // First 3 conditionals handle gameover conditions
            {
                resultText.color = Color.red;
                resultText.text = "Your pet was taken away because of exhaution! Adopt a new virtual pet?";
                EndGame();
            }
            else if (PetController.Instance.CurrentPet.Happiness <= 2)
            {
                resultText.color = Color.yellow;
                resultText.text = "Quickly entertain your pet! Before your pet gets taken away!";
            }
            else if (PetController.Instance.CurrentPet.Fullness <= 2)
            {
                resultText.color = Color.yellow;
                resultText.text = "Quickly feed your pet! Before your pet gets taken away!";
            }
            else if (PetController.Instance.CurrentPet.Tiredness >= 8) // Last 3 conditionals handle warning conditions
            {
                resultText.color = Color.yellow;
                resultText.text = "Quickly rest your pet! Before your pet gets taken away!";
            }

            if(!isGameOver) // Checks if game over otherwise the bars will show on game end
            {
                UpdateBar(barOne, PetController.Instance.CurrentPet.Happiness);
                UpdateBar(barTwo, PetController.Instance.CurrentPet.Fullness);
                UpdateBar(barThree, PetController.Instance.CurrentPet.Tiredness);
            }
        }
    }

    /// <summary>
    /// Updates a UI bar's segments based on the current value of a pet stat.
    /// </summary>
    public void UpdateBar(GameObject bar, int currentValue)
    {
        UnityEngine.UI.Image[] segments = bar.GetComponentsInChildren<UnityEngine.UI.Image>(true); // True in-order to grab the inactive sprites
        for (int i = 0; i < segments.Length; i++)
        {
            segments[i].gameObject.SetActive(i < currentValue + 1); // If i is less than currentValue + 1, turn this segment on. Otherwise turn it off.
        }
    }

    /// <summary>
    /// Handles the Play With button click event.
    /// Triggers the play action and updates the result text.
    /// </summary>
    public void OnPlayWithClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.PlayWithPetResult();
    }

    /// <summary>
    /// Handles the Feed button click event.
    /// Triggers the feed action and updates the result text.
    /// </summary>
    public void OnFeedClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.FeedPetResult();
    }

    /// <summary>
    /// Handles the Rest button click event.
    /// Triggers the rest action and updates the result text.
    /// </summary>
    public void OnRestClicked()
    {
        resultText.color = Color.white;
        resultText.text = PetController.Instance.RestpetResult();
    }

    /// <summary>
    /// Ends the game by disabling action buttons and showing the play again option.
    /// </summary>
    public void EndGame()
    {
        isGameOver = true;
        playWithButton.SetActive(false);
        feedButton.SetActive(false);
        sleepButton.SetActive(false);
        barOne.SetActive(false);
        barTwo.SetActive(false);
        barThree.SetActive(false);
        playAgainButton.SetActive(true);
    }
}

