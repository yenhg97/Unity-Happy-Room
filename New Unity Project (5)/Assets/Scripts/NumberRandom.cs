using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberRandom : MonoBehaviour {
    int number_of_wall = 4;
    public GameObject[] wall;
    int max_item = 4;
    int[] mynumber = new int[36];
    int total = 1000;
    public int step = 50;
    // Use this for initialization
    void Start () {
        create_number();
        int mycount = 0;
        for (int j = 0; j < number_of_wall; j++)
        {
            int n = wall[j].transform.childCount;
            for (int i = 0; i < n; i++)
            {

                wall[j].transform.GetChild(i).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text = mynumber[mycount].ToString();
                mycount++;
            }

        }
            //output = wall.transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<Text>().text;
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    void create_number()
    {
        
        int tmp2; int mycount=-1;
        
        for (int j = 0; j < 9; j++)
        {
            int tmp = total;
            for (int i = 0; i < max_item - 1; i++)
            {
                tmp2 = Random.Range(1, (tmp/step));
                tmp2 = tmp2 * step;
                tmp = tmp - tmp2;
                if (tmp2 <= 0) { tmp2 = 150; }
                mycount++;
                mynumber[mycount] = tmp2;

                
            }
            if (tmp<=0) { tmp = 350; }
            mycount++;
            mynumber[mycount] = tmp;
        }
        

    }
}
