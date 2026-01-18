using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts
{
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource _soundSource;
    // [SerializeField] AudioMixer _soundMixer;
    [SerializeField] AudioClip _defaultSound;

    public void PlaySound(AudioClip audioClip, float volume)
    {
        if(audioClip == null)
        {
            this.PlayDefaultSound();
            return;
        }
        this._soundSource.PlayOneShot(audioClip, volume);
    }
    public void PlaySound(AudioClip audioClip)
    {
        if(audioClip == null)
        {
            this.PlayDefaultSound();
            return;
        }
        this._soundSource.PlayOneShot(audioClip);
    }
    void PlayDefaultSound()
    {
        if(this._defaultSound != null)
        this._soundSource.PlayOneShot(this._defaultSound);
    }

    [System.Serializable] public class Sound
    {
        [Tooltip("Clip to play")]public AudioClip Clip;
        [Tooltip("Volume of the clip")]
        public float Volume = 1;
        #if UNITY_EDITOR 
        [Tooltip("Just for naming, this isn't actually used anywhere")]public string ClipName;
        #endif
    }
    public Sound[] SFX;
    public void PlaySound(int index)
    {
        if(index > this.SFX.Length-1)
        {
            Debug.LogWarning("Please assign the clip at index " + index.ToString());
        }
        this.PlaySound(this.SFX[index].Clip, this.SFX[index].Volume);
    }
}

}