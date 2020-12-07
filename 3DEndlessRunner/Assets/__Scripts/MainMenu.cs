using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] GameObject instructionsPanel;
    [SerializeField] GameObject optionsPanel;

    private AudioManager audioManager;

    private void Start()
    {
        audioManager.PlaySound("MainTheme");
    }

    // The below three functions simply manage our menu states
    public void GoToMain()
    {
        mainPanel.SetActive(true);
        instructionsPanel.SetActive(false);
        optionsPanel.SetActive(false);
    }
    public void GoToInstructions()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
    public void GoToOptions()
    {
        mainPanel.SetActive(false);
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
