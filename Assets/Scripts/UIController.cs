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

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private Button playButton;

    private void Update()
    {
        if(nameInputField.text.Length >= 3)
        {
            playButton.interactable = true;
        } 
        else
        {
            playButton.interactable = false;
        }
    }

    public void OnClickPlay()
    {
        PetController.Instance.CreatePet(nameInputField.text);
        SceneManager.LoadScene("VirtualPetGame");
    }

    public void OnClickHow()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void OnClickBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void OnClickQuit()
    {
        Debug.Log("Application Quitting!!!");
        Application.Quit();
    }
}
