
using UnityEngine;
using UnityEngine.UI;
namespace ET
{
	[ObjectSystem]
	public class Scroll_Item_ServerTesDestroySystem : DestroySystem<Scroll_Item_ServerTes> 
	{
		public override void Destroy( Scroll_Item_ServerTes self )
		{
			self.DestroyWidget();
		}
	}
}
