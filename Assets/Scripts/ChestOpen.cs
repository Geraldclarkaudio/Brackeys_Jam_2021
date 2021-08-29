using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    private Animator anim;
    private AudioSource _audioSource;
    public GameObject pressE;

    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private bool canOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        canOpen = true;
        pressE.SetActive(true);

    }
    private void OnTriggerExit(Collider other)
    {
        canOpen = false;
        pressE.SetActive(false);
    }

    private void Update()
    {
        if (canOpen == true && Input.GetKeyDown(KeyCode.E))
        {
            canOpen = false;
            anim.SetTrigger("Open");
            _audioSource.Play();
            Instantiate(coinPrefab, transform.position, Quaternion.identity);

        }
    }
}
