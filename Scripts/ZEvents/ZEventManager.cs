
/// Class:   ZEventManager.
/// Author:  Srinavin Nair
/// Purpose: Singleton class that handles all the event tree management so that the client doesn't have to.
/// Usage:   Just have an instance of the EventTreeManager in your scene.
/// 	     Then you can use: ZEventManager.Instance.CreateEventTree(); to create a new tree

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

	/// <summary>
	/// The list of event trees to be iterated upon
	/// </summary>
	List<ZEventTree> _eventTreeList;
	int _counter;
	ZEventTree _currentEventTree;
	
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		_instance = this;
		
		_eventTreeList = new List<ZEventTree>();
	}

	/// <summary>
	/// Iterate and update through each tree which has started
	/// If a tree is completed, remove from the list
	/// </summary>
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

	/// <summary>
	/// Creates a new event tree and returns it
	/// </summary>
	/// <returns>The event tree.</returns>
	public ZEventTree CreateEventTree(System.Action endFunc = null)
	{
		ZEventTree newEventTree = new ZEventTree(endFunc);
		_eventTreeList.Add(newEventTree);
		return newEventTree;
	}

	/// <summary>
	/// Starts an event tree passed as an argument.
	/// Note if this is not called, the tree updates
	 /// will not be called either
	/// </summary>
	/// <param name="evtTree">Evt tree.</param>
	public void StartEventTree(ZEventTree evtTree)
	{
		evtTree.Start();
	}

	/// <summary>
	/// Destroys an event tree passed as an argument
	/// </summary>
	/// <param name="evtTree">Evt tree.</param>
	public void DestroyEventTree(ZEventTree evtTree)
	{
		_eventTreeList.Remove(evtTree);
	}
}