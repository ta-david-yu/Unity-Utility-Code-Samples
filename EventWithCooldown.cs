using UnityEngine;
using UnityEngine.Events;

public class EventWithCooldown : MonoBehaviour
{
	public UnityEvent Event = new UnityEvent();

	[SerializeField]
	private float m_Cooldown = 0.5f;

	private float m_CooldownTimer = 0.0f;

	private void Update()
	{
		if (m_CooldownTimer <= 0.0f)
		{
			return;
		}

		m_CooldownTimer -= Time.deltaTime;
	}

	public void Execute()
	{
		if (m_CooldownTimer > 0.0f)
		{
			return;
		}

		Event?.Invoke();

		m_CooldownTimer = m_Cooldown;
	}
}
