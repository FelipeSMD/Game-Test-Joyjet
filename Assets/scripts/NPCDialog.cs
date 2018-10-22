using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialog : MonoBehaviour {
	private int currentText = 0;
	//Optei por colocar os dialogs em um array mesmo para simplicar a codificação, já que se trava de poucos textos
	// não havia necessiadade de usar um json ou xml auxiliar.
	private string[] dialogs = new string[] {"Este é um corredor de testes. Você foi envenenado e morrerá em breve, mas pode sobreviver caso consiga o antidoto no final do corredor", 
		"Você ainda pode coletar as esferas coloridas ao longo do percurso para adquirir habilidades de tiro unicas.", 
		"Use-as para destruir os blocos verdes, eles vão te curar um pouco.", 
		"Deseja tentar sobreviver?", 
		"Bom, tudo acabara em breve.", "Que entusiasmo, pode começar!",
		"Não tenho mais explicações."};

	public Button btNext;
	public GameObject player;
	public Text dialogNPC;
	public GameObject answersOptions;
	public GameObject dialogBox;

	void Start () {
		Button btn1 = btNext.GetComponent<Button>();
		btn1.onClick.AddListener(TaskOnClick);
		globalVariables.playerChoose = currentText;


	}

	void Update (){
		dialogNPC.text = dialogs [globalVariables.playerChoose];
	}



	void TaskOnClick()
	{
		//condicionais para lidar com o momento da pergunta ao player.
		//no geral apenas segue a conversa conforme o click do usuario
		//e em um determinado ponto libera as opções de resposta.
		if (currentText < 2) {
			currentText++;
			globalVariables.playerChoose = currentText;
		} else if (currentText == 2) {
			currentText++;
			globalVariables.playerChoose = currentText;
			answersOptions.SetActive (true);
		} else {
			player.GetComponent<playerController>().enabled = true; 
			globalVariables.playerChoose = 6;
			dialogBox.SetActive (false);
		}

	}
		

}
