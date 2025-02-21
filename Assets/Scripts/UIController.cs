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

public class UIController : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInputField;    

    public void OnClickPlay()
    {
        string petName = nameInputField.text;
        if (string.IsNullOrWhiteSpace(petName))
        {
            Debug.LogWarning("No name entered!");
            return;
        }
        else
        {
            PetController.Instance.CreatePet(petName);
            SceneManager.LoadScene("VirtualPetGame");
        }
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
