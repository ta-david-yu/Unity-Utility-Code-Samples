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
    private T _instance;

    [SerializeField]
    private RuntimeSetSO<T> _runtimeSet;

    protected override void _Awake()
    {
        if (!_instance || !_runtimeSet)
        {
            return;
        }

        _runtimeSet.AddInstance(_instance);
    }

    protected override void _OnDestroy()
    {
        if (!_instance || !_runtimeSet)
        {
            return;
        }

        _runtimeSet.RemoveInstance(_instance);
    }
}