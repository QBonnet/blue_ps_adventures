using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] m_playlist;
    public AudioSource m_audioSource;
    public AudioMixerGroup m_sfxMixer;
    private int m_musicIndex = 0;

    public static AudioManager m_instance;

    private void Awake()
    {
        if (m_instance != null)
        {
            Debug.LogWarning("AudioManager > 1");
            return;
        }

        m_instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_audioSource.clip = m_playlist[0];
        m_audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_audioSource.isPlaying)
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        m_musicIndex = (m_musicIndex + 1) % m_playlist.Length;
        m_audioSource.clip = m_playlist[m_musicIndex];
        m_audioSource.Play();
    }

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("tempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = m_sfxMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
