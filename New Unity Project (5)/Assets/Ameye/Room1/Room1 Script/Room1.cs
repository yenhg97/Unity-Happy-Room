using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room1 : MonoBehaviour {
	
	public GameObject optic;
	int _time=0;
	RaycastHit hit;
	float timer=2;
	int step=1;
	bool Ravenhited=false;
	bool wronghit=false;
	public bool winRoom1=false;


	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () 
	{
		Transform camera = Camera.main.transform;
		Ray ray = new Ray(camera.position, camera.forward );
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit)) {
			// gaze at the 'ought to gaze' object
			if (hit.collider.name == "Raven_box") 
			{
				timer -= Time.deltaTime;
				if (hit.collider.name != "Raven_box")
					timer = 2.0f;
				if (timer < 0) {
					GameObject qua = GameObject.Find ("Raven_box");
					Ravenhited = true;
					qua.transform.position = new Vector3(0,0.7f,0);
					qua.transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
				}

			} 
			//gaze at the wrong one => die
			if (hit.collider.name == "skull") 
			{
				timer -= Time.deltaTime;
				if (hit.collider.name != "skull")
					timer = 2.0f;
				if (timer < 0) {
					wronghit = true;
					GameObject ringring = GameObject.Find ("ringring");
					Destroy (ringring);
					GameObject qua = GameObject.Find ("Raven_box");
					Destroy (qua);
				}
			} 
		}
		//==================================================================
		if (wronghit == true) 
		{
			GameObject skull = GameObject.Find ("skull");
			skull.transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
			GameObject ghost = GameObject.Find ("ghost");
			if (ghost.transform.position != new Vector3 (0,0,2)) 
			{
				ghost.transform.position -= new Vector3 (0, 0.01f, 0);
			}
			if (ghost.transform.position == new Vector3 (0,0,2)) 
			{
				step = 2;
			}
			if (ghost.transform.position != new Vector3 (0,0,-2.3f)&&step==2) 
			{
				ghost.transform.position -= new Vector3 (0, 0, 0.1f);
			}
			if (ghost.transform.position == new Vector3 (0,0,-2.3f)&&step==2) 
			{
				step = 3;
			}
            if (step == 3) {
                Application.LoadLevel("WaitingRoom");
            }

        }
		//===================================================================
		if (Ravenhited == true) 
		{
			GameObject daulau = GameObject.Find ("skull");
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
		winRoom1 = true;
		if (Ravenhited == true) {
			GameObject ringring = GameObject.Find ("ringring");
			Destroy (ringring);
            Application.LoadLevel("WaitingRoom");
        }

	}

}
