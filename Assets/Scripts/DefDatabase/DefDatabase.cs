using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefDatabase <T> where T : Def
{
	public static IEnumerable<T> AllDefs
	{
		get
		{
			return DefDatabase<T>.defsList;
		}
	}

	public static void Add(T def)
	{
        if (DefDatabase<T>.defsList.Find(x => x.defName == def.defName) != null)
        {
			Debug.Log(string.Concat(new object[]
				{
					"Failed to find ",
					typeof(T),
					" named ",
					def.defName
				}));
			return;
        }

		DefDatabase<T>.defsList.Add(def);
	}

	private static List<T> defsList = new List<T>();


}
