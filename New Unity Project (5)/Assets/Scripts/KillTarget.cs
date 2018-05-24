using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillTarget : MonoBehaviour {

    //public GameObject target;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    float timeToSelect = 1.0f;
    int score;
    public Text turn;
    private float countDown;
   
    //public string Output;
    int max_item = 4;
    int target_number = 1000;
    public GameObject EndGame;
    public GameObject WinGame;
    public GameObject Instruction;
    int Result = 0;

    // Use this for initialization
    void Start () {
        score = 0;
        countDown = timeToSelect;
        hitEffect.enableEmission = false;

        //Instruction.SetActive(false);
        //StartCoroutine(delayTime());

        Destroy(Instruction, 2.0f);
        turn.text = "Turn: "+max_item.ToString();


    }

    // Update is called once per frame
    void Update () {
      
        Transform camera = Camera.main.transform;
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast (ray,out hit)&& (hit.collider.gameObject.tag == "Target"))
        {
            if (countDown > 0.0f)
            {
                countDown -= Time.deltaTime;
                hitEffect.transform.position = hit.point;
                hitEffect.enableEmission = true;
                
            }
            else
            {
              
                Instantiate(killEffect, hit.collider.gameObject.transform.position, hit.collider.gameObject.transform.rotation);
                countDown = timeToSelect;
                Destroy(hit.collider.gameObject);
                score += 1;
                turn.text = "Turn: "+(max_item - score).ToString();
                string Output = hit.collider.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
                Result += int.Parse(Output);
              
                if (score==max_item)
                {
                    if (Result==target_number)
                    {
                        WinGame.SetActive(true);
                        
                    }
                    else {
                        EndGame.SetActive(true);
                        turn.text = "Status: " + Result.ToString()+" / "+target_number.ToString();
                    }

                    //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                    delayTime();
                    Application.LoadLevel("WaitingRoom");
                }
                
            }
        }
        else
        {
            countDown = timeToSelect;
            hitEffect.enableEmission = false;

        }
		
	}
    IEnumerator delayTime()
    {
        yield return new WaitForSeconds(8.0f);
    }
   
    

}
