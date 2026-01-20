using UnityEngine;

namespace Unity.Events
{
    public class TapObjectOnTimeImpostor : TapObjectOnTime
    {
        [Header("Renderer")]
        [SerializeField] private SpriteRenderer _render;
        [SerializeField] private Sprite _impostor;

        [SerializeField, Range(0f, 1f)] private float _rate = 0.5f;

        private bool _isImpostor;
        private Sprite _common;

        protected override void Awake()
        {
            base.Awake();
            _common = _render.sprite;
        }
        protected override void EnableTap()
        {
            base.EnableTap();

            _isImpostor = Random.value <= _rate;
            _render.sprite = !_isImpostor ? _common : _impostor;
        }
        protected override void OnInteract()
        {
            if (!_isImpostor) { base.OnInteract(); return; }

            StartCoroutine(RecoveryInteract());
            _onTapObject?.Invoke();
            _group?.OnFailure();
        }
    }
}