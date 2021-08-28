using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f;

    public AudioClip clip;
 
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();

            if(player != null)
            {
                AudioSource.PlayClipAtPoint(clip, transform.position, 1.0f);
                
                //player.AddCoins();
            }

            Debug.Log("Obtained a Coin");
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
    }
}
