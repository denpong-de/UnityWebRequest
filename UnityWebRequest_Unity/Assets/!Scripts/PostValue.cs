using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostValue : MonoBehaviour
{
    [TextArea(1, 20)]
    [SerializeField] string _postUrl;
    int id;
    string username;

    public async void OnButtonSendValue(string value) 
    {
        id = PlayerPrefs.GetInt("id");
        username = PlayerPrefs.GetString("username");

        string postValue = "{\"id\":\"" + id + "\",\"username\":\"" + username + "\"," + value + "}";

        string res = await PostClient.RequestPost(_postUrl, postValue);

        if(res == "!")
        {
            SceneManager.LoadScene(0);
        }
    }
}
