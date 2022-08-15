using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action onStartGame;
    public static event Action onFailGame;
    public static event Action onWinGame;

    private bool canPlay;
    private bool _isWin;
    public bool IsWin
    {
        get
        {
            return _isWin;
        }
        set
        {
            _isWin = value;
        }
    }

    private bool _isFail;
    public bool IsFail
    {
        get
        {
            return _isFail;
        }
        set
        {
            _isFail = value;
        }
    }

    private void Update()
    {
        if(!canPlay && Input.GetMouseButtonDown(0))
        {
            canPlay = true;
            StartGame();
        }
    }

    private void StartGame()
    {
        if (onStartGame != null)
            onStartGame();
    }

    public void FailGame()
    {
        _isFail = true;
        if (onFailGame != null)
            onFailGame();
    }

    public void WonGame()
    {
        _isWin = true;
        if (onWinGame != null)
            onWinGame();
    }
}
