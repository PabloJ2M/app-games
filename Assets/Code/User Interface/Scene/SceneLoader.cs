namespace UnityEngine.SceneManagement
{
    [AddComponentMenu("System/SceneManagement/SceneLoader")]
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] protected string _scenePath;
        public string ScenePath { get => _scenePath; set => _scenePath = value; }

        [ContextMenu("Cut Scene")]
        public void CutScene() => SceneController.Instance?.OnCutScene(_scenePath);

        [ContextMenu("Add Scene")]
        public void AddScene() => StartCoroutine(SceneController.Instance?.AddScene(_scenePath));

        [ContextMenu("Remove Scene")]
        public void RemoveScene() => SceneController.Instance?.RemoveScene(_scenePath);

        [ContextMenu("Swipe Scene")]
        public void SwipeScene() => SceneController.Instance?.SwipeScene(_scenePath);

        [ContextMenu("Reload Scene")]
        public void ReloadScene() => SceneController.Instance?.SwipeScene(SceneManager.GetActiveScene().path);

        [ContextMenu("Close Game")]
        public void CloseGame() => SceneController.Instance?.SwipeScene(string.Empty);
    }
}