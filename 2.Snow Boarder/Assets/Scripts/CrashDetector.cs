using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSoundSFX;
    bool hasCrashed = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            crashEffect.Play();
            Invoke("ReloadScene", loadDelay);    
            GetComponent<AudioSource>().PlayOneShot(crashSoundSFX);

            FindAnyObjectByType<PlayerController>().DisableControls();
            hasCrashed = true;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}