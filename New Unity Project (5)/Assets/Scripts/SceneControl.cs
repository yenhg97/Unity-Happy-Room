using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControl : MonoBehaviour
{
    public GameObject door1, door2, door3;
    RaycastHit hit;
    float timer = 3.0f;
    bool open = false;
    // Use this for initialization

    public GameObject room_2;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
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
            Application.LoadLevel("scene5");
            open = false;
            timer = 3.0f;
        }
    }
    public void TurnToRoom1()
    {
        if (open == true)
        {
            Application.LoadLevel("room1");
            open = false;
            timer = 3.0f;
        }
    }
    public void TurnToRoom3()
    {
        if (open == true)
        {
            Application.LoadLevel("HappyRoom");
            open = false;
            timer = 3.0f;
        }
    }
  
}
