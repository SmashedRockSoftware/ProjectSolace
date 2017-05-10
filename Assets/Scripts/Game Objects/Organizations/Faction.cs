using System.Collections.Generic;

public class Faction {
	public string name { get; set; }
	public List<VIP> members {get; set; }
	public int influence { get; set; }

	/// <summary>
	///		Initializes a Faction with an ArrayList of members.
	/// </summary>
	/// <param name="n">Name of the faction.</param>
	/// <param name="mem">ArrayList of VIP members. First member is the leader.</param>
	/// <param name="inf">Value of influence from 1 to 100.</param>
	public Faction(string n, List<VIP> mem, int inf) {
		name = n;
		members = mem;
		influence = inf;
	}

	/// <summary>
	///		Initializes a Faction with a single leader member.
	/// </summary>
	/// <param name="n">Name of the faction.</param>
	/// <param name="mem">Leader of the faction</param>
	/// <param name="inf">Value of influence from 1 to 100.</param>
	public Faction(string n, VIP leader, int inf) {
		name = n;
		members = new List<VIP>();
		members.Add(leader);
		influence = inf;
	}

	/// <summary>Returns the leader of the faction.</summary>
	public object GetLeader() {
		return members[0];
	}

	/// <summary>Adds a member to the faction.</summary>
	/// <param name="mem">Member to add.</param>
	public void AddMember(VIP mem) {
		members.Add(mem);
	}

	/// <summary>Removes a member from the faction.</summary>
	/// <param name="name">String name of member to remove.</param>
	public void removeMember(string name) {
		bool found = false;

		for(int i = 0; i < members.Count; i++) {
			if (name == members[i].name) {
				found = true;
				members.RemoveAt(i);
			}
		}

		if (!found) {
			System.Console.WriteLine("Tried to remove member, member not found");
		}
	}
}
