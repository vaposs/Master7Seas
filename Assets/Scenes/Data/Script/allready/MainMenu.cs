using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image _mainSprite;
    [SerializeField] private Image _settingSprite;

    private int _indexScene = 1;

    private void Start()
    {
        _mainSprite.gameObject.SetActive(true);
        _settingSprite.gameObject.SetActive(false);
    }

    public void SettingButton()
    {
        _mainSprite.gameObject.SetActive(false);
        _settingSprite.gameObject.SetActive(true);
    }

    public void ReturnSettingButton()
    {
        _settingSprite.gameObject.SetActive(false);
        _mainSprite.gameObject.SetActive(true);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(_indexScene);
    }
}
