using System;
using System.Collections.Generic;

public class ZEventNode
{
	List<ZEventNode> _children;
	
	protected bool _isBlocking;
	public bool isComplete;
	
	protected bool _isLocalStarted;
	protected bool _isLocalComplete;
	
	protected string _name;
	public string Name
	{
		get {
			return _name;
		}
	}
	
	public static bool DEBUG = false;

	/// <summary>
	/// Constructor
	/// </summary>
	public ZEventNode(string name, bool nodeIsBlocking)
	{
		_name = name;
		_isBlocking = nodeIsBlocking;
		_children = new List<ZEventNode>();
		isComplete = false;
		_isLocalStarted = false;
		_isLocalComplete = false;
	}
	
	public void AddChild(ZEventNode eventNode)
	{
		_children.Add(eventNode);
	}

	public void RemoveChild(ZEventNode eventNode)
	{
		_children.Remove(eventNode);
	}
	
	public void Update()
	{
		if(!isComplete)
		{
			if(!_isLocalStarted)
			{
				startLocal();
				_isLocalStarted = true;
			}
			
			if(!_isLocalComplete) updateLocal();
			
			isComplete = true;
			
			// Foreach for a list is the same as iterating from 0, n-1
			foreach(ZEventNode childNode in _children)
			{
				childNode.Update();
				isComplete &= childNode.isComplete;
				
				if(childNode._isBlocking && !childNode.isComplete)
				{
					break;
				}				
			}
			
			isComplete &= _isLocalComplete;
		}
	}
	
	virtual protected void startLocal()
	{

	}
	
	virtual protected void updateLocal()
	{
		// to be overriden
	}
	
	protected void endLocal()
	{
		_isLocalComplete = true;
	}
}

