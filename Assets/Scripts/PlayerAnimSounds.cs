using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip footsteps;
    [SerializeField]
    private AudioClip swordSwing;

    public void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }
    public void SwordSwing()
    {
        _audioSource.clip = swordSwing;
        _audioSource.Play();
    }


    public void FootSteps()
    {
        _audioSource.clip = footsteps;
        _audioSource.Play();
    }


}
