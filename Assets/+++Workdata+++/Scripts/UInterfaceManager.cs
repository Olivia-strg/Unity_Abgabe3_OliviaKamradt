using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UInterface : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI numberOfCollectables;
    [SerializeField] private GameManager GameManager;

    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject winPanel;
    public GameObject levelPanel;


    private void Start()
    {

        //ChangeNumberText(0);
        MainMenuOn();
        GameLevelPanelOff();
        WinPanelOff();
        GameOverPanelOff();

    }
    public void ChangeNumberText(int newNumber)
    {

        numberOfCollectables.text = newNumber.ToString();

    }

    #region PanelsOnOff
    public void MainMenuOn()
    {
        mainMenuPanel.SetActive(true);
    }
    public void MainMenuOff()
    {
        mainMenuPanel.SetActive(false);
    }

    public void GameLevelPanelOn()
    {
        levelPanel.SetActive(true);
    }

    public void GameLevelPanelOff()
    {
        levelPanel.SetActive(false);
    }
    public void GameOverPanelOn()
    {
        gameOverPanel.SetActive(true);
    }
    public void GameOverPanelOff()
    {
        gameOverPanel.SetActive(false);
    }

    public void WinPanelOn()
    {
        winPanel.SetActive(true);
    }
    public void WinPanelOff()
    {
        winPanel.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("Restart");
    }
    #endregion


}




