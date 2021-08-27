using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private float speed = 50f;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        
      //  transform.position = new Vector3(player.transform.position.x, 200, player.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log("Hit by Meteor");
            Destroy(this.gameObject);

            //instantiate explosion effect 

        }
    }
}
