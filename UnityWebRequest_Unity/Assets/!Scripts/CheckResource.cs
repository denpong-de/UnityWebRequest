using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckResource : MonoBehaviour
{
    [TextArea(1, 20)]
    [SerializeField] string url;
    int localBannerId;

    void Start()
    {
        if (!PlayerPrefs.HasKey("bannerId"))
        {
            PlayerPrefs.SetInt("bannerId",0);
            localBannerId = 0;
        }
        else
        {
            localBannerId = PlayerPrefs.GetInt("bannerId");
        }

        CheckBannerId();
    }

    private async void CheckBannerId()
    {
        string value = "{ \"localBannerId\":\"" + localBannerId + "\"}";
        string res = await PostClient.RequestPost(url,value);

        if (res != "OK")
        {
            string[] responses = res.Split(';');
            PlayerPrefs.SetString("bannerUrl", responses[1]);
            PlayerPrefs.SetInt("bannerId", int.Parse(responses[0]));
        }
    }
}
