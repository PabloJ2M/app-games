using System.Collections;
using UnityEngine;
using PrimeTween;

namespace Unity.Events
{
    using Mathematics;
    using Random = Random;

    public class HitObject : Element
    {
        [SerializeField] private Transform _entity, _trap;
        [SerializeField] private float _distance, _threshold;
        [SerializeField] private float2 _timeLife, _timeOut;

        [SerializeField] private GameObject _particle;

        [SerializeField] private TweenSettings _targetSettings, _originSettings;

        private TweenSettings<float> _animationTarget, _animationOrigin;
        private Transform _target;

        private WaitWhile _whileDisplayed;
        private bool _canBeHitted, _isTrap;
        private float _origin;

        private IEnumerator Animation()
        {
            float time = Random.Range(_timeOut.x, _timeOut.y);
            yield return new WaitForSeconds(time);

            _isTrap = Random.value <= _threshold;
            _target = !_isTrap ? _entity : _trap;
            _canBeHitted = true;

            Tween.StopAll(_target);
            Tween.LocalPositionY(_target, _animationTarget).OnComplete(HideDelay);
            
            yield return _whileDisplayed;
            yield return new WaitForSeconds(_animationTarget.settings.duration);

            StartCoroutine(Animation());
        }
        private void HideDelay() => Invoke(nameof(Hide), Random.Range(_timeLife.x, _timeLife.y));
        private void Hide()
        {
            Tween.StopAll(_target);
            Tween.LocalPositionY(_target, _animationOrigin);
            CancelInvoke(nameof(Hide));
            _canBeHitted = false;
        }

        public override void Init(ElementGroup group)
        {
            base.Init(group);
            
            _origin = _entity.LocalPositionY() - _distance;
            _animationOrigin = new(_origin, _originSettings);
            _animationTarget = new(_origin + _distance, _targetSettings);

            _entity.LocalPositionY(_origin);
            _trap.LocalPositionY(_origin);
        }
        public override void OnStart() => StartCoroutine(Animation());
        public override void OnStop() => StopAllCoroutines();
        public override void Interact()
        {
            if (!_canBeHitted) return;

            if (_isTrap) _group.OnFailure(); else _group.OnSuccess();
            
            _particle?.SetActive(true);
            Invoke(nameof(DestroyParticle), 0.1f);
            Hide();
        }

        private void DestroyParticle() => _particle.SetActive(false);
    }
}