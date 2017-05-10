using System.Collections;

public class Faction {
	public string name { get; set; }
	public ArrayList members {get; set; }
	public int influence { get; set; }

	/// <summary>
	///		Initializes a Faction with an ArrayList of members.
	/// </summary>
	/// <param name="n">Name of the faction.</param>
	/// <param name="mem">ArrayList of VIP members. First member is the leader.</param>
	/// <param name="inf">Value of influence from 1 to 100.</param>
	public Faction(string n, ArrayList mem, int inf) {
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
		members = new ArrayList();
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
}
