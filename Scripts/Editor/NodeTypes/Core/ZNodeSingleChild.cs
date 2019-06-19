//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeSingleChild
/// Purpose:  Single child nodes can only have a single child connection.
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;

namespace ZEditor {

	public class ZNodeSingleChild:ZNode {

		public ZNodeSingleChild(ZNodeTree nodeTree, Rect wr, ZCustomNodeManager.CUSTOM_TYPE customType):base(CORE_TYPE.LEAF, customType, nodeTree, wr) {
			
		}
	}
}