using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.Events
{
    public abstract class ElementGroup : MonoBehaviour
    {
        [SerializeField] protected UnityEvent _onSuccess, _onFailure;
        protected Element[] _elements;

        protected virtual void Awake() => _elements = GetComponentsInChildren<Element>();
        protected virtual IEnumerator Start()
        {
            foreach (var element in _elements)
                element?.Init(this);

            yield return new WaitUntil(() => GameManager.Instance.IsEnabled);

            foreach (var element in _elements)
                element?.OnStart();
        }

        public abstract bool Compare(Element element);
        public abstract void OnSuccess();
        public abstract void OnFailure();
        public void OnCompleteGame()
        {
            foreach (var element in _elements)
                element.OnStop();
        }
        public void OnForceReloadGame() => StartCoroutine(Start());
    }
}