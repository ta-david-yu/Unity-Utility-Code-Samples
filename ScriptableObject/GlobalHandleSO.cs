using System;
using UnityEngine;

/// <summary>
/// This class is only made to make use of polymorphism. Use the generic version of <see cref="GlobalHandleSO{T}"/> instead.
/// </summary>
public abstract class GlobalHandleSO : ScriptableObject
{
    public abstract Component InstanceAsComponent { get; }
}

public class GlobalHandleSO<T> : GlobalHandleSO where T : Component
{
    public override Component InstanceAsComponent => Instance as Component;
    
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