//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeMultiChild
/// Purpose:  Multi Child nodes can have multiple children
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;

namespace ZEditor {

	public class ZNodeMultiChild:ZNode {

		public ZNodeMultiChild(ZNodeTree nodeTree, Rect wr, ZCustomNodeManager.CUSTOM_TYPE customType):base(CORE_TYPE.MULTI_CHILD, customType, nodeTree, wr) {
	    }
	}

}