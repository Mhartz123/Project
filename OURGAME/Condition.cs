using System;
using System.Threading;

namespace OURGAME
{
	/// <summary>
	/// Description of Condition.
	/// </summary>
	public class Condition
	{
		public static void playername(string a)
		{
			if(a == "y" || a == "Y"){
				Console.WriteLine("");
				Introduction.Before_Start();
				Console.Clear();
				Introduction.Start();
			} else if(a == "n" || a == "N"){
				Console.Clear();
				Introduction.IntroductionAgain();
				Thread.Sleep(3000);
				Console.Clear();
				Introduction.Start();
			} else {
				Console.Clear();
				Console.WriteLine("Welcome weary traveller to the unknown lands");
				Console.WriteLine("May I know your name?");
				Console.Write(">> {0}", Data.Name);
				Console.WriteLine("");
				Console.WriteLine("\nWell, is that so? Hm, well, you could have honestly picked a better name.\n");
				Introduction.Introduction2();
			}
			
		}
		
		public static void basestats(){
			if(Data.Base_Points > 0){
				Console.WriteLine("\n[You need to allocate all stat points]");
				Thread.Sleep(3000);
				Console.Clear();
				Introduction.Start();
			}
		}
		
		public static void finished(string a)
		{
			if(a == "y" || a == "Y"){
				Console.WriteLine("\nTake this potions with you, I hope they serve you nicely in your journey.");
				Data.potions += 5;
				Encounter.Loading();
				Console.Clear();
			}else if(a == "n" || a == "N"){
				Console.Clear();
				Introduction.Start();
			} else {
				Introduction.CurrentStats1();
			}
			
		}
		
		public static void tutorial_finishing(string a)
		{
			if(a == "n" || a == "N"){
				Console.WriteLine("\nTake this potions with you, I hope they serve you nicely in your journey.");
				Data.potions += 5;
				Encounter.Loading();
				Console.Clear();
			}else if(a == "y" || a == "Y"){
				
				Console.Clear();
			} else {
				Introduction.CurrentStats1();
			}
			
		}
		
		
		private static void first_floor_enemies(){

			Random rnd = new Random();
			int RNG = rnd.Next(1,5);
			
			if(RNG == 1){
				Enemy.goblin();
				Encounter.agility_check();
			}else if(RNG == 2){
				Enemy.Kobold();
				Encounter.agility_check();
			}else if(RNG == 3){
				Enemy.Shaman();
				Encounter.agility_check();
			}else if(RNG == 4){
				Enemy.Orc();
				Encounter.agility_check();
			}
		}
		
		private static void second_floor_enemies(){

			Random rnd = new Random();
			int RNG = rnd.Next(1,5);
			
			if(RNG == 1){
				Enemy.Swarm_of_Rats();
				Encounter.agility_check();
			}else if(RNG == 2){
				Enemy.Pack_of_Wolves();
				Encounter.agility_check();
			}else if(RNG == 3){
				Enemy.Rabid_Wolf();
				Encounter.agility_check();
			}else if(RNG == 4){
				Enemy.Werewolf();
				Encounter.agility_check();
			}
		}
		
		
		
		
//		public static void retrying(){
//			if(UserInput.retry == "Y" || UserInput.retry == "y"){
//				Introduction.Introduction1();
//			}else{
//				Console.WriteLine("You died");
//				Console.WriteLine("Press any key to exit the console");
//				Console.ReadKey();
//
//			}
//		}
		
