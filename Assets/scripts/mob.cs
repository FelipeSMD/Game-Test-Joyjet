using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob : MonoBehaviour {

	public int life;

	void Update () {
		if (life <= 0) {
			globalVariables.life += 30;
			Destroy (this.gameObject);
		}
	}

	void OnTriggerEnter (Collider other){
		//Retira vida do mob e acordo com o tipo de tiro recebido.
		//optei por usar tags para evitar a criação de variaveis no spec.
		if (other.tag == "redBullet") {
			life -= 20;
			//Destroi a bala para que ela não acerte um segundo objeto.
			Destroy (other.gameObject);
		}
		if (other.tag == "greenBullet") {
			life -= 100;
			Destroy (other.gameObject);
		}
		if (other.tag == "blueBullet") {
			life -= 15;
			Destroy (other.gameObject);
		}
	}
}
