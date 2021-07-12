using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class GetRemoteTextureClient
{
    public static async Task<Texture2D> GetRemoteTexture(string url)
    {
        using (UnityWebRequest www = UnityWebRequestTexture.GetTexture(url))
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
                    return DownloadHandlerTexture.GetContent(www);
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
