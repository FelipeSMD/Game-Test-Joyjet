using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	public Slider lifebar;
	public Text money;
	public GameObject redShoot;
	public GameObject greenShoot;
	public GameObject blueShoot;
	public GameObject finalMsgBox;
	public Text finalText;

	//Script responsavel pela maior parte da interface.
	//no geral desliga, liga e atualiza objetos do canvas.
	void Start () {
		finalMsgBox.SetActive (false);
		globalVariables.endGame = false;
	}

	void Update () {
		money.text = globalVariables.money.ToString();
		lifebar.value = globalVariables.life;
		openShoots ();
		if (globalVariables.life <= 0) {
			finalMsgBox.SetActive (true);
			finalText.text = "Você Morreu !";
		}
		if (globalVariables.endGame) {
			finalMsgBox.SetActive (true);
			finalText.text = "Parabéns, você sobreviveu !";
		}
	}

	void openShoots () {
		if (globalVariables.redOpen) {
			redShoot.SetActive(true);
		}
		if (globalVariables.greenOpen) {
			greenShoot.SetActive(true);
		}
		if (globalVariables.blueOpen) {
			blueShoot.SetActive(true);
		}
	}

}
