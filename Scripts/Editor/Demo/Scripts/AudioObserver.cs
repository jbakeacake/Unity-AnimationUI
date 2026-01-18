using Unity_AnimationUI.Scripts.Runtime;
using UnityEngine;

namespace Unity_AnimationUI.Scripts.Editor.Demo.Scripts
{
public class AudioObserver : MonoBehaviour
{
    [SerializeField] AudioManager _audio;
    void OnEnable()
    {
        ButtonUI.s_onClick += this.ButtonOnClick;
        ButtonUI.s_onPointerEnter += this.ButtonEnter;
        ButtonUI.s_onPointerDown += this.ButtonDown;
        ButtonUI.s_onSelect += this.ButtonEnter;

        AnimationUI.OnPlaySoundByFile += this._audio.PlaySound;
        AnimationUI.OnPlaySoundByIndex += this._audio.PlaySound;
    }
    void OnDisable()
    {
        ButtonUI.s_onClick -= this.ButtonOnClick;
        ButtonUI.s_onPointerEnter -= this.ButtonEnter;
        ButtonUI.s_onPointerDown -= this.ButtonDown;
        ButtonUI.s_onSelect -= this.ButtonEnter;

        AnimationUI.OnPlaySoundByFile -= this._audio.PlaySound;
        AnimationUI.OnPlaySoundByIndex -= this._audio.PlaySound;
    }

    void ButtonEnter() => this._audio.PlaySound(3);
    void ButtonOnClick() => this._audio.PlaySound(2);
    void ButtonDown() => this._audio.PlaySound(0);
}

}