using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Destructible2D.Examples
{
	/// <summary>This component turns the current Rigidbody2D into a spaceship that can jump in position while slicing and can be controlled with the <b>Horizontal</b> and <b>Vertical</b> and <b>Jump</b> input axes.</summary>
	[RequireComponent(typeof(Rigidbody2D))]
	[HelpURL(D2dHelper.HelpUrlPrefix + "D2dSpaceshipJumper")]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Spaceship Jumper")]
	public class D2dSpaceshipJumper : MonoBehaviour
	{
		[Tooltip("Minimum time between each jump in seconds.")]
		public float JumpDelay = 1.0f;

		[Tooltip("The jump distance in world space units.")]
		public float JumpDistance = 10.0f;

		[Tooltip("The turning force.")]
		public float TurnTorque = 10.0f;

		[Tooltip("The prefab that will be placed along the slice.")]
		public D2dSlicer SlicePrefab;

		[Tooltip("The main thrusters.")]
		public D2dThruster[] Thrusters;

		[System.NonSerialized]
		private Rigidbody2D cachedRigidbody2D;

		// Seconds until next shot is available
		private float cooldown;

		protected virtual void OnEnable()
		{
			if (cachedRigidbody2D == null) cachedRigidbody2D = GetComponent<Rigidbody2D>();
		}

		protected virtual void Update()
		{
			cooldown -= Time.deltaTime;

			// Does the player want to jump?
			if (Input.GetButtonDown("Jump") == true)
			{
				// Can we jump?
				if (cooldown <= 0.0f)
				{
					cooldown = JumpDelay;

					var oldPosition = transform.position;

					transform.Translate(0.0f, JumpDistance, 0.0f, Space.Self);

					var newPosition = transform.position;

					if (SlicePrefab != null)
					{
						var indicator = Instantiate(SlicePrefab);

						indicator.SetTransform(oldPosition, newPosition);
					}
				}
			}

			if (Thrusters != null)
			{
				for (var i = 0; i < Thrusters.Length; i++)
				{
					var thruster = Thrusters[i];

					if (thruster != null)
					{
						thruster.Throttle = Input.GetAxisRaw("Vertical");
					}
				}
			}

			cachedRigidbody2D.AddTorque(Input.GetAxisRaw("Horizontal") * -TurnTorque);
		}
	}
}

#if UNITY_EDITOR
namespace Destructible2D.Examples
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(D2dSpaceshipJumper))]
	public class D2dSpaceshipJumper_Editor : D2dEditor<D2dSpaceshipJumper>
	{
		protected override void OnInspector()
		{
			BeginError(Any(t => t.JumpDelay < 0.0f));
				Draw("JumpDelay");
			EndError();
			Draw("JumpDistance");
			Draw("TurnTorque");
			Draw("SlicePrefab");

			Separator();

			Draw("Thrusters");
		}
	}
}
#endif