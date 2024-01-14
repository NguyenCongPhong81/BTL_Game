using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEditor.PackageManager.UI;
using Unity.VisualScripting.FullSerializer;

namespace MathRun
{
    public enum ESoundType
    {
        None = 0,
        Bg_Game = 1,
        Sfx_Dead = 2,
        Sfx_Trigger_Point = 3,
        Sfx_Use_Wood = 4,


    }

    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource bgSource;
        [SerializeField] private AudioSource bgSfx;
        [SerializeField] private AudioSource bgSfxUseWood;
        [SerializeField] private AudioSource bgSfxDead;
        [SerializeField] private List<AudioSource> poolAudioSoureSfx;

        [Serializable]
        public struct SoundEntry
        {
            public ESoundType soundType;
            public AudioClip audioClip;
        }

        [SerializeField] private SoundEntry[] soundEntries;

        private Dictionary<ESoundType, AudioSource> audioSoureSfxCollection;

        public static SoundManager Instance;

        private void Awake()
        {
            Instance = this;
        }

        public void PlayBg(ESoundType type, bool isLoop)
        {
            PlayBg(GetClip(type), isLoop);
        }

        public void PlaySfx(ESoundType type)
        {
            PlaySfx(GetClip(type));
        }

        private void PlaySfx(AudioClip audioClip)
        {
            StopSfx();
            bgSfx.clip = audioClip;
            bgSfx.Play();
        }

        public void PlaySfxUseWood(ESoundType type)
        {
            PlaySfxUseWood(GetClip(type));
        }

        public void PlaySfxDead(ESoundType type)
        {
            PlaySfxDead(GetClip(type));
        }

        private void PlaySfxUseWood(AudioClip audioClip)
        {
            StopSfxUseWood();
            bgSfxUseWood.clip = audioClip;
            bgSfxUseWood.Play();
        }

        private void PlaySfxDead(AudioClip audioClip)
        {
            StopSfxDead();
            bgSfxDead.clip = audioClip;
            bgSfxDead.Play();
        }

        private void PlayBg(AudioClip clip, bool isLoop)
        {
            StopBg();
            bgSource.clip = clip;
            bgSource.loop = isLoop;
            //bgSource.volume = Config.Instance.BgVolume;
            bgSource.Play();
        }

        public void StopBg()
        {
            bgSource.Stop();
            StopAllCoroutines();
        }

        public void StopSfx()
        {
            bgSfx.Stop();
            StopAllCoroutines();
        }

        public void StopSfxUseWood()
        {
            bgSfxUseWood.Stop();
            StopAllCoroutines();
        }
        public void StopSfxDead()
        {
            bgSfxDead.Stop();
            StopAllCoroutines();
        }

        public void UnMuteMusic()
        {
            bgSfx.mute = false;
            bgSfxDead.mute = false;
            bgSfxUseWood.mute = false;
            bgSource.mute = false;
        }

        public void MuteMusic()
        {
            bgSfx.mute = true;
            bgSfxDead.mute = true;
            bgSfxUseWood.mute = true;
            bgSource.mute = true;
        }
        private AudioClip GetClip(ESoundType type)
        {
            foreach (var entry in soundEntries)
            {
                if (entry.soundType == type)
                {
                    return entry.audioClip;
                }
            }
            return null;
        }

    }
}
