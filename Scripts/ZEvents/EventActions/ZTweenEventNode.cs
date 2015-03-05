using UnityEngine;

public class ZTweenEventNode:ZEventNode
{
	private ZTweenBase _zTween;
	
	public ZTweenEventNode(string name, bool nodeIsBlocking, ZTweenBase tween):base(name, nodeIsBlocking)
	{
		_zTween = tween;
	}
	
	override protected void startLocal()
	{
		_zTween.Start();
	}
	
	override protected void updateLocal()
	{
		if(_zTween.HasEnded)
		{
			endLocal();	
		}
	}
}