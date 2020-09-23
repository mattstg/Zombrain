using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Destructible2D.Examples
{
	/// <summary>This component allows you to stamp all destructible sprites under the mouse.</summary>
	[HelpURL(D2dHelper.HelpUrlPrefix + "D2dClickToStamp")]
	[AddComponentMenu(D2dHelper.ComponentMenuPrefix + "Click To Stamp")]
	public class D2dClickToStamp : MonoBehaviour
	{
		public enum HitType
		{
			All,
			First
		}

		[Tooltip("The key you must hold down to perform stamping.")]
		public KeyCode Requires = KeyCode.Mouse0;

		[Tooltip("The Z position the stamp should spawn at. For normal 2D scenes this should be 0.")]
		public float Intercept;

		[Tooltip("The destructible sprite layers we want to stamp.")]
		public LayerMask Layers = -1;

		[Tooltip("The prefab used to show what the stamp will look like.")]
		public GameObject IndicatorPrefab;

		[Tooltip("This allows you to change the painting type.")]
		public D2dDestructible.PaintType Paint;

		[Tooltip("The shape of the stamp.")]
		public Texture2D Shape;

		[Tooltip("The stamp shape will be multiplied by this.\nSolid White = No Change")]
		public Color Color = Color.white;

		[Tooltip("The size of the stamp in world space.")]
		public Vector2 Size = Vector2.one;

		[Tooltip("The angle of the stamp in degrees.")]
		public float Angle;

		[Tooltip("How many destructibles should be hit?")]
		public HitType Hit;

		// Currently dragging?
		[SerializeField]
		private bool down;

		// Instance of the indicator
		[SerializeField]
		private GameObject indicatorInstance;

		// Initial scale
		[SerializeField]
		private Vector3 indicatorScale;

		protected virtual void Update()
		{
			// Main camera exists?
			var mainCamera = Camera.main;

			if (mainCamera != null)
			{
				// World position of the mouse
				var position = D2dHelper.ScreenToWorldPosition(Input.mousePosition, Intercept, mainCamera);

				// Begin dragging
				if (Input.GetKey(Requires) == true && down == false)
				{
					down = true;
				}

				// End dragging
				if (Input.GetKey(Requires) == false && down == true)
				{
					down = false;

					// Stamp everything at this point?
					if (Hit == HitType.All)
					{
						D2dStamp.All(Paint, position, Size, Angle, Shape, Color, Layers);
					}

					// Stamp the first thing at this point?
					if (Hit == HitType.First)
					{
						var destructible = default(D2dDestructible);

						if (D2dDestructible.TrySampleThrough(position, ref destructible) == true)
						{
							destructible.Paint(Paint, D2dStamp.CalculateMatrix(position, Size, Angle), Shape, Color);
						}
					}
				}

				// Update indicator?
				if (down == true && IndicatorPrefab != null)
				{
					if (indicatorInstance == null)
					{
						indicatorInstance = Instantiate(IndicatorPrefab);

						indicatorScale = indicatorInstance.transform.localScale;

						indicatorInstance.SetActive(true);
					}

					indicatorInstance.transform.position = position;

					indicatorInstance.transform.localScale = Vector3.Scale(indicatorScale, new Vector3(Size.x, Size.y, 1.0f));
				}
				// Destroy indicator?
				else if (indicatorInstance != null)
				{
					Destroy(indicatorInstance.gameObject);
				}
			}
		}
	}
}

#if UNITY_EDITOR
namespace Destructible2D.Examples
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(D2dClickToStamp))]
	public class D2dClickToStamp_Editor : D2dEditor<D2dClickToStamp>
	{
		protected override void OnInspector()
		{
			Draw("Requires");
			Draw("Intercept");
			BeginError(Any(t => t.Layers == 0));
				Draw("Layers");
			EndError();
			BeginError(Any(t => t.IndicatorPrefab == null));
				Draw("IndicatorPrefab");
			EndError();

			Separator();

			Draw("Paint");
			BeginError(Any(t => t.Shape == null));
				Draw("Shape");
			EndError();
			Draw("Color");
			BeginError(Any(t => t.Size.x == 0.0f || t.Size.y == 0.0f));
				Draw("Size");
			EndError();
			Draw("Angle");

			Separator();

			Draw("Hit");
		}
	}
}
#endif