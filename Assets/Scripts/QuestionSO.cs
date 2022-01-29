using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
	[SerializeField] string question = "Enter new question text here";
	[TextArea(2,6)] [SerializeField] string[] answers = new string [4];
	[SerializeField] int correctAnswerIndex;
	
	public int GetCorrectAnswerIndex()
	{
		return correctAnswerIndex;
	}
	
	public string GetAnswer(int index)
	{
		return answers[index];
	}
	
	public string GetQuestion()
	{
		return question;
	}
}
