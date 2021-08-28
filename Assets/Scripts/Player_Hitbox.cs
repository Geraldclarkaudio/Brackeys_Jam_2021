using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hitbox : MonoBehaviour
{
    private Skeleton_Enemy skeleton;

    private void OnTriggerEnter(Collider other)
    {
        skeleton = other.GetComponent<Skeleton_Enemy>();
        Debug.Log("Hit:" + other.name);
        skeleton.Death();
    }
}
