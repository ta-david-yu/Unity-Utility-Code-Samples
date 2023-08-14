using UnityEngine;


/// <summary>
/// This class is only made to make use of polymorphism. Use the generic version of <see cref="GlobalHandleRegister{T}"/> instead.
/// </summary>
public class GlobalHandleRegister : MonoBehaviour
{
    private void Awake()
    {
        _Awake();
    }

    protected virtual void _Awake() { }

    private void OnDestroy()
    {
        _OnDestroy();
    }

    protected virtual void _OnDestroy() { }
}
    
public class GlobalHandleRegister<T> : GlobalHandleRegister where T : Component
{
    [SerializeField]
    private T m_Instance;
    
    [SerializeField]
    private GlobalHandleSO<T> m_GlobalHandle;

    private void OnValidate()
    {
        if (!m_Instance)
        {
            m_Instance = GetComponent<T>();
        }
    }

    protected override void _Awake()
    {
        if (!m_Instance || !m_GlobalHandle)
        {
            return;
        }
            
        m_GlobalHandle.RegisterInstance(m_Instance);
    }

    protected override void _OnDestroy()
    {
        if (!m_Instance || !m_GlobalHandle)
        {
            return;
        }
            
        m_GlobalHandle.DeregisterInstance(m_Instance);
    }
}