		public static void first_floor_rng(){
			
			
			Encounter.Floor("1ST");
			Encounter.Loading();
			Console.Clear();
			
			
			
			
			string playerInput = "";
			while(!(playerInput == "e" || playerInput == "E")) {
				Encounter.Floor("1ST");
				string a = "\"The first step is always the hardest, but you must endure if\nyou want to return the world back to its former glory.\"";
				foreach(char i in a) {
					Console.Write(i);
					System.Threading.Thread.Sleep(50);
				}
				Thread.Sleep(1000);
				Console.WriteLine("\n\n[E]nter");
				Console.Write(">> ");
				playerInput = Console.ReadLine();
			}
			
//			if(Data.Name == "y" || Data.Name == "Y"){
//				final_boss();
//			}
			
			int base_exp = 102;
			Data.Max_Exp = base_exp;
			
			for(int i = 1; i <= 5; i++)
			{
				if(i < 5) {
					Console.Clear();
					Encounter.Floor("1ST");
					Encounter.Loading();
					Console.Clear();
					Encounter.Floor("1ST");
					Console.WriteLine("An enemy has appeared before you.");
					Encounter.Loading();
					Console.Clear();
					
					first_floor_enemies();
					
				Here:
					Console.WriteLine("Congratulations, you have won!");
					Thread.Sleep(1000);
					Console.WriteLine("\n[C]ontinue...");
					Console.Write(">> ");
					string userInput = Console.ReadLine();
					
					if(userInput == "c" || userInput == "C") 
					{
						Console.Clear();
						Encounter.Loading();
						Console.Clear();
						Encounter.Floor("1ST");
						Encounter.extra_encounters();
					There:
						Console.WriteLine("\n\n[C]ontinue");
						Console.Write(">> ");
						string userinput = Console.ReadLine();
								
						if(!(userinput == "c" || userinput == "C")) {
							Console.Clear();
							goto There;
						}
								
						string a = "";
						do{
							Console.Clear();
							Encounter.Floor("1ST");
							Encounter.Loading();
							Console.Clear();
							Encounter.Floor("1ST");
							Console.WriteLine("\nWalk further...");
							Console.WriteLine("\n[W]alk");
							Console.Write(">> ");
							a = Console.ReadLine();
						}while(!(a == "W" || a == "w"));
							// go
						
					} else {
						Console.Clear();
						goto Here;
					}
					
				} else {
					Console.Clear();
					Encounter.Loading();
					Console.Clear();
					Console.WriteLine("You stumbled upon a large door.");
					Thread.Sleep(2000);
					Console.WriteLine("\nIt appears to be the last enemy of the 1st floor.");
					Thread.Sleep(2000);
					Console.WriteLine("\nYou slowly opened the door.");
					Thread.Sleep(2000);
				Here1:
					Console.WriteLine("\n[C]ontinue");
					Console.Write(">> ");
					string userInput = Console.ReadLine();
					
					if(userInput == "c" || userInput == "C") {
						Console.Clear();
						Console.WriteLine("A formidable enemy stands before you.");
						Encounter.Loading();
						Console.Clear();
						Enemy.Treant();
						Encounter.agility_check();
					} else {
						goto Here1;
					}
					
					Console.Clear();
					Console.WriteLine("CONGRATULATIONS");
					Thread.Sleep(2000);
					Console.WriteLine("\nYou beat the enemies and boss on 1st Floor.");
					Thread.Sleep(2000);
					Console.WriteLine("\nYou are to advance onto the next floor.");
					Thread.Sleep(2000);
					Console.WriteLine("\n[A]dvance");
					Console.Write(">> ");
					string userinput = Console.ReadLine();
					if(userinput == "a" || userinput == "A") {
						Console.Clear();
						second_floor_rng();
					}
				}
			}
		}
		
		public static void second_floor_rng(){
			
			Encounter.Floor("2ND");
			Encounter.Loading();
			Console.Clear();
			
			string playerInput = "";
			while(!(playerInput == "e" || playerInput == "E")) {
				Encounter.Floor("2ND");
				Console.WriteLine("[E]nter");
				Console.Write(">> ");
				playerInput = Console.ReadLine();
			}
			
			for(int i = 1; i <= 5; i++)
			{
				if(i < 5) {
					Console.Clear();
					Encounter.Floor("2ND");
					Encounter.Loading();
					Console.Clear();
					Encounter.Floor("2ND");
					Console.WriteLine("An enemy has appeared before you.");
					Encounter.Loading();
					Console.Clear();
					
					second_floor_enemies();
					
				Here:
					Console.WriteLine("Congratulations, you have won!");
					Thread.Sleep(1000);
					Console.WriteLine("\n[C]ontinue...");
					Console.Write(">> ");
					string userInput = Console.ReadLine();
					
					if(userInput == "c" || userInput == "C") 
					{
						Console.Clear();
						Encounter.Loading();
						Console.Clear();
						Encounter.Floor("2ND");
						Encounter.extra_encounters();
					There:
						Console.WriteLine("\n\n[C]ontinue");
						Console.Write(">> ");
						string userinput = Console.ReadLine();
								
						if(!(userinput == "c" || userinput == "C")) 
						{
							Console.Clear();
							goto There;
						} else {
							string a = "";
							do {
								Console.Clear();
								Encounter.Floor("2ND");
								Encounter.Loading();
								Console.Clear();
								Encounter.Floor("2ND");
								Console.WriteLine("\nWalk further...");
								Console.WriteLine("\n[W]alk");
								Console.Write(">> ");
								a = Console.ReadLine();
							} while(!(a == "W" || a == "w"));
						}
						
					} else {
						Console.Clear();
						goto Here;
					}
					
				} else {
					Console.Clear();
					Encounter.Loading();
					Console.Clear();
					Console.WriteLine("You stumbled upon a large door.");
					Thread.Sleep(2000);
					Console.WriteLine("\nIt appears to be the last enemy of the 2nd floor.");
					Thread.Sleep(2000);
					Console.WriteLine("\nYou slowly opened the door.");
					Thread.Sleep(2000);
					
					Console.WriteLine("\n[C]ontinue");
					Console.Write(">> ");
					string userInput = Console.ReadLine();
					
					if(userInput == "c" || userInput == "C") {
						Console.Clear();
						Console.WriteLine("A formidable enemy stands before you.");
						Encounter.Loading();
						Console.Clear();
						Enemy.Wyvern();
						Encounter.agility_check();
						
					}
				}
				
				
			}
			
			final_boss();
		}
		
