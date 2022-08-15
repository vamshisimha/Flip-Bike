using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class UI_Manager : MonoBehaviour
{
    private GameManager gameManager;
    private LevelManager levelManager;
    [SerializeField] private Player_FlightController player_FlightController;
    [SerializeField] CompetitorProgressInfo playerProgressInfo;

    [SerializeField] private Text levelInfo;
    [SerializeField] private Text rankUI;
    [SerializeField] private Button playButton;
    [SerializeField] private GameObject comboSpeedVisual;
    [SerializeField] private GameObject gameWinVisual;
    [SerializeField] private GameObject gameLoseVisual;

    private void Awake()
    {
        gameManager = GetComponent<GameManager>();
        levelManager = GetComponent<LevelManager>();
    }

    private void OnEnable()
    {
        GameManager.onStartGame += OpenUI;
        GameManager.onFailGame += FailFinish;
        GameManager.onWinGame += WinFinish;
        player_FlightController.onIndicateComboSpeed += ShowComboSpeed_Instant;
    }

    private void OnDisable()
    {
        GameManager.onStartGame -= OpenUI;
        GameManager.onFailGame -= FailFinish;
        GameManager.onWinGame -= WinFinish;
        player_FlightController.onIndicateComboSpeed -= ShowComboSpeed_Instant;
    }

    private void Start()
    {
        playButton.onClick.AddListener(() => ClickPlay());
        ShowLevelInfo();
        CloseUI();
    }

    private void Update()
    {
        SetUI_Text();
    }

    private void ShowLevelInfo()
    {
        StartCoroutine(DelayLevelInfo());
    }

    private void ShowComboSpeed_Instant()
    {
        if(!gameManager.IsFail && !gameManager.IsWin)
        {
            comboSpeedVisual.SetActive(true);
            StartCoroutine(CloseComboSpeedVisual());
        } 
    }

    private void SetUI_Text()
    {
        rankUI.text = "Position : " + playerProgressInfo.Position.ToString();
    }

    private void ClickPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void FailFinish()
    {
        playButton.gameObject.SetActive(true);
        gameLoseVisual.SetActive(true);
    }

    private void WinFinish()
    {
        playButton.gameObject.SetActive(true);
        gameWinVisual.SetActive(true);
    }

    private void OpenUI()
    {
        rankUI.gameObject.SetActive(true);
    }

    private void CloseUI()
    {
        rankUI.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        comboSpeedVisual.SetActive(false);
        gameLoseVisual.SetActive(false);
        gameWinVisual.SetActive(false);
    }

    private IEnumerator CloseComboSpeedVisual()
    {
        yield return new WaitForSeconds(.5f);
        comboSpeedVisual.SetActive(false);
    }

    private IEnumerator DelayLevelInfo()
    {
        yield return new WaitForSeconds(.1f);
        levelInfo.text = "LEVEL : " + (levelManager.LevelIndex + 1).ToString();
    }
}
