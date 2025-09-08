using UnityEngine.UI;

namespace UnityEngine.Animations
{
    [RequireComponent(typeof(Image))]
    public class TweenColorResult : TweenColor
    {
        [SerializeField] protected Color _success = Color.green, _failure = Color.red;
        private Image _image;

        protected override void Awake() { base.Awake(); _image = GetComponent<Image>(); }
        private void Start() => _default = _image.color;

        protected override void OnUpdate(Color value) => _image.color = value;
        protected override void OnComplete() { base.OnComplete(); _image.color = _default; }

        [ContextMenu("Success")] public void Success() => PlayColor(true);
        [ContextMenu("Failure")] public void Failure() => PlayColor(false);
        [ContextMenu("Clear")] public void Clear() => _target = Color.white;

        public void PlayColor(bool value)
        {
            _target = value ? _success : _failure;
            _tweenCore.Play(value);
        }
    }
}