		public static void final_boss(){
			if(Data.Name == "y" || Data.Name == "Y"){
				goto fight;
			}
			
			string userInput = "";
			do {
				Console.WriteLine("The mighty wyvern was reduced to nothing but a mere flightless lizard.");
				Thread.Sleep(1000);
				Console.WriteLine("\n[C]ontinue...");
				Console.Write(">> ");
				userInput = Console.ReadLine();
			} while(!(userInput == "c" || userInput == "C"));
			
			do {
			Console.Clear();
			Console.WriteLine("Something feels off...");
			Thread.Sleep(2000);
			Console.WriteLine("\nYou rested,and after resting for a bit you continued walking");
			Thread.Sleep(2000);
			Console.WriteLine("\nYou walked further...");
			Thread.Sleep(2000);
			Console.WriteLine("\nUntil you found a door leading to the last floor.");
			Thread.Sleep(2000);
			Console.WriteLine("\n[C]ontinue...");
			Console.Write(">> ");
			userInput = Console.ReadLine();
			} while(!(userInput == "c" || userInput == "C"));
			
			do {
				Data.Base_HP = Data.Endurance;
				Data.Base_MP = Data.MP;
				Data.potions = 5;
				Console.Clear();
				Console.WriteLine("Behind the final door is the root of chaos...");
				Thread.Sleep(2000);
				Console.WriteLine("\nA sinister serpent...");
				Thread.Sleep(2000);
				Console.WriteLine("\nA parasite... his presence alone spoils everything");
				Thread.Sleep(2000);
				Console.WriteLine("\nleaving you with just five potions on you");
				Thread.Sleep(2000);
				Console.WriteLine("\nWhatever it is, the last struggle between annihilation or liberation starts here.");
				Thread.Sleep(2000);
				Console.WriteLine("\n[C]ontinue...");
				Console.Write(">> ");
				
				userInput = Console.ReadLine();
			} while(!(userInput == "c" || userInput == "C"));
			
			// HERE HERE HERE
			
			Console.Clear();
			Thread.Sleep(1000);
			Encounter.Floor("LAST");
			Thread.Sleep(1000);
			Console.WriteLine("A God stands in your way.");
			Encounter.Loading();
		fight:
			Console.Clear();
			Enemy.Apophis();
			Encounter.agility_check();	
			
			Console.Clear();
			Encounter.Loading();
			Console.Clear();
			Console.WriteLine("[CONGRATULATIONS]");
			Thread.Sleep(1000);
			Console.WriteLine("\nYou have defeated the God of Darkness, [Apophis]");
			Thread.Sleep(2000);
			Console.WriteLine("\nWith the fall of the sinister serpent marks the end of your journey...");
			Thread.Sleep(2000);
			Console.WriteLine("\nThe world has begun to heal but the root of chaos still stands tall.");
			Thread.Sleep(2000);
			Console.WriteLine("\nIt wasn't a simple wound, it was a parasite. One day, someone will enter the tower and repeat your courageous feat once more!");   
			Thread.Sleep(2000);
			
			do {
				Console.WriteLine("\n[E]nd");
				Console.Write(">> ");
				userInput = Console.ReadLine();
			} while(!(userInput == "e" || userInput == "E"));
			
			Console.Clear();
			Encounter.Loading();
			Console.Clear();
			Program.RunMainMenu();
		}
			
			
	}
}
