using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject multiplayerPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject optionsPanel;

    [SerializeField] private GameObject findOpponentPanel = null;
    [SerializeField] private GameObject waitingStatusPanel = null;
    [SerializeField] private TextMeshProUGUI waitingStatusText = null;

    private bool isConnecting = false;

    private const string GameVersion = "0.1";
    private const int MaxPlayersPerRoom = 2;

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public void FindOpponent()
    {
        isConnecting = true;

        findOpponentPanel.SetActive(false);
        waitingStatusPanel.SetActive(true);

        waitingStatusText.text = "Searching...";

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            PhotonNetwork.GameVersion = GameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");

        if (isConnecting)
        {
            PhotonNetwork.JoinRandomRoom();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        waitingStatusPanel.SetActive(false);
        findOpponentPanel.SetActive(true);

        Debug.Log($"Disconnected due to: {cause}");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No Clients are waiting for an opponent, creating a new room");

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Client successfully joined a room");

        int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

        if (playerCount != MaxPlayersPerRoom)
        {
            waitingStatusText.text = "Waiting for opponent";
            Debug.Log("Client is waiting for an opponent");
        }
        else
        {
            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
        {
            PhotonNetwork.CurrentRoom.IsOpen = false;

            waitingStatusText.text = "Opponent Found";
            Debug.Log("Match is ready to begin");

            PhotonNetwork.LoadLevel("Game");
        }
    }

    private AudioManager audioManager;

    private void Start()
    {
        audioManager.PlaySound("MainTheme");
    }

    // The below three functions simply manage our menu states
    public void GoToMain()
    {
        mainPanel.SetActive(true);
        multiplayerPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GoToMultiplayer()
    {
        mainPanel.SetActive(false);
        multiplayerPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GoToInstructions()
    {
        mainPanel.SetActive(false);
        multiplayerPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void GoToOptions()
    {
        mainPanel.SetActive(false);
        multiplayerPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void OnPlayClicked()
    {
        SceneManager.LoadScene("Game");
    }

    // checks if we're running the unity editor or running the actual build of the game
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
