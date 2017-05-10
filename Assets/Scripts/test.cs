using UnityEngine;

public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Faction crazies = new Faction("Crazy", 100);
		Faction commies = new Faction("Communists", 0);
		Person person = new Person("Alex Jones", 50, Occupation.mercenary, Gender.male, 0, 100, 50, 0);
		VIP AlexJones = new VIP(person, 60, ref crazies);
		crazies.AddMember(ref AlexJones);

		VIP test1 = crazies.GetLeader();
		Debug.Log(AlexJones.name);
		AlexJones.name = "Not Alex Jones";
		Debug.Log(AlexJones.name);
		VIP test = crazies.GetLeader();
		Debug.Log(test.name);
	}

	// Update is called once per frame
	void Update () {

	}
}
