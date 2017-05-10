
public class VIP : Person {
	public int leadership { get; set; }
	public Faction faction { get; set; }

	/// <summary>
	///		Initializes a VIP.
	/// </summary>
	/// <param name="person">Base person</param>
	/// <param name="lead">Leadership capability from 1 to 100</param>
	/// <param name="fac">Faction of VIP</param>
	public VIP(Person person, int lead, ref Faction fac)
			: base(person.name, person.age, person.occupation, person.gender,
			person.ideology, person.awareness, person.happiness, person.indifference)	{
				
		leadership = lead;
		faction = fac;
	}

	///<summary>Kills the VIP (Missing implementation)</summary>
	public void kill() {
		faction.removeMember(this.name);
	}
}
