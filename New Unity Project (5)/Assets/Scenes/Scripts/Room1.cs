using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Room1 : MonoBehaviour {
	
	public GameObject optic;
	int _time=0;
	RaycastHit hit;
	float timer=3;
	float timer0=2;
	int step=1;
	bool Ravenhited=false;
	bool wronghit=false;
	//===============================
	public GameObject target;
	public ParticleSystem hitEffect;
	public GameObject killEffect;

	public GameObject target2;
	public GameObject killEffect2;

	public AudioSource musica;
	public AudioSource musica2;
	public AudioSource musica3;

	public GameObject guide;
	bool islookingBook=false;
	//===============================


	// Use this for initialization
	void Start () {

		guide.SetActive (false);
		hitEffect.enableEmission = false;
		musica.enabled = false;
		musica2.enabled=false;

	}
	// Update is called once per frame
	void Update () 
	{
		//guide.SetActive (false);
		Transform camera = Camera.main.transform;
		Ray ray = new Ray(camera.position, camera.forward );
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			// gaze at the 'ought to gaze' object

			if (hit.collider.name == "Raven_box") 
			{
				timer -= Time.deltaTime;
				if (hit.collider.name != "Raven_box")
					timer = 3;
				if (timer < 0) {
					GameObject qua = GameObject.Find ("Raven_box");
					Ravenhited = true;
					musica2.enabled = true;
					musica2.Play ();
					Instantiate (killEffect2, target2.transform.position, target2.transform.rotation);
					qua.transform.position = new Vector3(0,0.8f,0);
					qua.transform.Rotate(-90f, 0f, 0f);

					timer = 3;
				}

			} 
			//gaze at the wrong one => die
			if (hit.collider.name == "songuoi") 
			{
				hitEffect.transform.position = hit.point;
				hitEffect.enableEmission = true;
				PlayerPrefs.SetInt("win1",0);
				PlayerPrefs.Save ();
				timer -= Time.deltaTime;
				if (hit.collider.name != "songuoi")
					timer = 2;
				if (timer < 0) 
				{
					wronghit = true;
					Instantiate (killEffect, target.transform.position, target.transform.rotation);
					hitEffect.enableEmission = false;
					GameObject ringring = GameObject.Find ("ringring");
					Destroy (ringring);
					GameObject qua = GameObject.Find ("Raven_box");
					Destroy (qua);
				} 
				else if (hit.collider.name != "songuoi")
				{
					timer = 3;
				}
			} 
		}
		//==================================================================
		if (wronghit == true) 
		{
			
			GameObject skull = GameObject.Find ("songuoi");
			Destroy (skull);
			GameObject lightt = GameObject.Find ("Directional Light");
			Destroy (lightt);
			GameObject ghost = GameObject.Find ("ghost");
			timer0-=Time.deltaTime;
			if (timer0<0) {
				ghost.transform.position = new Vector3 (-0.2f, -1.3f, -1.8f);
				ghost.transform.Rotate(0,-40,0);
				musica.enabled = true;
				musica.Play ();
				SceneManager.LoadScene("WaitingRoom", LoadSceneMode.Single);
				//add text here 
            }

        }
		//===================================================================
		if (Ravenhited == true) 
		{
			GameObject daulau = GameObject.Find ("songuoi");
			daulau.transform.position -= new Vector3 (0f, Time.deltaTime*0.1f, 0f);
		}
		optic.transform.Rotate (Vector3.back * Time.smoothDeltaTime * _time);

	}
	public void opticRotate()
	{
		_time = _time + 100;
	}
	public void ringTaken()
	{
		if (Ravenhited == true) {
			PlayerPrefs.SetInt ("win1", 1);
			PlayerPrefs.Save ();
			GameObject ringring = GameObject.Find ("ringring");
			Destroy (ringring);
			//add text here + delay 
			SceneManager.LoadScene("WaitingRoom", LoadSceneMode.Single);
        }

	}
	public void book()
	{
		guide.SetActive (true);
	}
}
