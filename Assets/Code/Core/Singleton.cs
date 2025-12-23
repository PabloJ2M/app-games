using UnityEngine;

[DefaultExecutionOrder(-100)]
public abstract class SingletonBasic<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake() => Instance = this as T;
}

[DefaultExecutionOrder(-500)]
public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        //create singleton
        if (Instance) { Destroy(gameObject); return; }

        transform.SetParent(null);
        Instance = this as T;
        DontDestroyOnLoad(gameObject);
    }
}