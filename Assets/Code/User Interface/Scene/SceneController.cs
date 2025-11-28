using System.Collections;
using System.Collections.Generic;

namespace UnityEngine.SceneManagement
{
    public class SceneController : SingletonBasic<SceneController>
    {
        [SerializeField] private RectTransform _transform;
        [SerializeField] private FadeScene _fade;

        public List<string> scenes { get; protected set; } = new();
        private bool _lock;

        private void Start() => Instantiate(_fade, _transform);

        public void SwipeScene(string value) => OnFading(value);
        public void Quit() => OnFading(string.Empty);

        public IEnumerator AddScene(string value)
        {
            if (scenes.Contains(value)) yield break;
            yield return SceneManager.LoadSceneAsync(value, LoadSceneMode.Additive);
            scenes.Add(value);
        }
        public void RemoveScene(string value)
        {
            if (!scenes.Contains(value)) return;
            SceneManager.UnloadSceneAsync(value, UnloadSceneOptions.None);
            scenes.Remove(value);
        }
        
        public void OnCutScene(string value)
        {
            SceneManager.LoadSceneAsync(value, LoadSceneMode.Single);
        }
        private void OnFading(string value)
        {
            if (_lock) return;

            Instantiate(_fade, _transform).onComplete += onComplete;
            _lock = true;

            void onComplete()
            {
                Time.timeScale = 1;
                if (string.IsNullOrEmpty(value)) Application.Quit();
                else OnCutScene(value);
            }
        }
    }
}