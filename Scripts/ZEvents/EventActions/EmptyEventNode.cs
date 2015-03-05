using UnityEngine;

public class EmptyEventNode:ZEventNode
{	
	public EmptyEventNode(string name, bool nodeIsBlocking):base(name, nodeIsBlocking)
	{
		
	}
	
	override protected void startLocal()
	{
		endLocal();
	}
}