using System;
using UnityEngine;

public class GlobalHandleSO<T> : ScriptableObject where T : Component
{
    public T Instance { get; private set; }

    public event Action<T> OnAfterInstanceRegistered = delegate { };
    public event Action<T> OnBeforeInstanceDeregistered = delegate { };

    public void RegisterInstance(T instance)
    {
        if (Instance)
        {
            Debug.LogError(
                $"An {nameof(T)} instance has already been registered ({Instance.gameObject.name}) to the handle. Skip registration.");
            return;
        }

        Instance = instance;

        OnAfterInstanceRegistered?.Invoke(Instance);
    }

    public void DeregisterInstance(T instance)
    {
        if (instance != Instance)
        {
            Debug.LogError(
                $"Trying to deregister a different {nameof(T)} instance from the handle. Skip deregistration.");
            return;
        }

        OnBeforeInstanceDeregistered?.Invoke(Instance);

        Instance = null;
    }
}