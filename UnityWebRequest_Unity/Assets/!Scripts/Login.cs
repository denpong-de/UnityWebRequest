using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField passwordInputField;
    [SerializeField] private GameObject warningText;
    [TextArea(1, 20)]
    [SerializeField] string url;

    public async void OnPressLogin()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
        {
            warningText.SetActive(true);
            return;
        }

        string value = "{ \"username\":\"" + username + "\", \"password\":\"" + password + "\"}";
        string res = await PostClient.RequestPost(url, value);

        if(res != "!")
        {
            PlayerPrefs.SetInt("id",int.Parse(res));
            PlayerPrefs.SetString("username", username);
            SceneManager.LoadScene(1);
        }
        else
        {
            warningText.SetActive(true);
        }
    }
}
