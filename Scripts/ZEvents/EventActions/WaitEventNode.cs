using System;
using UnityEngine;

public class WaitEventNode:ZEventNode
{
	private float _timeToWait;
	private float _startTime;
	
	public WaitEventNode(string name, bool nodeIsBlocking, float waitTime):base(name, nodeIsBlocking)
	{
		_timeToWait = waitTime;
	}
	
	override protected void startLocal()
	{
		_startTime = Time.time;
	}
	
	override protected void updateLocal()
	{
		if(Time.time - _startTime >= _timeToWait)
		{
			endLocal();	
		}
	}
}