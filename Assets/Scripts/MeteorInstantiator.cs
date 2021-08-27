using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorInstantiator : MonoBehaviour
{
    public GameObject meteorPrefab;
    private bool instantiated = false;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(instantiated == false)
        {
            StartCoroutine(MeteorShower());
            instantiated = true;
        }
    }

    IEnumerator MeteorShower()
    {
        Instantiate(meteorPrefab, new Vector3(player.transform.position.x, 200, player.transform.position.z), Quaternion.identity);
        yield return new WaitForSeconds(3.0f);
        instantiated = false;
    }
}
