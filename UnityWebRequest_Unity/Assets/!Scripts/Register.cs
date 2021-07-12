using System;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    [SerializeField] private GameObject RegisterPage;
    [SerializeField] private InputField usernameInputField;
    [SerializeField] private InputField passwordInputField;
    [SerializeField] private Text warningText;
    [TextArea(1, 20)]
    [SerializeField] string url;

    public async void OnPressRegister()
    {
        if (String.IsNullOrWhiteSpace(usernameInputField.text) || String.IsNullOrWhiteSpace(passwordInputField.text))
        {
            warningText.text = "ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง";
            warningText.gameObject.SetActive(true);
            return;
        }

        string value = "{ \"username\":\"" + usernameInputField.text + "\", \"password\":\"" + passwordInputField.text + "\"}";
        string res = await PostClient.RequestPost(url, value);

        if (res != "!")
        {
            RegisterPage.SetActive(false);
        }
        else
        {
            warningText.text = "ชื่อผู้ใช้นี้ถูกใช้งานไปแล้ว";
            warningText.gameObject.SetActive(true);
        }
    }

    public void OpenRegisterPage()
    {
        RegisterPage.SetActive(true);
    }

    public void CloseRegisterPage()
    {
        RegisterPage.SetActive(false);
    }
}
