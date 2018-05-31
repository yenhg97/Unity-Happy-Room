using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{
    public GameObject door1, door2, door3;
	public Text Wintext;
	public bool winAll = false;

	public int a;
	public int b;
	public int c;
    RaycastHit hit;
    float timer = 3.0f;
    bool open = false;
    // Use this for initialization

    public GameObject room_2;



	public GameObject target2;
	public GameObject Effect2;
	public GameObject won;

    void Start() {
		//PlayerPrefs.SetInt ("win1", 0);
		//PlayerPrefs.SetInt ("win2", 0);
		//PlayerPrefs.SetInt ("win3", 0);
		won.SetActive(false);
	}

    // Update is called once per frame
    void Update() {
		a = PlayerPrefs.GetInt ("win1");//debug
		b = PlayerPrefs.GetInt ("win2");//debug
		c = PlayerPrefs.GetInt ("win3");//debug
		if (PlayerPrefs.GetInt ("win2") == 1 && PlayerPrefs.GetInt ("win1") == 1 && PlayerPrefs.GetInt ("win3") == 1) {
			winAll = true;
			won.SetActive (true);
			Instantiate (Effect2, target2.transform.position, target2.transform.rotation);
		}
		if (winAll == true) {
			PlayerPrefs.SetInt ("win1", 0);
			PlayerPrefs.SetInt ("win2", 0);
			PlayerPrefs.SetInt ("win3", 0);
		}
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit)){
            if (hit.collider.name == "basic_door") {
                timer -= Time.deltaTime;
                if (hit.collider.name != "basic_door")
                    timer = 3.0f;
                if (timer < 0){
                    open = true;
                    TurnToRoom3();
                }
            }
            if (hit.collider.name == "left_door")
            {
                timer -= Time.deltaTime;
                if (hit.collider.name != "left_door")
                    timer = 3.0f;
                if (timer < 0)
                {
                    open = true;
                    TurnToRoom2();
                }
            }
            if (hit.collider.name == "right_door")
            {
                timer -= Time.deltaTime;
                if (hit.collider.name != "right_door")
                    timer = 3.0f;
                if (timer < 0)
                {
                    open = true;
                    TurnToRoom1();
                }
            }
        }
    }
    public void TurnToRoom2()
    {
        if (open == true)
        {
            //Application.LoadLevel("scene5");
			SceneManager.LoadScene("Scene5", LoadSceneMode.Single);
            open = false;
            timer = 3.0f;
        }
    }
    public void TurnToRoom1()
    {
        if (open == true)
        {
            //Application.LoadLevel("room1");
			SceneManager.LoadScene("room1", LoadSceneMode.Single);
            open = false;
            timer = 3.0f;
        }
    }
    public void TurnToRoom3()
    {
        if (open == true)
        {
            //Application.LoadLevel("HappyRoom");
			SceneManager.LoadScene("HappyRoom", LoadSceneMode.Single);
            open = false;
            timer = 3.0f;
        }
    }
  
}
