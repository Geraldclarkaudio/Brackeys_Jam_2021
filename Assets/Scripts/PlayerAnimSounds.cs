using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField]
    private AudioClip[] footsteps;
    [SerializeField]
    private AudioClip swordSwing;
    [SerializeField]
    private AudioClip skeletonDeath;
    [SerializeField]
    private AudioClip skeletonFall;

    public void Start()
    {
        _audioSource = GetComponentInParent<AudioSource>();
    }
    public void SwordSwing()
    {
        _audioSource.clip = swordSwing;
        _audioSource.volume = 1.0f;
        _audioSource.Play();
    }


    public void FootSteps()
    {
        _audioSource.clip = footsteps[Random.Range(0,3)];
        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.volume = Random.Range(0.05f, 0.15f);
        _audioSource.Play();
    }

    public void SkeletonDeathsounds()
    {
        _audioSource.clip = skeletonDeath;
        _audioSource.volume = 1.0f;
        _audioSource.Play();
    }
    public void SkeletonFall()
    {
        _audioSource.clip = skeletonFall;
        _audioSource.volume = 1.0f;
        _audioSource.Play();
    }


}
