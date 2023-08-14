using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
/// This class is only made to make use of polymorphism. Use the generic version of <see cref="RuntimeSetSO{T}"/> instead.
/// </summary>
public abstract class RuntimeSetSO : ScriptableObject
{
    public abstract IReadOnlyList<UnityEngine.Object> InstancesAsObjects { get; }
}

public class RuntimeSetSO<T> : RuntimeSetSO where T : UnityEngine.Object
{
    private List<T> m_Instances = new List<T>();
    public IReadOnlyList<T> Instances => m_Instances.AsReadOnly();

    /// <summary>
    /// This is slow, avoid using this in critical path.
    /// </summary>
    public override IReadOnlyList<UnityEngine.Object> InstancesAsObjects =>
        m_Instances.Cast<UnityEngine.Object>() as IReadOnlyList<UnityEngine.Object>;

    public event Action<T> OnAfterInstanceAdded = delegate { };
    public event Action<T> OnBeforeInstanceRemoved = delegate { };

    public event Action<List<T>> OnSetUpdated = delegate { };

    public void AddInstance(T instanceToAdd)
    {
        bool isIncluded = m_Instances.Contains(instanceToAdd);
        if (isIncluded)
        {
            Debug.LogError($"The {nameof(T)} instance ({instanceToAdd.name}) has already been added to the set.",
                instanceToAdd);
            return;
        }

        m_Instances.Add(instanceToAdd);
        OnAfterInstanceAdded?.Invoke(instanceToAdd);

        OnSetUpdated?.Invoke(m_Instances.ToList());
    }

    public void RemoveInstance(T instanceToRemove)
    {
        OnBeforeInstanceRemoved?.Invoke(instanceToRemove);
        m_Instances.Remove(instanceToRemove);

        OnSetUpdated?.Invoke(m_Instances.ToList());
    }
}
