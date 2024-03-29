using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Destructible2D.Examples
{
	/// <summary>This component turns the current Rigidbody2D into a car that can be controlled with the <b>Horizontal</b> and <b>Vertical</b> input axes.</summary>
	[RequireComponent(typeof(Rigidbody2D))]
	[HelpURL(D2dHelper.HelpUrlPrefix + "D2dPlayerCar")]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Player Car")]
	public class D2dPlayerCar : MonoBehaviour
	{
		[Tooltip("The wheels used to steer this car")]
		public D2dWheel[] SteerWheels;

		[Tooltip("The maximum +- angle of turning")]
		public float SteerAngleMax = 20.0f;

		[Tooltip("How quickly the steering wheels turn to their target angle")]
		public float SteerAngleDampening = 5.0f;

		[Tooltip("The wheels used to move this car")]
		public D2dWheel[] DriveWheels;

		[Tooltip("The maximum torque that can be applied to each drive wheel")]
		public float DriveTorque = 1.0f;

		// Current steering angle
		[SerializeField]
		private float currentAngle;

		protected virtual void Update()
		{
			var targetAngle = Input.GetAxisRaw("Horizontal") * SteerAngleMax;
			var factor      = D2dHelper.DampenFactor(SteerAngleDampening, Time.deltaTime);

			currentAngle = Mathf.Lerp(currentAngle, targetAngle, factor);

			for (var i = 0; i < SteerWheels.Length; i++)
			{
				SteerWheels[i].transform.localRotation = Quaternion.Euler(0.0f, 0.0f, -currentAngle);
			}
		}

		protected virtual void FixedUpdate()
		{
			for (var i = 0; i < DriveWheels.Length; i++)
			{
				DriveWheels[i].AddTorque(Input.GetAxisRaw("Vertical") * DriveTorque * Time.fixedDeltaTime);
			}
		}
	}
}

#if UNITY_EDITOR
namespace Destructible2D.Examples
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(D2dPlayerCar))]
	public class D2dPlayerCar_Editor : D2dEditor<D2dPlayerCar>
	{
		protected override void OnInspector()
		{
			Draw("SteerWheels");
			Draw("SteerAngleMax");
			Draw("SteerAngleDampening");

			Separator();

			Draw("DriveWheels");
			Draw("DriveTorque");
		}
	}
}
#endif