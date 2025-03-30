using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public int _score = 0;
    [SerializeField] private GameObject _ui;
    [SerializeField] private TextMeshProUGUI _scoreText;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        switch (other.tag)
        {
            case "NPC":
                // 함수
                OpenUI();
                break;
            case "Collectable":
                // 함수
                break;
        }
    }

    void Start()
    {
        SetScore();
    }

    public void OpenUI()
    {
        _ui.SetActive(true);
    }

    public void GetScore(int score)
    {
        _score += score;
        SetScore();
    }

    public void CloseUI()
    {
        _ui.SetActive(false);
    }

    private void SetScore()
    {
        _scoreText.text = $"Score : {_score}";
    }
}
