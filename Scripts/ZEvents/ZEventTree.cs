using UnityEngine;
using System.Collections.Generic;

public class ZEventTree
{
	public delegate void EndFunc();
	EndFunc _endFunc;
	
	ZEventNode _root;

	public bool IsStarted
	{
		get
		{
			return _isStarted;
		}
	}
	bool _isStarted;

	public bool IsComplete
	{
		get
		{
			return _root.isComplete;
		}
	}

	Dictionary<ZEventNode, bool> _dictOfEventNodes;
	
	public ZEventTree(EndFunc func=null)
	{
		_root = new EmptyEventNode("root", false);
		_isStarted = false;
		_endFunc = func;
		_dictOfEventNodes = new Dictionary<ZEventNode, bool>();
	}
	
	public ZEventNode Root
	{
		get { return _root; }
	}

	public void Start()
	{
		_isStarted = true;	
	}
	
	public void Update()
	{
		if(_isStarted && !_root.isComplete)
		{
			_root.Update();
			if(_root.isComplete)
			{
				if(_endFunc!=null)
					_endFunc();
			}
		}
	}
	
	public void AddChildNode(ZEventNode parentNode, ZEventNode newNode)
	{
		if(_dictOfEventNodes.ContainsKey(newNode))
		{
			Debug.LogWarning("Can't add the same node as child twice to an event tree - " + newNode.Name);
			return;
		}

		parentNode.AddChild(newNode);
		_dictOfEventNodes.Add(newNode, true);
	}

	public void RemoveChildNode(ZEventNode parentNode, ZEventNode newNode)
	{
		if(!_dictOfEventNodes.ContainsKey(newNode))
		{
			Debug.LogWarning("Node doesn't exist in the event tree - " + newNode.Name);
			return;
		}
		
		parentNode.RemoveChild(newNode);
		_dictOfEventNodes.Remove(newNode);
	}
}