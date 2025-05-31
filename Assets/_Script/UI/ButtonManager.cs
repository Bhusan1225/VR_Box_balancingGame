using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] Button retryButton;
    [SerializeField] Button lobbyButton;

    void Start()
    {
        retryButton.onClick.AddListener(() => SceneController.Instance.RestartScene());
        lobbyButton.onClick.AddListener(() => SceneController.Instance.LoadLobby());
    }
}
