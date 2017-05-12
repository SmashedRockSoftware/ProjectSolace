public class Person {

	public string firstName { get; set; }
	public string lastName { get; set; }
	public int age { get; set; }
	public Occupation occupation { get; set; }
	public Gender gender { get; set; }
	public int ideology { get; set; }	//Value from 1 to 100, 1-50 is liberal, 51-100 is conservative
	public int awareness { get; set; } //Value from 1 to 100
	public int happiness { get; set; } //Value from 1 to 100
	public int indifference { get; set; } //Value from 1 to 100

	/// <summary>
	///		Initializes a Person.
	/// </summary>
	/// <param name="f">First name of person.</param>
	/// <param name="l">Last name of person.</param>
	/// <param name="a">Age of person.</param>
	/// <param name="occ">Occupation of person.</param>
	/// <param name="gen">Gender of person.</param>
	/// <param name="id">Ideology of person, from 1 to 100. Lower numbers are liberal, higher conservatiive.</param>
	/// <param name="aw">Awareness of person.</param>
	/// <param name="hap">Happiness of person.</param>
	/// <param name="ind">indifference of person.</param>
	public Person(string f, string l, int a, Occupation occ, Gender gen, int id, int aw, int hap, int ind) {
		firstName = f;
		lastName = l;
		age = a;
		occupation = occ;
		gender = gen;
		ideology = id;
		awareness = aw;
		happiness = hap;
		indifference = ind;
	}

	/// <summary>Returns full name (first name and last name).</summary>
	public string GetFullName() {
		return firstName + " " + lastName;
	}
}

public enum Occupation { hacker, mercenary, none }
public enum Gender { female, male, unknown }
