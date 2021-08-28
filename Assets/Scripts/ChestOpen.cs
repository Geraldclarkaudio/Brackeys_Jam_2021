using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject coinPrefab;

    private bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;

        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && canOpen == true)
        {
            anim.SetTrigger("Open");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }
}
