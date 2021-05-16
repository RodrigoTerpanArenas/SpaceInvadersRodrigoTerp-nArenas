using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeAudio : MonoBehaviour
{
    //Este código va a hacer sonar el efecto de sonido de muerte del enemigo cuando muera cualquier enemigo.
    private AudioSource _audioSource;

    private void Awake() => _audioSource = GetComponent<AudioSource>();

    private void OnEnable() => UpgradeBehavior.UpG += PlayAudio;

    private void OnDisable() => UpgradeBehavior.UpG -= PlayAudio;

    private void PlayAudio() => _audioSource.Play();
}
