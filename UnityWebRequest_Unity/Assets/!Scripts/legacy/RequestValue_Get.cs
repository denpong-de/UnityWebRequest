using UnityEngine;
using UnityEngine.UI;

public class RequestValue_Get : MonoBehaviour
{
    [TextArea(1, 20)]
    [SerializeField] string _getUrl;
    [SerializeField] Text _valueText;
    string _oldValue;
    string _value;

    [SerializeField] GameObject popUp;

    // Start is called before the first frame update
    void Start()
    {
        Request(-1);
    }

    public async void Request(int input)
    {
        if (input > int.Parse(_valueText.text))
        {
            popUp.SetActive(true);
            return;
        }

        _oldValue = _value;
        while(_oldValue == _value) //Prevent form reading old value.
        {
            _value = await GetRemoteValueClient.GetRemoteValue(_getUrl);
            _valueText.text = _value;
        }
    }
}
