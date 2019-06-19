//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeEditorSkin
/// Purpose:  The class is used to define the view params for the inspector/nodes
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

namespace ZEditor {
	
	public class ZNodeEditorSkin:ScriptableObject {
		[System.Serializable]
		public class ZNodeEditorSkinItem {
			public bool isDefault;
			[Header("Editor")]
			public Texture x;
			public Texture plus;
			public Texture zoomIn;
			public Texture zoomOut;
			public Texture leftArrowInactive, leftArrowActive, rightArrowInactive, rightArrowActive;
			[Header("Nodes")]
			public Texture defaultNode;
			public Texture selectedNode, xButton;
			public float nodeWidth = 50;
			public float nodeHeight = 50;
			public float nodeImgSize = 0.75f;
			public float xIconSize = 15;
			public float rootPositionX = 300;
			public float rootPositionY = 150;
			[Header("Connectors")]
			public Texture defaultInConnector;
			public Texture selectedInConnector, filledInConnector;
			public Texture defaultOutConnector, selectedOutConnector, filledOutConnector;
			public float connectionCircleSize = 4;
			public float connectionCirclePickSize = 8;
			public float inConnectorSize = 10;
			public float outConnectorSize = 12;
			public float connectorHeightOffset = 5;
			[Header("Inspector")]
			public Texture searchIcon;
			[Header("Layout")]
			public bool isVerticalLayout = true;
			public float leftPanelWidth = 200;
			public float leftPanelHeight = 1000;
			public float mainPanelWidth = 2000;
			public float mainPanelHeight = 2000;
			public float tabHeight = 20;
			public float autoLayoutHeight = 120;
			public float autoLayoutWidth = 40;
			public bool autoLayoutAsDefault = false;
			[Header("Zoom")]
			public float minZoom = 0.35f;
			public float maxZoom = 1.0f;
			public float startZoom = 0.75f;
			[Header("Core Nodes")]
			public CoreNodeSkin[] coreNodes;
			[Header("Custom Nodes")]
			public CustomNodeSkin[] customNodes;

			public string GetCustomNodeInspectorName(ZCustomNodeManager.CUSTOM_TYPE customNodeType) {
				for(int i=0; i<customNodes.Length; ++i) {
					if(customNodes[i].customNodeType == customNodeType) {
						return customNodes[i].inspectorName;
					}
				}
				return "";
			}

			public Texture GetCustomNodeImage(ZCustomNodeManager.CUSTOM_TYPE customNodeType) {
				for(int i=0; i<customNodes.Length; ++i) {
					if(customNodes[i].customNodeType == customNodeType) {
						return customNodes[i].icon;
					}
				}
				return null;
			}

			public Texture GetCoreNodeImage(ZNode.CORE_TYPE coreType) {
				for(int i=0; i<coreNodes.Length; ++i) {
					if(coreNodes[i].coreType == coreType) {
						return coreNodes[i].icon;
					}
				}
				return null;
			}
		}

		[System.Serializable]
		public class CoreNodeSkin {
			public ZNode.CORE_TYPE coreType;
			public Texture icon;
		}

		[System.Serializable]
		public class CustomNodeSkin {
			public ZCustomNodeManager.CUSTOM_TYPE customNodeType;
			public string inspectorName;
			public Texture icon;
		}

		public ZNodeEditorSkinItem[] skins;

		public ZNodeEditorSkinItem GetDefaultSkinItem() {
			for(int i=0; i<skins.Length; ++i) {
				if(skins[i].isDefault) {
					return skins[i];
				}
			}

			return skins[0];
		}

		public event System.Action OnModified;

		void OnValidate() {
			if(OnModified!=null)
				OnModified();
		}
	}
}