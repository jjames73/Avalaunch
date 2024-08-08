using UnityEngine;

public class MenuSound : MonoBehaviour
{
    private AudioSource MenuS;

    void Start()
    {
        MenuS = GetComponent<AudioSource>();
        MenuS.Play();
    }
}

