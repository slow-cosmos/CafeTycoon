using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region Singleton
    public static SoundManager instance = null;
    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Init();
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    #endregion

    [SerializeField] private AudioSource bgm;
    [SerializeField] private AudioSource effect;

    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    private AudioClip[] resources;

    private void Init()
    {
        resources = Resources.LoadAll<AudioClip>("Sound");
        for (int i = 0; i < resources.Length; i++)
        {
            clips[resources[i].name] = resources[i];
        }
        PlayBgm("Lobby");
    }

    public void PlayBgm(string sceneName, float vol = 0.6f)
    {
        bgm.loop = true;
        bgm.volume = vol;
        bgm.clip = clips[sceneName];
        bgm.Play();
    }

    public void PlayEffect(string name, float vol = 0.6f)
    {
        effect.loop = false;
        effect.volume = vol;
        effect.PlayOneShot(clips[name]);
    }
}
