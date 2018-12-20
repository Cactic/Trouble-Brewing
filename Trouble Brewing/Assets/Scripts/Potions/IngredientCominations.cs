using System.Collections.Generic;

public partial class PotionHasher {
	private static Dictionary<int,PotionPreset> _ingredientCombinations = new Dictionary<int,PotionPreset>(){
		{ 66051, new PotionPreset("PotionofLesserHealth",2,0,0,0,0,0,0)},
		{ 460809, new PotionPreset("PotionofLesserToughness",0,0,0,1,0,0,0)},
		{ 461315, new PotionPreset("PotionofGreaterPain",-6,0,0,0,0,0,0)},
		{ 66819, new PotionPreset("PotionofLesserHaste",0,4,0,0,0,0,0)},
		{ 66822, new PotionPreset("PotionofLesserStrength",0,0,2,0,0,0,0)},
		{ 66054, new PotionPreset("PotionofLesserAttackSpeed",0,0,0,0,0,-2,0)},
		{ 460041, new PotionPreset("PotionofLesserPiercing",0,0,0,0,1,0,0)},
		{ 67593, new PotionPreset("PotionofLesserPain",-2,0,0,0,0,0,0)},
		{ 67595, new PotionPreset("PotionofLesserWeakness",0,0,-2,0,0,0,0)},
		{ 66057, new PotionPreset("PotionofLesserSlowness",0,-4,0,0,0,0,0)},
		{ 67590, new PotionPreset("PotionofLesserSloth",0,0,0,0,0,-2,0)},
		{ 460035, new PotionPreset("PotionofLesserFrailty",0,0,0,-1,0,0,0)},
		{ 262665, new PotionPreset("PotionofHealth",5,0,0,0,0,0,0)},
		{ 262659, new PotionPreset("PotionofStrength",0,0,4,0,0,0,0)},
		{ 460803, new PotionPreset("PotionofHaste",0,8,0,0,0,0,0)},
		{ 460806, new PotionPreset("PotionofToughness",0,0,0,2,0,0,0)},
		{ 263430, new PotionPreset("PotionofPiercing",0,0,0,0,2,0,0)},
		{ 66825, new PotionPreset("PotionofToughness",0,0,0,2,0,0,0)},
		{ 459270, new PotionPreset("PotionofPain",-5,0,0,0,0,0,0)},
		{ 459268, new PotionPreset("PotionofWeakness",0,0,-4,0,0,0,0)},
		{ 459273, new PotionPreset("PotionofSlowness",0,-8,0,0,0,0,0)},
		{ 264201, new PotionPreset("PotionofSloth",0,0,0,0,0,-3,0)},
		{ 66827, new PotionPreset("PotionofFrailty",0,0,0,-2,0,0,0)},
		{ 264715, new PotionPreset("PotionofGreaterHealth",8,0,0,0,0,0,0)},
		{ 263427, new PotionPreset("PotionofGreaterStrength",0,0,6,0,0,0,0)},
		{ 461323, new PotionPreset("PotionofGreaterHaste",0,10,0,0,0,0,0)},
		{ 461321, new PotionPreset("PotionofGreaterAttackSpeed",0,0,0,0,0,5,0)},
		{ 67587, new PotionPreset("PotionofGreaterToughness",0,0,0,3,0,0,0)},
		{ 263433, new PotionPreset("PotionofGreaterPiercing",0,0,0,0,3,0,0)},
		{ 461318, new PotionPreset("PotionofGreaterWeakness",0,0,-6,0,0,0,0)},
		{ 460811, new PotionPreset("PotionofGreaterSlowness",0,-10,0,0,0,0,0)},
		{ 263435, new PotionPreset("PotionofGreaterSloth",0,0,0,0,0,-5,0)},
		{ 66059, new PotionPreset("PotionofGreaterFrailty",0,0,0,-3,0,0,0)},
		{ 459267, new PotionPreset("PotionofWeakness",0,0,-4,0,0,0,0)}
	};
}
