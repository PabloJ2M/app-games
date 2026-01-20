using System;
using PrimeTween;

namespace UnityEngine.Animations
{
    public interface ITween
    {
        TweenSettings Settings { get; }
        bool IsEnabled { get; set; }

        void Play(bool value);
        void ForcePlay(bool value);
    }

    public interface ITweenCallback
    {
        event Action<bool> onPlayStatusChanged;
        event Action onEnabled, onDisabled;
        event Action onCompleted;

        void OnComplete();
    }
}