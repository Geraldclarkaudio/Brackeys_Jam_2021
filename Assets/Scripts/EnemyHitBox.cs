using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    private Player player;
 

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            player = other.GetComponent<Player>();

            Debug.Log("Damaged Player");
            player.Damage();  
        }
    }
}
