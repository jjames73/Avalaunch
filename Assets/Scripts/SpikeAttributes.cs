using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeAttributes : MonoBehaviour
{
    private Renderer pr;
    private Color origColor;
    private AudioSource damageSound;

    void Start()
    {
        damageSound = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (pr == null)
            {
                pr = other.GetComponent<Renderer>();
                origColor = pr.material.color;
            }

            if (damageSound != null)
            {
                damageSound.Play();
            }

            StartCoroutine(DamageFlash());
            StarAttributes.starCount--;
            Debug.Log("Stars Left: " + StarAttributes.starCount);

            if (StarAttributes.starCount < 0)
            {
                StartCoroutine(DamageFlash());
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }

    IEnumerator DamageFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            pr.material.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            pr.material.color = origColor;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
