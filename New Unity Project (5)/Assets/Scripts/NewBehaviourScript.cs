using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public GameObject C1;


	RaycastHit hit;
	float timer = 1.0f;
    public GameObject explosion;

    void Start() {
    }
		
	void Update() {

		gameObject.transform.Rotate(Vector3.up * 98 * Time.deltaTime);


		Transform camera = Camera.main.transform;
		Ray ray = new Ray(camera.position, camera.forward );

		if (Physics.Raycast (ray, out hit)) {
			
			if (hit.collider.gameObject.tag == "Box") {
				timer -= Time.deltaTime;
				if (hit.collider.gameObject.tag != "Box")
					timer = 1.0f;
				if (timer < 0) {
					Instantiate(explosion, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
					Destroy(hit.collider.gameObject);
                    timer = 1.0f;
				}
			} 
		

			//if (hit.collider.name == "WoodCrate (1)") {
			//	timer -= Time.deltaTime;
			//	if (hit.collider.name != "WoodCrate (1)")
			//		timer = 1.0f;
			//	if (timer < 0) {
			//		//Instantiate(explosion, C1.transform.position, C1.transform.rotation);
			//		Destroy(C2);
			//	}
			//}
				
    }

}

}
