using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    private Player player;

    private bool canHit = true;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player" && canHit == true)
        {
            player = other.GetComponent<Player>();

            Debug.Log("Damaged Player");
            player.Damage();
            canHit = false;
            StartCoroutine(CanHitReset());
        }
    }

    IEnumerator CanHitReset()
    {
        yield return new WaitForSeconds(0.3f);
        canHit = true;
    }
}
