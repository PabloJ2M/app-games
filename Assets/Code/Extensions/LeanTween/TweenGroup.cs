using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

namespace UnityEngine.Animations
{
    public class TweenGroup : MonoBehaviour
    {
        [SerializeField] private float _delay;

        [SerializeField] private bool _negateCallback;
        [SerializeField] private UnityEvent<bool> _onValueChanged;

        private List<ITween> tweens = new();

        public void AddListener(ITween tween) => tweens.Add(tween);
        public void RemoveListener(ITween tween) => tweens.Remove(tween);

        [ContextMenu("Show")] public void EnableTween() => SetTweenStatus(true);
        [ContextMenu("Hide")] public void DisableTween() => SetTweenStatus(false);
        private void SetTweenStatus(bool value) => StartCoroutine(TweenDelay(value));

        private IEnumerator TweenDelay(bool value)
        {
            WaitForSeconds delay = new(_delay);
            foreach (var tween in tweens) { tween.Play(value); if (_delay != 0) yield return delay; }
            _onValueChanged.Invoke(_negateCallback ? !value : value);
        }
    }
}