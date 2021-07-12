using UnityEngine;
using UnityEngine.UI;

public class RequestImage : MonoBehaviour
{
    [SerializeField] Image _image;
    string _url;
    Texture2D _texture;

    // Start is called before the first frame update
    async void Start()
    {
        _url = PlayerPrefs.GetString("bannerUrl");
        _texture = await GetRemoteTextureClient.GetRemoteTexture(_url);
        _image.sprite = Sprite.Create(_texture,new Rect(0,0,_texture.width,_texture.height),new Vector2(0,0));
    }

    void OnDestroy() => Dispose();
    public void Dispose() => Destroy(_texture);// memory released, leak otherwise
}
