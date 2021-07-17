using System;

using UnityEngine;

using JetBrains.Annotations;
using UnityEngine.UI;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {
		[SerializeField] private GameObject trash;

		FoodPlace _place = null;
		float     _timer = 0f;
		float	  _timeDelay = 0.5f;
		float     _lastTimeUsed = 0f;

		const string TRASH_CLOSED_IMAGE_PATH = "Images/BurgerArt/trash_close";
		const string TRASH_OPEN_IMAGE_PATH = "Images/BurgerArt/trash_open";

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if (_place.CurFood == null) {
				return;
			}
			_timer = Time.realtimeSinceStartup;
			bool doubleTapDetected = (_timer - _lastTimeUsed) <= _timeDelay;
			if (_place.CurFood.CurStatus == Food.FoodStatus.Overcooked && doubleTapDetected) {
				_place.FreePlace();
				OpenTrash();
				Invoke("CloseTrash", 1);
			}
			_lastTimeUsed = _timer;
		}

		public void OpenTrash() {
			if (trash == null)
			{
				Debug.Log("Trash game object not found!");
				return;
			}
			trash.GetComponent<Image>().sprite = Resources.Load<Sprite>(TRASH_OPEN_IMAGE_PATH);
		}

		public void CloseTrash() {
			if ( trash == null ) {
				Debug.Log("Trash game object not found!");
				return;
			}
			trash.GetComponent<Image>().sprite = Resources.Load<Sprite>(TRASH_CLOSED_IMAGE_PATH);
		}
	}
}
