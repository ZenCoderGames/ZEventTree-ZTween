//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZCustomNodeManager
/// Purpose:  This is the only class that needs to be edited when creating new nodes apart from
/// 		  the new nodes class itself. (Edit function: CreateCustomNode)
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using UnityEngine;
using WyrmTale;
using ZEditor;

public static class ZCustomNodeManager {

	public enum CUSTOM_TYPE {
		NONE, SINGLE_CHILD, MULTI_CHILD, LEAF
	}

	public class CustomNodeType {
		public string buttonName;
		public CUSTOM_TYPE customNodeType;

		public CustomNodeType(string name, CUSTOM_TYPE type) {
			buttonName = name;
			customNodeType = type;
		}
	};

	public static List<CustomNodeType> GetCustomNodeTypes(ZNodeEditorSkin.ZNodeEditorSkinItem skinItem) {
		List<CustomNodeType> customNodeTypes = new List<CustomNodeType>();

		for(int i=0; i<skinItem.customNodes.Length; ++i) {
			customNodeTypes.Add(new CustomNodeType(skinItem.customNodes[i].inspectorName, skinItem.customNodes[i].customNodeType));
		}

		return customNodeTypes;
	}

	// Edit this function when creating new nodes
	public static ZNode CreateCustomNode(CUSTOM_TYPE customNodeType, ZNodeTree nodeTree, Rect nodeRect, JSON js) {
		ZNode node = null;

		if(customNodeType == CUSTOM_TYPE.SINGLE_CHILD)
			node = new ZCustomNodeSingleChild(nodeTree, nodeRect, customNodeType);
		else if(customNodeType == CUSTOM_TYPE.MULTI_CHILD)
			node = new ZCustomNodeMultiChild(nodeTree, nodeRect, customNodeType);
		else if(customNodeType == CUSTOM_TYPE.LEAF)
			node = new ZCustomNodeLeaf(nodeTree, nodeRect, customNodeType);
		
		return node;
	}
}
