using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AllAboard : MonoBehaviour
{
    [SerializeField]
    private bool canBoard = false;
    [SerializeField]
    private int shipSceneToLoad;
    [SerializeField]
    private GameObject presEBubble;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canBoard = true;
            presEBubble.SetActive(true);
            
        }
    }
    private void nTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            canBoard = false;
            presEBubble.SetActive(false);
        }
    }

    private void Update()
    {
        if(canBoard == true && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("On the Ship!");
            SceneManager.LoadScene(shipSceneToLoad);

        }
    }
}
