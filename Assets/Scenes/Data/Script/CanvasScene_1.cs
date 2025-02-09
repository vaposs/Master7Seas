using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScene_1 : MonoBehaviour
{
    [SerializeField] private float _delay;
    [SerializeField] private Image _infoPanel;
    [SerializeField] private PlayerMover _playerMover;

    private void Start()
    {
        _infoPanel.gameObject.SetActive(true);
        StartCoroutine(EnamlePanel(_delay));
    }

    private IEnumerator EnamlePanel(float delay)
    {
        yield return new WaitForSeconds(delay);

        _infoPanel.gameObject.SetActive(false);
    }
}
