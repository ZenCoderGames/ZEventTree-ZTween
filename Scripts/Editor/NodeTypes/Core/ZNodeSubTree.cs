//////////////////////////////////////////////////////////////////////////////////////////////////
/// Class: 	  ZNodeSubTree
/// Purpose:  Subtree nodes are just links to a different tree
/// Author:   Srinavin Nair
//////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
using UnityEditor;
using WyrmTale;

namespace ZEditor {

	public class ZNodeSubTree:ZNode {
		public string treePath;

		public ZNodeSubTree(ZNodeTree nodeTree, Rect wr, ZCustomNodeManager.CUSTOM_TYPE customType, JSON js):base(CORE_TYPE.SUB_TREE, customType, nodeTree, wr) {
			treePath = "";

			if(js!=null && js.Contains("params")) {
				JSON paramsJS = js.ToJSON("params");
				treePath = paramsJS.ToString("treePath");
			}
		}

		protected override void CreateOutConnector() {}

		override public void Serialize(ref JSON nodeJS) {
			base.Serialize(ref nodeJS);

			JSON paramsJS = new JSON();
			paramsJS["treePath"] = treePath;
			nodeJS["params"] = paramsJS;
		}

		override public void DrawInInspector(GUIStyle guiStyle) {
			base.DrawInInspector(guiStyle);

			GUILayout.BeginHorizontal("");
			GUILayout.TextArea("Tree Path:", guiStyle);
			treePath = GUILayout.TextField(treePath, EditorStyles.textField);
			GUILayout.EndHorizontal();

			if(GUILayout.Button("Show Subtree")) {
				NodeEditor.GoToOrCreateTree(treePath);
			}
		}
	}

}