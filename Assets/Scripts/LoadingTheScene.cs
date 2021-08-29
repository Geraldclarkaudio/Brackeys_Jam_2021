using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingTheScene : MonoBehaviour
{
    [SerializeField]
    private GameObject uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager.SetActive(true);
        SceneManager.LoadScene(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
