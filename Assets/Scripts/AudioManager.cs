using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioManagerClip
{
  public string Name;
  public AudioClip Clip;
  public float Volume, Pitch;
  public bool Loop;
}

public class AudioManager : MonoBehaviour
{
  public AudioManagerClip[] Clips;

  private Dictionary<AudioManagerClip, AudioSource> _sources;

   void Awake()
  {
    _sources = new Dictionary<AudioManagerClip, AudioSource>();
    foreach(AudioManagerClip clip in Clips)
      _sources.Add(clip, gameObject.AddComponent<AudioSource>());
  }

  public void Play(string name)
  {
    AudioManagerClip clip = System.Array.Find(Clips, c => c.Name == name);
    if (clip != null)
      Play(clip);
    else
      Debug.LogWarning("Audio clip \"" + name + "\" not found!");
  }

  public void Play(AudioManagerClip clip)
  {
    AudioSource source = _sources[clip];
    source.clip = clip.Clip;
    source.volume = clip.Volume;
    source.pitch = clip.Pitch;
    source.loop = clip.Loop;

    source.Play();
  }
}