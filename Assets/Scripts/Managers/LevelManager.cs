using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    private bool isFinishedLevels; 
    private int _levelIndex;
    public int LevelIndex
    {
        get
        {
            return _levelIndex;
        }
        set
        {
            _levelIndex = value;
        }
    }

    [SerializeField] private GameObject[] levels;

    public static event Action<int> onIndicateLevelIndex;

    private void OnEnable()
    {
        GameManager.onWinGame += SetNewLevelIndex;
    }

    private void OnDisable()
    {
        GameManager.onWinGame -= SetNewLevelIndex;
    }

    private void Start()
    {
        SetLevel();
        IndicateLevelIndex(_levelIndex);
    }

    private void SetNewLevelIndex()
    {
        if (!isFinishedLevels){
            if (_levelIndex != levels.Length - 1){
                _levelIndex++;
            }
            else{
                _levelIndex = Random.Range(0, levels.Length);
                isFinishedLevels = true;
            }
        }
        else
            _levelIndex = Random.Range(0, levels.Length);

        PlayerPrefs.SetInt("levelIndex", _levelIndex);
    }

    private void SetLevel()
    {
        _levelIndex = PlayerPrefs.GetInt("levelIndex");

        for (int i = 0; i < levels.Length; i++)
        {
            if (i == _levelIndex)
                levels[i].SetActive(true);
            else
                levels[i].SetActive(false);
        }
    }

    private void IndicateLevelIndex(int targetIndex)
    {
        if (onIndicateLevelIndex != null)
            onIndicateLevelIndex(targetIndex);
    }
}
