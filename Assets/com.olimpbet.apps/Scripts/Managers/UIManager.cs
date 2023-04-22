using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance 
    { 
        get => FindObjectOfType<UIManager>(); 
    }

    private GameObject _gameRef;
    public int levelId;

    [SerializeField] GameObject menu;
    [SerializeField] GameObject game;
    [SerializeField] GameObject levels;

    [Space(10)]
    [SerializeField] Text levelText;


    private void Start()
    {
        levelId = 1;
        OpenMenu();
    }


    public void OpenLevels()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void StartGame()
    {
        if (_gameRef)
        {
            Destroy(_gameRef);
        }

        levelText.text = $"LVL {levelId}";

        var _parent = GameObject.Find("Environment").transform;
        var _prefab = Resources.Load<GameObject>($"level {levelId}");

        _gameRef = Instantiate(_prefab, _parent);

        menu.SetActive(false);
        levels.SetActive(false);

        game.SetActive(true);
    }

    public void OpenMenu()
    {
        if(_gameRef)
        {
            Destroy(_gameRef);
        }

        var lines = FindObjectsOfType<LineRenderer>();
        foreach (var line in lines)
        {
            Destroy(line.gameObject);
        }

        levels.SetActive(false);
        game.SetActive(false);
        menu.SetActive(true);
    }
}
