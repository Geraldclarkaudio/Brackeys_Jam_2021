using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;

    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;

    }
    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
    }

    private void Update()
    {
        if (canOpen == true && Input.GetKeyDown(KeyCode.E))
        {
            canOpen = false;
            anim.SetTrigger("Open");
        }
    }
}
