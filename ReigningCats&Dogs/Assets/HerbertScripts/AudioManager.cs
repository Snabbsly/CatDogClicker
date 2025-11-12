using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] AudioSource[] audioSources;
    [SerializeField] AudioClip[] audioClips;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public void PlaySound(int sound, int source)
    {
        //Plays all sound effects, depending on the parameters
        audioSources[source].clip = audioClips[sound];
        audioSources[source].Play();
    }
}
