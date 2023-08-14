using UnityEngine;

/// <summary>
/// This class is only made to make use of polymorphism. Use the generic version of <see cref="RegisterToRuntimeSet{T}"/> instead.
/// </summary>
public class RegisterToRuntimeSet : MonoBehaviour
{
    private void Awake()
    {
        _Awake();
    }

    protected virtual void _Awake()
    {
    }

    private void OnDestroy()
    {
        _OnDestroy();
    }

    protected virtual void _OnDestroy()
    {
    }
}

public class RegisterToRuntimeSet<T> : RegisterToRuntimeSet where T : UnityEngine.Object
{
    [SerializeField]
    private T m_Instance;

    [SerializeField]
    private RuntimeSetSO<T> m_RuntimeSet;

    protected override void _Awake()
    {
        if (!m_Instance || !m_RuntimeSet)
        {
            return;
        }

        m_RuntimeSet.AddInstance(m_Instance);
    }

    protected override void _OnDestroy()
    {
        if (!m_Instance || !m_RuntimeSet)
        {
            return;
        }

        m_RuntimeSet.RemoveInstance(m_Instance);
    }
}