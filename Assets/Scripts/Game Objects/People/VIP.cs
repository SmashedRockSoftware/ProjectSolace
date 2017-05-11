
public class VIP : Person {
	public int leadership { get; set; }
	public Faction faction;

	/// <summary>
	///		Initializes a VIP.
	/// </summary>
	/// <param name="person">Base person</param>
	/// <param name="lead">Leadership capability from 1 to 100</param>
	/// <param name="fac">Reference Faction of VIP</param>
	public VIP(Person person, int lead, ref Faction fac)
			: base(person.name, person.age, person.occupation, person.gender,
			person.ideology, person.awareness, person.happiness, person.indifference)	{

		leadership = lead;
		faction = fac;
		VIP test = this;
		faction.AddMember(ref test);
	}

	/// <summary>Kills the VIP (Missing implementation)</summary>
	public void kill() {
		faction.removeMember(this);
	}

	/// <summary>Returns the faction this VIP is in.</summary>
	public Faction getFaction() {
		return faction;
	}

	/// <summary>Changes the faction this VIP is in.</summary>
	/// <param name="fac">New reference to Faction</param>
	public void changeFaction(ref Faction fac) {
		faction.removeMember(this);
		faction = fac;
		VIP test = this;
		faction.AddMember(ref test);
	}
}
