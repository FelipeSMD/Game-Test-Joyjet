using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

	// optei pelo uso das variaveis para permitir o uso do mesmo script para todos as balas.
	// assim poderia apenas passar os valores via spec.
	// Além disso facilita o uso em eventuais prefabs diferentes que pudessem surgir.
	public float velocityForce;
	private float translate;
	public float lifeTime;



	void Start () {
		StartCoroutine (Wait());
	}
	

	void Update () {
		translate = velocityForce * Time.deltaTime;
		this.transform.Translate (0, 0, translate);
	}


	// Este contador é usado para que a bala não fique ocupando espaço de memoria e processamento sempre.
	// Evitando também a existencia da inumeros GameObject na cena.
	IEnumerator Wait() { 
		yield return new WaitForSeconds(lifeTime); 

		Destroy (this.gameObject);
	}
}
