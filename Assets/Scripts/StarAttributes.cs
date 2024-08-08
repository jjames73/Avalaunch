using UnityEngine;

public class StarAttributes : MonoBehaviour
{
    public static int starCount = 0;
    private AudioSource starSound;

    void Start()
    {
        starSound = GetComponent<AudioSource>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            if (starSound != null)
            {
                starSound.Play();
            }

            Destroy(gameObject);
            starCount++;
            Debug.Log(starCount);
        }
    }
}
    
