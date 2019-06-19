using UnityEngine;

public class ZTweenTest : MonoBehaviour {
    public EasingEquations.Ease easeType;

	void Start () {
        ZTweenVector3 zTween = new ZTweenVector3(transform.localScale, transform.localScale * 5, 1, easeType, 0, false);
        zTween.OnUpdateFunc = (Vector3 val) => {
            transform.localScale = val;
        };
		zTween.OnCompleteFunc = () => {
			Debug.Log("OnComplete scale tween");
		};

		ZTweenManager.Instance.AddTween(zTween);

		/*ZTweenVector3 zTween2 = new ZTweenVector3(transform.eulerAngles, transform.eulerAngles + Vector3.forward * 180, 1, easeType, 0, true);
		zTween2.OnUpdateFunc = (Vector3 val) => {
			transform.rotation = Quaternion.Euler(val);
		};
		zTween2.OnCompleteFunc = () => {
			Debug.Log("OnComplete rotate tween");
		};
		
		ZEventTree zEventTree = ZEventManager.Instance.CreateEventTree();
		ZTweenEventNode eventNodeScaleBlock = new ZTweenEventNode("scaleBlock", true, zTween);
		ZTweenEventNode eventNodeScale = new ZTweenEventNode("scale", false, zTween);
		WaitEventNode waitEventNode1 = new WaitEventNode("wait", true, 1);
		WaitEventNode waitEventNode3 = new WaitEventNode("wait", true, 3);
		ZTweenEventNode eventNodeRotateBlock = new ZTweenEventNode("rotateBlock", true, zTween2);
		ZTweenEventNode eventNodeRotate = new ZTweenEventNode("rotate", false, zTween2);
		
		zEventTree.AddChildNode(zEventTree.Root, eventNodeScaleBlock);
		zEventTree.AddChildNode(zEventTree.Root, waitEventNode1);
		zEventTree.AddChildNode(zEventTree.Root, eventNodeRotateBlock);
		zEventTree.AddChildNode(zEventTree.Root, waitEventNode3);
		zEventTree.AddChildNode(zEventTree.Root, eventNodeRotate);
		zEventTree.AddChildNode(zEventTree.Root, eventNodeScale);

		ZEventManager.Instance.StartEventTree(zEventTree);*/
	}
}