using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PostClient
{
    public static async Task<string> RequestPost(string url, string value)
    {
        var jsonBinary = System.Text.Encoding.UTF8.GetBytes(value);

        DownloadHandlerBuffer downloadHandlerBuffer = new DownloadHandlerBuffer();

        UploadHandlerRaw uploadHandlerRaw = new UploadHandlerRaw(jsonBinary);
        uploadHandlerRaw.contentType = "application/json";

        using (UnityWebRequest www = new UnityWebRequest(url, "POST", downloadHandlerBuffer, uploadHandlerRaw))
        {
            // begin request:
            var asyncOp = www.SendWebRequest();

            // await until it's done: 
            while (!asyncOp.isDone)
                await Task.Yield();

            // read results:
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                // log error:
                Debug.LogError($"{www.error}, URL:{www.url}");

                // nothing to return on error:
                return null;
            }
            else
            {
                try
                {
                    // return valid results:
                    return www.downloadHandler.text;
                }
                catch (Exception ex)
                {
                    // log error:
                    Debug.LogError("Could not GetContent: " + ex.Message);

                    // nothing to return on error:
                    return default;
                }
            }
        }
    }
}
