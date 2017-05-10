using System.Collections.Generic;

public class Faction {
	public string name { get; set; }
	public List<VIP> members;
	public int influence { get; set; }

	/// <summary>
	///		Initializes a Faction without any members.
	/// </summary>
	/// <param name="n">Name of the faction.</param>
	/// <param name="inf">Value of influence from 1 to 100.</param>
	public Faction(string n, int inf) {
		name = n;
		influence = inf;
		members = new List<VIP>();
	}

	/// <summary>
	///		Initializes a Faction with a single leader member.
	/// </summary>
	/// <param name="n">Name of the faction.</param>
	/// <param name="mem">Leader of the faction</param>
	/// <param name="inf">Value of influence from 1 to 100.</param>
	public Faction(string n, ref VIP leader, int inf) {
		name = n;
		members = new List<VIP>();
		members.Add(leader);
		influence = inf;
	}

	/// <summary>Returns the leader of the faction.</summary>
	public VIP GetLeader() {
		return members[0];
	}

	/// <summary>Adds a member to the faction.</summary>
	/// <param name="mem">Member to add.</param>
	public void AddMember(ref VIP mem) {
		members.Add(mem);
	}

	/// <summary>Removes a member from the faction.</summary>
	/// <param name="name">String name of member to remove.</param>
	public void removeMember(VIP vip) {
			members.Remove(vip);
	}

	/// <summary>Sets the leader of the faction (Inserts VIP into member List at 0).</summary>
	/// <param name="vip">VIP to be made leader.</summary>
	public void setLeader(ref VIP vip) {
		if (vip.faction.name == this.name)
			members.Remove(vip);

		members.Insert(0, vip);
	}
}
