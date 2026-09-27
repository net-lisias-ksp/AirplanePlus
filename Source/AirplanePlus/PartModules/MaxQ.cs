/*
	This file is part of Airplane+ /L
		© 2022-2026 LisiasT : http://lisias.net <support@lisias.net>

	The Source Code for Airplane+ is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Airplane+ /L is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Airplane+ /L. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Airplane+ /L. If not, see <https://www.gnu.org/licenses/>.
*/
using System;

using UnityEngine;

namespace AirplanePlus.PartModules
{
	public class MaxQ:PartModule
	{
		[KSPField]
		public double MaxQ_kPA = 0;

		private readonly Color ALERT_COLOR = new Color(0.5f, 0.75f, 0, 0.75f);
		private bool shouldBeEnabled = false;
		private bool blinkIt = false;

		private delegate void UpdateBlinkDelegate();
		private UpdateBlinkDelegate UpdateBlink;

		public override void OnStart(StartState state)
		{
			base.OnStart(state);

			if (this.MaxQ_kPA <= 0)
			{
				this.shouldBeEnabled = this.enabled = false;
				Log.warn("MaxQ is not configured. Deactivating.");
				return;
			}

			this.UpdateBlink = this.UpdateBlinkNone;
			this.shouldBeEnabled = this.enabled = true;
			Log.dbg("Enabled? {0} ; MaxQ_kPA: {1}", this.enabled, this.MaxQ_kPA);
		}

		public void Update()
		{
			if (this.enabled != this.shouldBeEnabled) // Prevents some idiots from enabling me when I should not be!
			{ 
				this.enabled = this.shouldBeEnabled;
				return;
			}
			this.UpdateBlink();
		}

		private void UpdateBlinkNone()
		{
			bool blinkIt = (this.part.dynamicPressurekPa > (this.MaxQ_kPA * 0.8));
			if (blinkIt != this.blinkIt)
			{
				this.blinkIt = blinkIt;
				if (blinkIt)
					this.UpdateBlink = this.UpdateBlinkOn;
				else
					this.UpdateBlink = this.UpdateBlinkOff;
			}
		}

		private void UpdateBlinkOn()
		{
			Log.dbg("UpdateBlinkOn");
			this.part.SetHighlightColor(ALERT_COLOR);
			this.part.SetHighlight(true, false); 
			this.part.SetHighlightType(Part.HighlightType.AlwaysOn);
			this.UpdateBlink = this.UpdateBlinkNone;
		}

		private void UpdateBlinkOff()
		{
			Log.dbg("UpdateBlinkOff");
			this.part.SetHighlightDefault();
			this.UpdateBlink = this.UpdateBlinkNone;
		}

		public void FixedUpdate()
		{
			if (!this.shouldBeEnabled) return;

			if (this.part.dynamicPressurekPa > this.MaxQ_kPA)
				this.part.explode();
		}
	}
}
