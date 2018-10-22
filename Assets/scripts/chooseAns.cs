using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chooseAns : MonoBehaviour {

	//Script apenas para informar a escolha do jogador.
	//optei por utilizar as variaveis para premitir o reuso em outros botões caso necessario.

	public int choose ;
	public Button btAns;
	public GameObject answersOptions;

	void Start()
	{
		Button btn1 = btAns.GetComponent<Button>();


		btn1.onClick.AddListener(TaskOnClick);

	}

	void TaskOnClick()
	{
		
		globalVariables.playerChoose = choose; 
		answersOptions.SetActive (false);
	}
}
