//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeLeaf
/// Purpose:  Leaf nodes dont have children
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;

namespace ZEditor {

	public class ZNodeLeaf:ZNode {

		public ZNodeLeaf(ZNodeTree nodeTree, Rect wr, ZCustomNodeManager.CUSTOM_TYPE customType):base(CORE_TYPE.LEAF, customType, nodeTree, wr) {
	    }

	    protected override void CreateOutConnector() {}
	}

}