//////////////////////////////////////////////
//Assignment/Lab/Project: Virtual Pet Assignment
//Name: Blaise Harris
//Section: SGD.213.0021
//Instructor: Aurore Locklear
//Date: 02/21/2025
/////////////////////////////////////////////

using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Manages the main menu and navigation UI for the Virtual Pet game.
/// Handles user input validation and scene transitions.
/// </summary>
public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button playButton;

    /// <summary>
    /// Continuously checks if the pet name input is valid to enable the play button.
    /// </summary>
    private void Update()
    {
        if (nameInputField != null && playButton != null)
        {
            if (nameInputField.text.Length >= 3)
            {
                playButton.interactable = true;
            }
            else
            {
                playButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// Creates a pet with the entered name and loads the game scene.
    /// </summary>
    public void OnClickPlay()
    {
        PetController.Instance.CreatePet(nameInputField.text);
        SceneManager.LoadScene("VirtualPetGame");
    }

    /// <summary>
    /// Loads the "How To Play" scene.
    /// </summary>
    public void OnClickHow()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    /// <summary>
    /// Resets the pet controller and loads the main menu scene.
    /// </summary>
    public void OnClickBack()
    {
        PetController.ResetSingleton(); // In-order to start a new game the PetController singleton must be reset because this is used also at the end of a game
        SceneManager.LoadScene("MainMenu");
    }

    /// <summary>
    /// Quits the application.
    /// </summary>
    public void OnClickQuit()
    {
        Debug.Log("Application Quitting!!!");
        Application.Quit();
    }
}
