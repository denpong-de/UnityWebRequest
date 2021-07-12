using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RequestValue : MonoBehaviour
{
    [TextArea(1, 20)]
    [SerializeField] string url;
    [SerializeField] Text valueText;

    int id;
    string username;

    // Start is called before the first frame update
    void Start()
    {
        OnRequestValue();
    }
    
    public async void OnRequestValue()
    {
        id = PlayerPrefs.GetInt("id");
        username = PlayerPrefs.GetString("username");

        string value = "{\"id\":\"" + id + "\",\"username\":\"" + username + "\"}";
        string res = await PostClient.RequestPost(url, value);

        if(res != "!")
        {
            valueText.text = res;
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

    public void PressUpdateValue(float t)
    {
        Invoke("OnRequestValue",t);
    }
}
