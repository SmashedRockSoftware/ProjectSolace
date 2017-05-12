public class Employee : Person {

	public int fitness { get; set; }
	public int intelligence { get; set; }
	public int efficiency { get; set; }
	public int minSalary {get; set; }
	public int salary { get; set; }

		/// <summary>
		///		Initializes an Employee.
		/// </summary>
		/// <param name="person">Base person</param>
		/// <param name="fit">Fitness of Employee from 1 to 100</param>
		/// <param name="intel">Intelligence of Employee from 1 to 100</param>
		/// <param name="eff">Efficiency of Employee from 1 to 100</param>
		/// <param name="minSal">Minimum salary employee will accept</param>
		/// <param name="sal">How much employee is currently being payed</param>
	public Employee(Person person, int fit, int intel, int eff, int minSal, int sal)
			: base(person.firstName, person.lastName, person.age, person.occupation, person.gender,
			person.ideology, person.awareness, person.happiness, person.indifference) {

		fitness = fit;
		intelligence = intel;
		efficiency = eff;
		minSalary = minSal;
		salary = sal;
	}
}
