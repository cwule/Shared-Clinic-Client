using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Speechcommands : MonoBehaviour
{
    public Text _connectText, _speechText, _errorText;
    public GameObject _displayPanel;
    public CalibrateTrackableEventHandler _calibHandler;

    public NetworkManager netManager;

    public void Connect2Server()
    {
        _errorText.text = "";
        if (!NetworkClient.active && !NetworkServer.active)
            netManager.StartClient();
    }

    public void DisconnectServer()
    {
        if (NetworkClient.active || NetworkServer.active)
        {
            netManager.StopServer();
            Debug.Log("Disconnect");
        }
    }

    public void ToggleDisplay()
    {
        _speechText.text = "Toggle Display";
        bool dispState = _displayPanel.activeSelf ? false : true;
        _displayPanel.SetActive(dispState);
    }

    public void ShowDisplay()
    {
        _speechText.text = "Show Display";
        _displayPanel.SetActive(true);
    }

    public void HideDisplay()
    {
        _speechText.text = "Hide Display";
        _displayPanel.SetActive(false);
    }

    private void Update()
    {
        if (NetworkClient.active)
        {
            _connectText.text = "Connected";
            _connectText.color = Color.green;
            _calibHandler.enabled = true;
        }
        else
        {
            _connectText.text = "Disconnected";
            _connectText.color = Color.red;
        }
    }
}
