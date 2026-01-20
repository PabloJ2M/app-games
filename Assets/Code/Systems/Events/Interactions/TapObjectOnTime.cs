using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Events
{
    using Mathematics;
    using Random = Random;

    public class TapObjectOnTime : TapObject
    {
        [Header("Time Visibility Controls")]
        [SerializeField] private float2 _timeAliveRange = new(1f, 1f);
        [SerializeField] private float2 _timeHiddenRange = new(1f, 1f);
        [SerializeField] private UnityEvent<bool> _onStatusChanged;

        protected float TimeAlive => Random.Range(_timeAliveRange.x, _timeAliveRange.y);
        protected float TimeHidden => Random.Range(_timeHiddenRange.x, _timeHiddenRange.y);

        public override void OnStart()
        {
            StopAllCoroutines();
            StartCoroutine(DisplayTimeout());
        }
        public override void OnStop()
        {
            StopAllCoroutines();
            DisableTap();
        }
        protected override void EnableTap()
        {
            base.EnableTap();
            _onStatusChanged.Invoke(true);
        }
        protected override void DisableTap()
        {
            base.DisableTap();
            _onStatusChanged.Invoke(false);
        }

        private IEnumerator DisplayTimeout()
        {
            DisableTap();
            yield return new WaitForSeconds(TimeHidden);

            EnableTap();
            yield return new WaitForSeconds(TimeAlive);

            StartCoroutine(DisplayTimeout());
        }
    }
}