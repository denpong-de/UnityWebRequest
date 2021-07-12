using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasBehav : MonoBehaviour
{
    [SerializeField] GameObject popupCanvas;

    public void Close()
    {
        popupCanvas.SetActive(false);
    }

    public void Logout()
    {
        SceneManager.LoadScene(0);
    }
}
