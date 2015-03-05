using UnityEngine;
using System.Collections.Generic;

public class ZEventManager : MonoBehaviour {
	private static ZEventManager _instance;
	public static ZEventManager Instance
	{
		get {
			return _instance;
		}
	}

	List<ZEventTree> _eventTreeList;
	int _counter;
	ZEventTree _currentEventTree;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		_instance = this;
		
		_eventTreeList = new List<ZEventTree>();
	}

	void Update () {
		for(_counter=0; _counter<_eventTreeList.Count; ++_counter)
		{
			_currentEventTree = _eventTreeList[_counter];
			if(_currentEventTree.IsStarted)
			{
				_currentEventTree.Update();

				if(_currentEventTree.IsComplete)
				{
					DestroyEventTree(_currentEventTree);
				}
			}
		}
	}

	public ZEventTree CreateEventTree()
	{
		ZEventTree newEventTree = new ZEventTree();
		_eventTreeList.Add(newEventTree);
		return newEventTree;
	}

	public void StartEventTree(ZEventTree evtTree)
	{
		evtTree.Start();
	}

	public void DestroyEventTree(ZEventTree evtTree)
	{
		_eventTreeList.Remove(evtTree);
	}
}