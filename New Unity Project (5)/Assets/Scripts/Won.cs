using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Won : MonoBehaviour {
    public GameObject C1;
    RaycastHit hit;
    float timer = 1.0f;
    public GameObject explosion;
    public GameObject text;
	// Use this for initialization
	void Start () {
        text.active = false;
	}
	
	// Update is called once per frame
	void Update () {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name == "WoodBarrel (1)")
            {
                timer -= Time.deltaTime;
                if (hit.collider.name != "WoodBarrel (1)")
                    timer = 1.0f;
                if (timer < 0)
                {
                    Instantiate(explosion, C1.transform.position, C1.transform.rotation);
                    Destroy(C1);
                    text.active = true;
                    Application.LoadLevel("WaitingRoom");
                }
            }

        }
    }
}
