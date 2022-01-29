using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
	[SerializeField] QuestionSO question;
	[SerializeField] TextMeshProUGUI questionText;
	
	private void Start()
	{
		questionText.text = question.GetQuestion();
	}

}
