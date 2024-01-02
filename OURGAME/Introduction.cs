using System;
using System.Threading;

namespace OURGAME
{

	public class Introduction
		{
		public static int Double_Input { get; set; }
	    public static string Input {get; set;}
		public static string retry {get; set;}
		
		public static void Introduction1()
		{	//"Why does everything feels familiar?"
			Encounter.Loading();
			Console.Clear();
			Thread.Sleep(1000);
			string a = "\"Why does everything feels familiar?\"";
			
			foreach(char i in a) {
				Console.Write(i);
				System.Threading.Thread.Sleep(50);
			}
			
			
			Thread.Sleep(3000);
			
			for(int i = (a.Length); i > 0; i--) {
				
				Console.Clear();
				Console.WriteLine(a.Substring(0, i));
				
				Thread.Sleep(25);
			}
			
			Console.Clear();
			Console.WriteLine("Welcome to the Tower Climber.");
			Thread.Sleep(2000);
			Console.WriteLine("May I know your name?");
			Console.Write(">> ");
			Name();
		}
		
		public static void Introduction2()
		{
			Console.WriteLine("Is this your name [{0}]?", Data.Name);
			Console.WriteLine("[Y]es or [N]o");
			Console.Write(">> ");
			string player_name = Console.ReadLine();
			Condition.playername(player_name);
		}
		
		public static void Name()
		{
			Data.Name = Console.ReadLine();
			
			if(Data.Name == "y" || Data.Name == "Y"){
				Data.Strength = 9999;
				Data.Endurance = 99;
				Data.Base_HP = Data.Endurance * 10;
				Data.MP = 999;
				Data.Base_MP = 999;
				Data.Magic = 99;
				Data.Agility = 999;
				Data.potions = 999;
				Condition.first_floor_rng();
			}
			
			
			if(Data.Name == " " || Data.Name == "") {
				Console.Clear();
				Console.WriteLine("Welcome to the Tower Climber.");
				Console.WriteLine("May I know your name?");
				Console.Write(">> ");
				Name();
			} else {
				Console.WriteLine("");
				Console.WriteLine("Well, is that so? Hm, well, you could have honestly picked a better name.\n");
				Thread.Sleep(1000);
				Introduction2();
			}
				
			
			
		}
		
		public static void Before_Start() {
			Console.WriteLine("Okay [{0}], it's time to allocate skill points into your stats.", Data.Name);
			Thread.Sleep(4000);
		}
		
		public static void IntroductionAgain()
		{
			Console.WriteLine("What's your name then?");
			Console.Write(">> ");
			Data.Name = Console.ReadLine();
			Console.WriteLine("");
			Thread.Sleep(1000);
			Introduction2();
		}
		
		public static void Start()
		{
			Console.WriteLine("The skill points are: ");
			Console.WriteLine("[Strength] for more damage."); //DMG
     		Console.WriteLine("[Endurance] for more health points."); //HP
      		Console.WriteLine("[Magic] for more mana points and magic damage."); //MP
      		Console.WriteLine("[MP] is a stat that you gain depending on your [Magic], the more points you put into magic, the more Mana Points you get");
      		Console.WriteLine("This allows you to cast magic at the cost of MP, without MP you can't cast a magic Ability");
      		Console.WriteLine("[Agility] for a better chance of striking first.\n"); //AGI
      		Console.WriteLine("NOW CHOOSE");
      		Data.Base_Points = 50;
      		Console.WriteLine("Minimum of (1) and Maximum of (20).");
      		Console.WriteLine("TIP: It would be better to distribute the stats fairly depending on what you have.");
      		
      		
      		Data.Strength_stat();
      		Data.Endurance_stat();
      		Data.Magic_stat();
      		Data.Agility_stat();
      		CurrentStats();
		}
		
		public static void Again()
		{
			Console.WriteLine("The skill points are: ");
			Console.WriteLine("[Strength] for more damage."); //DMG
     		Console.WriteLine("[Endurance] for more health points."); //HP
      		Console.WriteLine("[Magic] for more mana points and magic damage."); //MP
      		Console.WriteLine("[MP] is a stat that you gain depending on your [Magic], the more points you put into magic, the more Mana Points you get");
      		Console.WriteLine("This allows you to cast magic at the cost of MP, without MP you can't cast a magic Ability");
      		Console.WriteLine("[Agility] for a better chance of striking first."); //AGI
      		Console.WriteLine("NOW CHOOSE");
      		Console.WriteLine("Minimum of (1) and Maximum of (20).");
      		Console.WriteLine("TIP: It would be better to distribute the stats fairly depending on what you have.");
		}
		
