using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using System;


[RequireComponent(typeof(Collider))]
public class PaintMe : MonoBehaviour
{

	public Color ClearColour;
	public Material PaintShader;
	public RenderTexture PaintTarget;
	private RenderTexture TempRenderTarget;
	private Material ThisMaterial;
	public int value = 1;
	public float timer;

	public GameObject finishPanel;

	public ParticleSystem shotParticle;

	public TMP_Text ValueDisplay;

	[SerializeField] private LayerMask boxLayer;
	public bool isBox1BDone, isBox2BDone, isBox3BDone, isBox4BDone;
	private bool IsAllDone => isBox1BDone && isBox2BDone && isBox3BDone && isBox4BDone;
	void Init()
	{
		if (ThisMaterial == null)
			ThisMaterial = this.GetComponent<Renderer>().material;

		//	already setup
		if (PaintTarget != null)
			if (ThisMaterial.mainTexture == PaintTarget)
				return;

		//	copy texture
		if (ThisMaterial.mainTexture != null)
		{
			if (PaintTarget == null)
				PaintTarget = new RenderTexture(ThisMaterial.mainTexture.width, ThisMaterial.mainTexture.height, 0);
			Graphics.Blit(ThisMaterial.mainTexture, PaintTarget);
			ThisMaterial.mainTexture = PaintTarget;
		}
		else
		{
			if (PaintTarget == null)
				PaintTarget = new RenderTexture(1024, 1024, 0);

			//	clear if no existing texture
			Texture2D ClearTexture = new Texture2D(1, 1);
			ClearTexture.SetPixel(0, 0, ClearColour);
			Graphics.Blit(ClearTexture, PaintTarget);
			ThisMaterial.mainTexture = PaintTarget;

		}
	}

	// Update is called once per frame
	void Update()
	{

		RaycastHit hitInfo = new RaycastHit();

		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		// OnMouseDown
		if (Input.GetMouseButton(0))
		{
			if (Physics.Raycast(ray, out hitInfo))
			{
				hitInfo.collider.SendMessage("HandleClick", hitInfo, SendMessageOptions.DontRequireReceiver);
				//switch (hitInfo.collider.tag)
				//{
				//	case "box1": isBox1BDone = true; break;
				//	case "box2": isBox2BDone = true; break;
				//	case "box3": isBox3BDone = true; break;
				//	case "box4": isBox4BDone = true; break;
				//}
				//if (IsAllDone)
				//{
				//	Debug.Log("yEYe");
				//}
			}

		}

	}


	void HandleClick(RaycastHit Hit)
	{

		shotParticle.Play();

		timer += Time.deltaTime;
		if (timer > 0.05)
		{
			timer = 0;
			value++;

			if (value >= 100)
			{

				value = 100;

				StartCoroutine(panelOpen());
			}
		}
		Vector2 LocalHit2 = Hit.textureCoord;
		PaintAt(LocalHit2);
		Debug.Log(value);
		ValueDisplay.text = value + "%";
	}


	void PaintAt(Vector2 Uv)
	{
		Init();

		if (TempRenderTarget == null)
		{
			TempRenderTarget = new RenderTexture(PaintTarget.width, PaintTarget.height, 0);
		}
		PaintShader.SetVector("PaintUv", Uv);
		Graphics.Blit(PaintTarget, TempRenderTarget);
		Graphics.Blit(TempRenderTarget, PaintTarget, PaintShader);
	}
	IEnumerator panelOpen()
	{
		yield return new WaitForSeconds(0.5f);
		finishPanel.SetActive(true);
	}
}