using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {

	//Script para mudança de cena.
	//Optei pelo uso das variaveis para permitir reuso em outros botões.
	public string sceneName;
	public Button btScene;

	void Start () {
		Button btn1 = btScene.GetComponent<Button>();


		btn1.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		SceneManager.LoadScene(sceneName);

	}


}