		public static void CurrentStats()
		{
			Condition.basestats();
			Console.WriteLine("\nCURRENT STATS");
			Thread.Sleep(1000);
			Console.WriteLine("Strength    : " + Data.Strength);
			Thread.Sleep(1000);
			Console.WriteLine("Endurance   : " + Data.Endurance);
			Thread.Sleep(1000);
			Console.WriteLine("Magic       : " +  Data.Magic);
			Thread.Sleep(1000);
			Console.WriteLine("Mana Points : " +  Data.MP);
			Thread.Sleep(1000);
			Console.WriteLine("Agility     : " +  Data.Agility);
			Thread.Sleep(1000);
			CurrentStats1();
//			Condition.second_floor_rng();
		}
		
		public static void CurrentStats1()
		{
			
			Console.WriteLine("\nAre you happy with your stats, [{0}]?", Data.Name);
			Console.WriteLine("[Y]es or [N]o");
			Console.Write(">> ");
			string finishing = Console.ReadLine();	
			Condition.finished(finishing);
			do_tutorial();
		
		}
		
		public static void do_tutorial(){
			again:
			Console.WriteLine("Do you wanna read the tutorial on how to play the game or not?");
			Console.WriteLine("[Y]es or [N]o");
			Console.Write(">> ");
			string proceed = Console.ReadLine();
			if(proceed == "y" || proceed == "Y"){
				Console.Clear();
				tutorial();
			}else if(proceed == "n" || proceed == "N"){
				Console.Clear();
				Condition.first_floor_rng();
			}else{
				Console.Clear();
				goto again;
			}
		}
		
		public static void tutorial(){
			Console.WriteLine("The game is simple.");
			Console.WriteLine("You are in a tower and is tasked to return the beauty and prosperity of the land by killing the [Apophis], God of Darkness.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("It has three floors, the end having Apophis on it.");
			Console.WriteLine("You are to scale the tower and gather enough strength to kill him.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("The game ends if you either kill [Apophis] OR you die, but you can simply restart again.");
			Console.WriteLine("Now I'll explain how the battle system works.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("When encountering an enemy, the deciding factor on who attacks first is who has the higher [Agility].");
			Console.WriteLine("After the agility check comes the real fight.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("In a battle, you have four options, the first of which is to launch an attack.");
			Console.WriteLine("It's simple: after selecting the attack option, your character swings at the enemy.");
			Console.WriteLine("It's damage is based on the [Strength] you have.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("Second option is [Magic], which is more sophisticated than it sounds.");
			Console.WriteLine("All spells cost mana to cast, and mana can be replenished by defending or resting along the way.");
			Console.WriteLine("You then have three spells to select from. One of the basic spells you can cast is [Fireball].");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("[Fireball] is a simple spell that burns your enemy. It deals alot of damage but costs [Magic Points] to use.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("The second spell is [Ice Barrier].");
			Console.WriteLine("It cost alot of [Magic Points], but for one turn you are immune to any attacks, so use it wisely.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("And for the last magic and most important one is the [Heal Spell].");
			Console.WriteLine("It's really simple. It heals you by 40% at a HIGH COST of mana, so use it sparingly or only when you're out of potions.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("Third option is the [Heal] option.");
			Console.WriteLine("Using this option consumes one of your potions and heal your for 40% of your HP.");
			Console.WriteLine("Potions are rare so use it wisely and only in situations that call for it.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("And lastly is [Defend].");
			Console.WriteLine("This option is ideal for magic players because blocking the attack reduces the amount of damage taken and gives you some mana back.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("After defeating an enemy by depleting its HP, you obtain EXP or [Experience Points]");
			Console.WriteLine("This points are important because after reaching a certain EXP, you then level up, increasing your overall stats.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("After all that you are given three chances to choose two actions.");
			Console.WriteLine("You can either rest and have a chance to heal up and not risk getting damaged and/or killed by traps.");
			Console.WriteLine("OR risk yourself and venture on to find either treasures or traps.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			Console.WriteLine("After four enemy encounters, you will meet the floor's final enemy, which is the boss.");
			Console.WriteLine("Be careful as these enemies are formidable.");
			Console.WriteLine("");
			Thread.Sleep(3000);
			again:
			Console.WriteLine("That's all for the tutorial. Do you want to go through the instruction again, or do you want to begin your quest, [ " + Data.Name + "]?");
			Console.WriteLine("[Y]es or [N]o");
			string proceed = Console.ReadLine();
			if(proceed == "y" || proceed == "Y"){
				Console.Clear();
				tutorial();
			}else if(proceed == "n" || proceed == "N"){
				Console.Clear();
				Condition.first_floor_rng();
			}else{
				Console.Clear();
				goto again;
			}
			
		}

		
	}
}
	

