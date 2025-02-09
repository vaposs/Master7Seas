using System;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class InteractablePlayer : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Image _lvlUpImage;
    [SerializeField] private Text _lvlText;

    private int _lvl = 1;
    private float _experienceMultiplier = 1.1f;
    private int _maxValueSlider = 100;
    private Enemy[] _enemies;
    private Drop[] _drops;
    private Queue<Drop> _queueDrops = new Queue<Drop>();

    private void Start()
    {
        _slider.maxValue = _maxValueSlider;
        _slider.value = 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Drop drop))
        {
            AddXpTakeDrop(drop);
            Destroy(drop.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Magneto magneto))
        {
            _drops = GameObject.FindObjectsByType<Drop>(FindObjectsSortMode.None);

            for (int i = 0; i < _drops.Length; i++)
            {
                _queueDrops.Enqueue(_drops[i]);
            }

            while (_queueDrops.Count > 0)
            {
                AddXpTakeDrop(_queueDrops.Dequeue());
            }

            Destroy(magneto.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out BoardPortalUp boardPortalUp))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y * -1 + 5, transform.position.z);
        }

        if (collision.gameObject.TryGetComponent(out BoardPortalLeft boardPortalLeft))
        {
            transform.position = new Vector3(transform.position.x * -1 - 5, transform.position.y, transform.position.z);
        }

        if (collision.gameObject.TryGetComponent(out BoardPortalDown boardPortalDown))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1 -5, transform.position.z);
        }

        if (collision.gameObject.TryGetComponent(out BoardPortalRight boardPortalRight))
        {
            transform.position = new Vector3(transform.position.x * -1 + 5, transform.position.y, transform.position.z);
        }

        if (collision.gameObject.TryGetComponent(out Bomb bomb))
        {
            _enemies = GameObject.FindObjectsByType<Enemy>(FindObjectsSortMode.None);

            if (_enemies.Length != 0)
            {
                foreach (Enemy enemie in _enemies)
                {
                    enemie.Destroed();
                }
            }

            Destroy(bomb.gameObject);
        }

        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            AddXpKillEnemy(enemy.XP);
            enemy.DestroeOnPlayer();
        }
    }

    private void AddXpTakeDrop(Drop drop)
    {
        _slider.value += drop.XP;
        Destroy(drop.gameObject);

        if (_slider.value >= _slider.maxValue)
        {
            MultiplierSladerValue();
        }
    }

    private void MultiplierSladerValue()
    {
        Time.timeScale = 0;
        _lvl++;
        _lvlText.text = Convert.ToString(_lvl);
        _lvlUpImage.gameObject.SetActive(true);
        _slider.maxValue = _slider.maxValue * _experienceMultiplier;
        _slider.value = 0;
    }

    private void AddXpKillEnemy(int index)
    {
        _slider.value += index;

        if (_slider.value >= _slider.maxValue)
        {
            MultiplierSladerValue();
        }
    }

    public void ClouseLvlvImage()
    {
        _lvlUpImage.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
