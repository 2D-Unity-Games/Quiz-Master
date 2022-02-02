using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
	[SerializeField] QuestionSO question;
	[SerializeField] TextMeshProUGUI questionText;
	[SerializeField] GameObject[] answerButtons;
	
	[SerializeField] Sprite defaultAnswerSprite;
	[SerializeField] Sprite correctAnswerSprite;
	
	int correctAnswerIndex;
	
	private void Start()
	{
		DisplayQuestion();
	}

	private void DisplayQuestion()
	{
		questionText.text = question.GetQuestion();
		for (int i = 0; i < answerButtons.Length; i++)
		{
			TextMeshProUGUI buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
			buttonText.text = question.GetAnswer(i);
		}
	}

	private void SetButtonState(bool state)
	{
		for (int i = 0; i < answerButtons.Length; i++)
		{
			Button button = answerButtons[i].GetComponent<Button>();
			button.interactable = state;
		}
	}

	public void OnAnswerSelected(int index)
	{
		Image buttonImage;
		if (index == question.GetCorrectAnswerIndex())
		{
			questionText.text = "Correct";
			buttonImage = answerButtons[index].GetComponent<Image>();
			buttonImage.sprite = correctAnswerSprite;
		} 
		else 
		{
			correctAnswerIndex = question.GetCorrectAnswerIndex();
			string correctAnswer = question.GetAnswer(correctAnswerIndex);
			questionText.text = "Sorry, the correct answer was:\n" + correctAnswer;
			buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
			buttonImage.sprite = correctAnswerSprite;
		}
		SetButtonState(false);
	}

	private void GetNextQuestion()
	{
		SetButtonState(true);
		SetDefaultButtonSprite();
		DisplayQuestion();
	}

	private void SetDefaultButtonSprite()
	{
		for (int i = 0; i < answerButtons.Length; i++)
		{
			Image buttonImage = answerButtons[i].GetComponent<Image>();
			buttonImage.sprite = defaultAnswerSprite;
		}
	}
}
