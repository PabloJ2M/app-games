using UnityEngine;

namespace Unity.Events
{
    public abstract class Element : MonoBehaviour
    {
        protected ElementGroup _group;

        public virtual void Init(ElementGroup group) => _group = group;
        public abstract void OnStart();
        public abstract void OnStop();
        public abstract void Interact();
    }
}