using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource _bgmSource = null;
    [SerializeField] private AudioSource _soundSource = null;
    public static SoundManager _instance { get; private set; }

    private Dictionary<string, AudioClip> _loadedClip = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
            Destroy(this.gameObject);
    }
    
    private AudioClip LoadAudioClip(string fullPath)
    {
        AudioClip clip = null;
        if (_loadedClip.TryGetValue(fullPath, out clip))
            return clip;

        clip = Resources.Load<AudioClip>(fullPath);
        if (clip == null)
        {
            Debug.LogError($"[SoundManager.LoadAudioClip.InvalidPath]{fullPath}");
            return null;
        }

        _loadedClip.Add(fullPath, clip);
        return clip;
    }

    #region BGM
    

    private static string GetBGMFullPath(string path) => Define.bgmRoot + "/" + path;
    public void LoadBGM(string path) => LoadAudioClip(GetBGMFullPath(path));

    public void PlayBGM(string path)
    {
        AudioClip clip = LoadAudioClip(GetBGMFullPath(path));
        if (clip == null)
            return;

        _bgmSource.clip = clip;
        _bgmSource.Play();
    }

    public void StopBGM() => _bgmSource.Stop();

    #endregion

    #region SoundEffect

    private static string GetSoundFullPath(string path) => Define.soundRoot + "/" + path;

    public void LoadSound(string path) => LoadAudioClip(GetSoundFullPath(path));

    public void PlaySound(string path)
    {
        AudioClip clip = LoadAudioClip(GetSoundFullPath(path));
        if (clip == null)
            return;
        _soundSource.PlayOneShot(clip);
    }

    public void ClearLoadedAudioClip() => _loadedClip.Clear();
    public void StopSound() => _soundSource.Stop();

    // 대사용 코루틴 추가
    public void PlaySoundCor(string path, System.Action onComplete = null)
    {
        AudioClip clip = LoadAudioClip(GetSoundFullPath(path));
        if (clip == null)
            return;

        _soundSource.PlayOneShot(clip);
        StartCoroutine(InvokeOnComplete(clip.length, onComplete));
    }

    private IEnumerator InvokeOnComplete(float clipLength, System.Action onComplete)
    {
        yield return new WaitForSeconds(clipLength);
        onComplete?.Invoke();
    }

    #endregion
}
