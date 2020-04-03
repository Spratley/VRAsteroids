using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    public AudioClip breakAsteroid;

    public AudioSource laserL;
    public AudioSource laserR;
    public AudioSource bonk;
    public AudioSource engineIdle;
    public AudioSource thrusterGoL;
    public AudioSource thrusterGoR;
    public AudioSource thrusterLoopL;
    public AudioSource thrusterLoopR;


    public Rigidbody shipBody;
    public GameObject asteroid;
    public float prevVelocity;
    public scoreManager player;


    void Start()
    {
        engineIdle.Play();
    }

    public void PlayLaser()
    {
        laserL.Play();
        laserR.Play();
    }

    public void PlayBreak(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(breakAsteroid, position, 4.0f);
    }

    IEnumerator EngineCheck()
    {
        thrusterGoL.Play();
        thrusterGoR.Play();

        float startVolumeL = thrusterGoL.volume;
        float startVolumeR = thrusterGoR.volume;
        while (thrusterGoL.volume > 0 && thrusterGoR.volume > 0)
        {
            thrusterGoL.volume -= startVolumeL * Time.deltaTime / thrusterGoL.clip.length;
            thrusterGoR.volume -= startVolumeR * Time.deltaTime / thrusterGoR.clip.length;
            yield return null;
        }
        thrusterGoL.Stop();
        thrusterGoR.Stop();
        thrusterGoL.volume = 0.6f;
        thrusterGoR.volume = 0.6f;

        //Switch to thrusterLoop
        thrusterLoopL.Play();
        thrusterLoopR.Play();
    }

    void Update()
    {
        if (prevVelocity <= 1)
        {
            if (shipBody.velocity.magnitude > 1)
            {
                engineIdle.Stop();
                StartCoroutine(EngineCheck());
            }
            else
            {
                //Turn that shit off if they stop moving while it's going
                thrusterLoopL.Stop();
                thrusterLoopR.Stop();
                thrusterGoL.Stop();
                thrusterGoR.Stop();

                if (!engineIdle.isPlaying)
                {
                    engineIdle.Play();
                }
            }
        }

        //Store prev velocity
        prevVelocity = shipBody.velocity.magnitude;
    }
}
