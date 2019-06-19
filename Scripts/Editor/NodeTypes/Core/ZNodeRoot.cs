//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeRoot
/// Purpose:  Root nodes are the starting point of every tree
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;

namespace ZEditor {

	public class ZNodeRoot:ZNode {
	    
		public ZNodeRoot(ZNodeTree nodeTree, Rect wr, ZCustomNodeManager.CUSTOM_TYPE customType):base(CORE_TYPE.ROOT, customType, nodeTree, wr) {
		}

	    protected override void CreateInConnector() {
	    }
	}

}