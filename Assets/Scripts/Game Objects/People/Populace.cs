public class Populace {
	public int awareness { get; set; }
	public int happiness { get; set; }

	///<summary>Initializes a populace</summary>
	/// <param name="aw">Awareness of the populace</param>
	/// <param name="hap">Happiness of the populace</param>
	public Populace(int aw, int hap) {
		awareness = aw;
		happiness = hap;
	}
}
