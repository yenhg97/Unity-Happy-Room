﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lose : MonoBehaviour
{



    public GameObject C1;
    RaycastHit hit;
    float timer = 1.0f;
    public GameObject explosion;
    public GameObject text;
    // Use this for initialization
    void Start()
    {
        text.active = false;
		//PlayerPrefs.SetInt ("win3", 0);
    }

    // Update is called once per frame
    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.forward);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name == "WoodBarrel")
            {
                timer -= Time.deltaTime;
                if (hit.collider.name != "WoodBarrel")
                    timer = 1.0f;
                if (timer < 0)
                {
                    Instantiate(explosion, C1.transform.position, C1.transform.rotation);
					PlayerPrefs.SetInt ("win3", 0);
					PlayerPrefs.Save ();
                    Destroy(C1);
                    text.active = true;
                    //Application.LoadLevel("WaitingRoom");

					SceneManager.LoadScene("WaitingRoom", LoadSceneMode.Single);
                }
            }

        }
    }
}
