/*
	This file is part of Airplane++ /L
		© 2022-2026 LisiasT : http://lisias.net <support@lisias.net>

	The Source Code for Airplane++ is double licensed, as follows:
		* SKL 1.0 : https://ksp.lisias.net/SKL-1_0.txt
		* GPL 2.0 : https://www.gnu.org/licenses/gpl-2.0.txt

	And you are allowed to choose the License that better suit your needs.

	Airplane++ /L is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.

	You should have received a copy of the SKL Standard License 1.0
	along with Airplane++ /L. If not, see <https://ksp.lisias.net/SKL-1_0.txt>.

	You should have received a copy of the GNU General Public License 2.0
	along with Airplane++ /L. If not, see <https://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;

using UnityEngine;

namespace AirplanePlus.PartModules
{
	public class APanimateGenericEchokinesis:PartModule
	{
		[KSPField]
		public string targetModuleID = "";

		[KSPField]
		public string animationName = "";

		[KSPField]
		public int layer = 0;

		private bool shouldBeEnabled = false;
		private ModuleAnimateGeneric targetModule;
		private AnimationState masterAnimationState;
		private List<AnimationState> animationStates = new List<AnimationState>();

		public override void OnStart(StartState state)
		{
			base.OnStart(state);

			if (string.IsNullOrEmpty(this.animationName))
			{
				this.shouldBeEnabled = this.enabled = false;
				Log.warn("No animation configured. Deactivating.");
				return;
			}

			{
				int count = part.Modules.Count;
				for (int i = 0; i < count; ++i)
				{
					PartModule pm = part.Modules[i];
					if (pm is ModuleAnimateGeneric target && target.animationName == animationName)
					{
						if (! (string.IsNullOrEmpty(this.targetModuleID) || this.targetModuleID.Equals(target.moduleID)) ) 
							continue;

						this.targetModule = target;
						if (0 == this.layer)
							this.layer = 1 + this.targetModule.layer;
						break;
					}
				}
			}

			if (null == this.targetModule)
			{
				this.shouldBeEnabled = this.enabled = false;
				Log.warn("No ModuleAnimateGeneric found on this part. Deactivating.");
				return;
			}

			if (null == this.targetModule.GetAnimation())
			{
				this.shouldBeEnabled = this.enabled = false;
				Log.warn("The target ModuleAnimateGeneric has no animations at all! Deactivating.");
				return;
			}

			this.masterAnimationState = this.targetModule.GetAnimation()[this.animationName];
			if (null == this.masterAnimationState)
			{
				this.shouldBeEnabled = this.enabled = false;
				Log.warn("The target ModuleAnimateGeneric has not an animation called {0}. Deactivating.", this.animationName);
				return;
			}

			{
				List<Animation> animations = part.FindModelComponents<Animation>();
				int count = animations.Count;
				for (int i = 0; i < count; ++i)
				{
					Animation animation = animations[i];
					AnimationState animationState = animation[this.animationName];
					if (null != animationState && this.masterAnimationState != animationState)
					{ 
						if (null == animationState) continue;
						if (this.masterAnimationState == animationState) continue;

						animationState.layer = this.layer;
						animationState.enabled = true;
						animationState.weight = 1f;
						this.animationStates.Add(animationState);
					}
				}
			}

			this.shouldBeEnabled = this.enabled = (null != this.targetModule) && this.targetModule.enabled && (null != this.masterAnimationState) && (this.animationStates.Count > 0);
			Log.dbg("Enabled? {0} ; Count: {1}", this.enabled, this.animationStates.Count);
		}

		public void Update()
		{
			if (this.enabled != this.shouldBeEnabled) // Prevents some idiots from enabling me when I should not be!
			{ 
				this.enabled = this.shouldBeEnabled;
				return;
			}
			{ 
				int count = this.animationStates.Count;
				for (int i = 0; i < count; ++i)
				{
					AnimationState animationState = this.animationStates[i];
					animationState.normalizedTime = this.masterAnimationState.normalizedTime;
					animationState.speed = this.masterAnimationState.speed;
					animationState.weight = 1f;
					animationState.enabled = true;
				}
			}
		}
	}
}
