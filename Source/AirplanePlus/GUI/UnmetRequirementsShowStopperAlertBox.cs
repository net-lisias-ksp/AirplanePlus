/*
	This file is part of Airplane++ /L
		© 2022-2024 by:
			LisiasT : http://lisias.net <support@lisias.net>

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
using UnityEngine;
using KSPe.UI;

namespace AirplanePlus.GUI
{
	internal class UnmetRequirementsShowStopperAlertBox
	{
		private static readonly string MSG = @"Unfortunately Airplane+ is unable to proceed due unmet requirements!

You need to have {0} installed, otherwise this Add'On will not work as intended.";

		private static readonly string AMSG = @"download and install {0} and then restart KSP (it will close now)";

		internal static void Show(string failedRequirement)
		{
			KSPe.Common.Dialogs.ShowStopperAlertBox.Show(
				string.Format(MSG, failedRequirement),
				string.Format(AMSG, failedRequirement),
				() => { Application.Quit(); }
			);
			Log.detail("\"Houston, we have a Problem!\" about unmet dependencies {0} was displayed", failedRequirement);
		}
	}
}