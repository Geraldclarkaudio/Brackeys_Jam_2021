using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnterIsland : MonoBehaviour
{
    [SerializeField]
    private bool canEnter = false;

    [SerializeField]
    private int islandScene;

    public GameObject pressE;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            pressE.SetActive(true);
            canEnter = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            pressE.SetActive(false);
            canEnter = false;
        }
    }

    private void Update()
    {
        if(canEnter == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Can Enter Island");
            //Load Scene
            SceneManager.LoadScene(islandScene);

           
        }
    }
}
