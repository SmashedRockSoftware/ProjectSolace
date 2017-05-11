
public class PersonBuilder {
	public string name { get; set; }
	public int age { get; set; }
	public Occupation occupation { get; set; }
	public Gender gender { get; set; }
	public int ideology { get; set; }	//Value from 1 to 100, 1-50 is liberal, 51-100 is conservative
	public int awareness { get; set; } //Value from 1 to 100
	public int happiness { get; set; } //Value from 1 to 100
	public int indifference { get; set; } //Value from 1 to 100

	/// <summary>Returns a built Person</summary>
	public Person GetResult() {
		return new Person(name, age, occupation, gender, ideology, awareness,
				happiness, indifference);
	}
}
