using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalTest : MonoBehaviour
{
    [Header("Variables")]
    [Range(0, 12)] [SerializeField] int score = 0;
    [SerializeField] private List<GameObject> _questions;
    [SerializeField] private int currentQuestionIndex = 0;

    [Header("Screens")]

    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _scoreScreen;

    [Header("Buttons")]
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _previousBtn;
    [SerializeField] private Button _nextBtn;
    [SerializeField] private Button _submitBtn;
    [SerializeField] private Button _mainMenu;

    [Header("Text")]
    [SerializeField] private TMPro.TMP_Text _scoreText;

    [Header("Answers")]
    [SerializeField] private TMPro.TMP_Dropdown _q1Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q2Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q3Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q4Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q5Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q6Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q7Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q8Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q9Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q10Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q11Dropdown;
    [SerializeField] private TMPro.TMP_Dropdown _q12Dropdown;

    [Header("Correct Answers")]
    [Range(0, 3)] [SerializeField] private int _q1Answer;
    [Range(0, 3)] [SerializeField] private int _q2Answer;
    [Range(0, 3)] [SerializeField] private int _q3Answer;
    [Range(0, 3)] [SerializeField] private int _q4Answer;
    [Range(0, 3)] [SerializeField] private int _q5Answer;
    [Range(0, 3)] [SerializeField] private int _q6Answer;
    [Range(0, 3)] [SerializeField] private int _q7Answer;
    [Range(0, 3)] [SerializeField] private int _q8Answer;
    [Range(0, 3)] [SerializeField] private int _q9Answer;
    [Range(0, 3)] [SerializeField] private int _q10Answer;
    [Range(0, 3)] [SerializeField] private int _q11Answer;
    [Range(0, 3)] [SerializeField] private int _q12Answer;

    public void StartButton()
    {
        currentQuestionIndex = 0;
        _questions[currentQuestionIndex].SetActive(true);
        _previousBtn.gameObject.SetActive(false);
        _nextBtn.gameObject.SetActive(true);
        _submitBtn.gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(false);
        _startScreen.SetActive(false);
    }

    public void NextScreen()
    {
        _questions[currentQuestionIndex].SetActive(false);
        currentQuestionIndex++;

        if (currentQuestionIndex >= _questions.Count - 1)
        {
            currentQuestionIndex = _questions.Count - 1;
            _questions[currentQuestionIndex].SetActive(true);
            _nextBtn.gameObject.SetActive(false);
            _submitBtn.gameObject.SetActive(true);
            return;
        }
        _nextBtn.gameObject.SetActive(true);
        _previousBtn.gameObject.SetActive(true);
        _questions[currentQuestionIndex].SetActive(true);
    }

    public void PreviousScreen()
    {
        _questions[currentQuestionIndex].SetActive(false);
        currentQuestionIndex--;
        
        if (currentQuestionIndex <= 0)
        {
            currentQuestionIndex = 0;
            _questions[currentQuestionIndex].SetActive(true);
            _previousBtn.gameObject.SetActive(false);
            return;
        }
        _submitBtn.gameObject.SetActive(false);
        _nextBtn.gameObject.SetActive(true);
        _questions[currentQuestionIndex].SetActive(true);
    }

    public void Submit()
    {
        _previousBtn.gameObject.SetActive(false);
        _nextBtn.gameObject.SetActive(false);
        _submitBtn.gameObject.SetActive(false);

        _mainMenu.gameObject.SetActive(true);

        _questions[currentQuestionIndex].SetActive(false);
        _scoreScreen.SetActive(true);

        #region Calculate Score

        score = 0;

        if (_q1Dropdown.value == _q1Answer) score++;
        if (_q2Dropdown.value == _q2Answer) score++;
        if (_q3Dropdown.value == _q3Answer) score++;
        if (_q4Dropdown.value == _q4Answer) score++;
        if (_q5Dropdown.value == _q5Answer) score++;
        if (_q6Dropdown.value == _q6Answer) score++;
        if (_q7Dropdown.value == _q7Answer) score++;
        if (_q8Dropdown.value == _q8Answer) score++;
        if (_q9Dropdown.value == _q9Answer) score++;
        if (_q10Dropdown.value == _q10Answer) score++;
        if (_q11Dropdown.value == _q11Answer) score++;
        if (_q12Dropdown.value == _q12Answer) score++;

        #endregion

        switch (score)
        {
            case 0:
                _scoreText.text = $"YOU SCORED: {score}/12\n  Maybe driving isn't your thing...";
                break;
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                _scoreText.text = $"YOU SCORED: {score}/12\n  All good, you just need to prepare a little more!";
                break;
            case 6:
                _scoreText.text = $"YOU SCORED: {score}/12\n  Half way there, just need to prepare a little more!";
                break;
            case 7:
            case 8:
            case 9:
                _scoreText.text = $"YOU SCORED: {score}/12\n  Good work! These are some of the hardest questions, so don't feel like you need to be perfect!";
                break;
            case 10:
            case 11:
                _scoreText.text = $"YOU SCORED: {score}/12\n  Great job, easily passed the test!";
                break;
            case 12:
                _scoreText.text = $"YOU SCORED: {score}/12\n  PERFECT SCORE! Way to go!";
                break;
        }
    }
}
