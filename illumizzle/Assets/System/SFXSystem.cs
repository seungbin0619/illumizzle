using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXSystem : MonoBehaviour
{
    #region [ 인스턴스 초기화 ]

    public static SFXSystem instance;
    public AudioSource current;
    public AudioSource sound;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);

        current = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(sound.gameObject);
    }

    #endregion

    [System.Serializable]
    public class SoundData
    {
        public AudioClip sound;
        public float volume = 1;
        public double[] trim = new double[2] { 0, -1 };
    }

    [SerializeField]
    private SoundData[] bgm;

    [SerializeField]
    private SoundData[] sounds;

    private int index = -1;
    private SoundData currentBgm;

    WaitForEndOfFrame delay = new WaitForEndOfFrame();

    private bool bgmFade = false;
    private float puzzleSnd = 1f;

    private Coroutine coroutine = null;

    public void BgmChange(int index = -1)
    {
        if (index == -1 || index == this.index) return;
        StartCoroutine(CoBgmChange(index));
    }

    public void BgmVolume(float value)
    {
        IEnumerator CoBgmVolume()
        {
            float cvol = current.volume / currentBgm.volume;
            float progress = 0;

            while(progress < 0.5f)
            {
                float clamp = progress * 2f;
                puzzleSnd = LineAnimation.Lerp(cvol, value, clamp, 0.5f);

                yield return delay;
                progress += Time.deltaTime;
            }

            puzzleSnd = value;
        }

        StartCoroutine(CoBgmVolume());
    }

    private IEnumerator CoBgmChange(int index)
    {
        bgmFade = true;
        float progress = 0, duration = 0.5f;
        float weight = DataSystem.GetData("Setting", "Bgm", 100) * 0.01f;
        float volume;

        if (current.isPlaying)
        {
            // 페이드 아웃
            while (progress < duration)
            {
                volume = 1 - progress / duration;
                current.volume = weight * volume * currentBgm.volume;

                yield return delay;
                progress += Time.deltaTime;
            }
            current.volume = 0;

            currentBgm = null;
            current.Stop();
            current.clip = null;
        }

        this.index = index;

        currentBgm = bgm[index];
        current.clip = currentBgm.sound;
        current.Play();

        // 페이드 인
        progress = 0;
        while (progress < duration)
        {
            volume = progress / duration;
            current.volume = weight * volume * currentBgm.volume;

            yield return delay;
            progress += Time.deltaTime;
        }

        current.volume = weight * currentBgm.volume;
        bgmFade = false;
    }

    public void PlaySound(int index)
    {
        if (index < 0 || index >= sounds.Length) return;
        float weight = DataSystem.GetData("Setting", "Sound", 100) * 0.01f;

        sound.clip = sounds[index].sound;
        sound.volume = weight * sounds[index].volume;
        sound.PlayScheduled(sounds[index].trim[0]);

        if(sounds[index].trim[1] != -1)
            coroutine = StartCoroutine(CoPlay(index));
    }

    public void StopSound(float fade = 0)
    {
        if (coroutine != null) StopCoroutine(coroutine);
        coroutine = null;

        IEnumerator CoFade()
        {
            float progress = 0, vol = sound.volume;
            while(progress < fade)
            {
                sound.volume = vol * (1 - progress / fade);
                yield return delay;

                progress += Time.deltaTime;
            }
            sound.Stop();
            sound.clip = null;
        }
        StartCoroutine(CoFade());
    }

    private IEnumerator CoPlay(int index)
    {
        while (sound.time < sounds[index].trim[1])
        {
            yield return delay;
        }
        sound.Stop();
        sound.clip = null;
    }

    private void Update()
    {
        if (bgmFade) return;
        if (currentBgm == null) return;
        //
        current.volume = DataSystem.GetData("Setting", "Sound", 100) * 0.01f * currentBgm.volume * puzzleSnd;
    }
}
