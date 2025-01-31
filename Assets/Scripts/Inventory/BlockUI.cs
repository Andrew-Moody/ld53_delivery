using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockUI : MonoBehaviour
{
	private ItemUI _parentItem;
	public ItemUI GetParentItem { get { return _parentItem; } }

	[SerializeField]
	private Image _damageIcon;

	public Transform _raycastDebug;


	[SerializeField]
	private Image _raycastTarget;

	[SerializeField]
	private Sprite _damageSprite;

	[SerializeField]
	private Sprite _potentialDamageSprite;

	private bool _isDamaged;
	public bool IsDamaged { get { return _isDamaged; } }

	public bool IsDamagePattern { get; set; }


	public void EnableRayCast(bool enable)
	{
		_raycastTarget.raycastTarget = enable;
	}


	public void SetDamaged(bool damaged)
	{
		_isDamaged = damaged;

		_damageIcon.enabled = damaged;

		if (damaged != _parentItem.IsDamaged)
		{
			_parentItem.CheckDamage();
		}
	}


	public void SetupAsItem()
	{
		_parentItem = GetComponentInParent<ItemUI>();

		SetDamaged(false);

		ShowRayCastBlock(false);

		_damageIcon.sprite = _damageSprite;

		IsDamagePattern = false;
	}


	public void SetupAsDamage()
	{
		ShowRayCastBlock(false);

		EnableRayCast(false);

		_damageIcon.sprite = _potentialDamageSprite;

		Color color = _damageIcon.color;
		color.a = 0.5f;
		_damageIcon.color = color;

		IsDamagePattern = true;
	}


	public void ShowRayCastBlock(bool show)
	{
		if (show)
		{
			_raycastTarget.color = Color.white;
		}
		else
		{
			_raycastTarget.color = Color.clear;
		}
	}
}
