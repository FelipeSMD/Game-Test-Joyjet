using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class playerController : MonoBehaviour {

	private float velocidade = 20f;
	private float translate;
	private float jumpForce = 5f;
	private bool onGround = false;
	private bool coolDown = false;
	private bool takeDamage = false;

	public Rigidbody playerRB;
	public GameObject dialogBox;
	public GameObject redBullet;
	public GameObject blueBullet;
	public GameObject greenBullet;


	void Start () {
		
		globalVariables.life = 100;
	}
		
	void Update () {
		onGround = Physics.Raycast (transform.position, -Vector3.up, 1f);
		shoot ();
		move ();

		//causa dano ao player passeado no tempo para passar a impressão de envenenamento.
		if (!takeDamage) {
			takeDamage = true;
			globalVariables.life -= 2;
			StartCoroutine (nextDamage ());
		}

		if (globalVariables.life <= 0) {
			this.GetComponent<playerController>().enabled = false; 
		}
	}

	void OnTriggerEnter (Collider other){
		//Preferi concentrar o tratamento de colissões no player para evitar a criação de outros scripts
		//que iriam conter apenas poucas linhas e aumentar o numero de arquivos para serem analisados.
		if (other.tag == "Coin") {
			globalVariables.money += 5;
			Destroy (other.gameObject);
		}
		if (other.tag == "NPC") {
			this.GetComponent<playerController>().enabled = false; 
			dialogBox.SetActive (true);
		}
		if (other.tag == "redShoot") {
			Destroy (other.gameObject);
			globalVariables.redOpen = true;
		}
		if (other.tag == "greenShoot") {
			Destroy (other.gameObject);
			globalVariables.greenOpen = true;
		}
		if (other.tag == "blueShoot") {
			Destroy (other.gameObject);
			globalVariables.blueOpen = true;
		}
		if (other.tag == "cure") {
			this.GetComponent<playerController>().enabled = false; 
			globalVariables.endGame = true;
		}
	}

	void move(){
		if (Input.GetButton ("Vertical")) {
			translate = (Input.GetAxis ("Vertical") * velocidade) * Time.deltaTime;
			this.transform.Translate (0, 0, translate);
		}
		if(Input.GetButton ("Horizontal")){
			translate = (Input.GetAxis ("Horizontal") * velocidade) * Time.deltaTime;
			this.transform.Translate (translate,0 , 0);

		}
		if (Input.GetButton ("Jump")) {
			if (onGround) {
				playerRB.velocity = new Vector3 (0, Input.GetAxis ("Jump") * jumpForce, 0);

			}
		}
	}
	void shoot(){
		//Instancia um prefab de bala apartir do botão pressionado.
		//Uma condição extra foi adicionada para verificar se o tiro em questão já teria sido liberado pelo jogador
		if ((Input.GetButton ("Fire1")) && (coolDown == false) && (globalVariables.redOpen == true)) {
			Instantiate(redBullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f), Quaternion.identity);
			//booleano utilizado para que o jogador não possa atirar sempre.
			coolDown = true;
			//contador para reativar o tiro
			StartCoroutine (Wait(0.3f));
		}
		if((Input.GetButton ("Fire2")) && (coolDown == false) && (globalVariables.greenOpen == true)){
			Instantiate(greenBullet, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 0.5f), Quaternion.identity);
			StartCoroutine (Wait(1.0f));
			coolDown = true;
		}
		if ((Input.GetButton ("Fire3")) && (coolDown == false) && (globalVariables.blueOpen == true)) {
			Instantiate(blueBullet, new Vector3(this.transform.position.x + 0.2f, this.transform.position.y, this.transform.position.z + 0.5f), Quaternion.identity);
			Instantiate(blueBullet, new Vector3(this.transform.position.x - 0.2f, this.transform.position.y, this.transform.position.z + 0.5f), Quaternion.identity);
			coolDown = true;
			StartCoroutine (Wait(0.5f));
		}
	}

	IEnumerator Wait(float timeCD) { 
		yield return new WaitForSeconds(timeCD); 

		coolDown = false;
	}

	IEnumerator nextDamage() { 
		yield return new WaitForSeconds(0.2f); 

		takeDamage = false;
	}
}
