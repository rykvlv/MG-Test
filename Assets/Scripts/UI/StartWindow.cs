using UnityEngine;
using UnityEngine.UI;

using  CookingPrototype.Controllers;

using TMPro;

namespace CookingPrototype.UI {
	public sealed class StartWindow : MonoBehaviour {
		public TMP_Text GoalText     = null;
		public Button   PlayButton = null;

		bool _isInit = false;

		void Init() {
			var gc = GameplayController.Instance;
			PlayButton.onClick.AddListener(gc.Restart);
		}

		public void Show() {
			if ( !_isInit ) {
				Init();
			}

			var gc = GameplayController.Instance;
			
			GoalText.text = $"{gc.OrdersTarget}";

			gameObject.SetActive(true);
		}

		public void Hide() {
			gameObject.SetActive(false);
		}
	}
}