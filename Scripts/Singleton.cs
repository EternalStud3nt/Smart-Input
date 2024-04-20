using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }
    public bool doNotDestroyOnLoad;
    protected virtual void Awake()
    {
        if (Instance == null)
        {
            Instance = GetComponent<T>();
            if (doNotDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}