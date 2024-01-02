using System;
using System.Threading;

namespace OURGAME
{
	/// <summary>
	/// Description of Encounter.
	/// </summary>
	public class Encounter
	{
		public static int protection {get; set;}
		public static int defense {get; set;}
		public static double percentage {get; set;}
		public static double percentage1 {get; set;}
		public static double percentage2 {get; set;}
		
//		public static void enemy() {
//			Console.WriteLine(Enemy.Enemy_Name + " : " + Enemy.Enemy_HP);
//			Console.Write("HP: " + Data.Base_HP);
//			Console.Write("       MP: " + Data.MP);
//			Console.Write("              Potions: " + Data.potions);
//			Console.Write("                     Strength: " + Data.Strength);
//			Console.Write("                            Magic: " + Data.Magic);
//			Console.WriteLine("\nWhat will you do");
//			string prompt = "choose";
//			buttons(prompt);
//		}
//
//		
//	    public static void buttons(string text)
//		{
//	    	
//			string[] options = {"1: Attack", "2: Magic","3: Heal","4: Defend"};
//			Menu mainMenu = new Menu(text, options);
//			
//			int selectedIndex = mainMenu.Run();
//			
//			switch(selectedIndex)
//			{
//				case 0:
//					swing();
//					break;
//				case 1:
//					magic();
//					break;
//				case 2:
//					healing();
//					break;
//				case 3:
//					defend();
//					break;
//		   }
//	    }
		
//			
//		
		// dito yung extra encounters 
		public static void Loading()
		{
			for(int i = 0; i < 3; i++) {
				Console.Write(" . ");
				Thread.Sleep(1000);
			}
		}
		
		public static void new_loading(string a)
		{	
			Console.WriteLine(a);
			for(int i = 0; i < 3; i++) {
				Console.Write(" . ");
				Thread.Sleep(1000);
			}
			Console.Clear();
			Console.WriteLine(a);
		}
		
		public static void short_loading(string a) 
		{
			Console.WriteLine("[{0}]", a);
			for(int i = 0; i < 3; i++) {
				Console.Write(" . ");
				Thread.Sleep(0500);
			}
			Console.Clear();
			Console.WriteLine("[{0}]", a);
		}
		
		public static void extra_encounters(){
			
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");
			Console.WriteLine("|                                                              |");
			Console.WriteLine("|     Would you like to delve deeper or catch your breath?     |");
			Console.WriteLine("|                                                              |");
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	
			check_stats();
			
			Console.WriteLine("\n\nWhat will you do");
			Console.WriteLine("1: Walk");
			Console.WriteLine("2: Rest"); 
			Console.Write("\n>> ");
			string player_choice = Console.ReadLine();
			
			switch(player_choice) {
				case "1":
					Walk();
					break;
				case "2": 
					Rest();
					break;
				default:
					extra_encounters();
					break;
			}
		}

		
		// choice 
		public static void Walk()
		{
			Console.Clear();
			new_loading("<<YOU WALKED A FEW PACES>>");
			Random rnd = new Random();
			int num = rnd.Next(0, 10); // 33.3% walk in peace or encounter
			
			if(num >= 0 && num < 3) {
				Console.WriteLine("================================================================");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                      You walked in peace.                    |");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");
		  		Console.WriteLine("================================================================");
				check_stats();
				// dunno
			} else {
				Different_Options();
//				Program.Next();
			}
		}
		
		public static void Rest()
		{
			Console.Clear();
			new_loading("<<YOU TAKE A REST>>");
			Random rnd = new Random();
			int num = rnd.Next(0, 10); // 70|30 rest in peace or encounter
			
			if(num < 7 || Data.Base_HP == Data.Endurance) {
				Console.WriteLine("================================================================");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                    You rested peacefully.                    |");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");
		  		Console.WriteLine("================================================================");
				check_stats();
				//dunno
			} else {
				Console.WriteLine("================================================================");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|            You gained some health and mana points            |");                  
				Console.WriteLine("|                        while resting.                        |");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");
		  		Console.WriteLine("================================================================");
		  		
				percentage = (double)(Data.Base_HP / Data.Endurance) * 100;
			    if(percentage == 100){
			    
				}else if(percentage >= 60){
					Data.Base_HP = Data.Endurance;
			    
				}else{
			    	double healing1 = (double)Data.Endurance * 0.4;
			    	Data.Base_HP += healing1;
			    }
				
				Data.Base_MP = Data.MP;
				check_stats();
			}
		}
		
		// different encounters
		public static void Different_Options()
		{
			Random rnd = new Random();
			int num = rnd.Next(0, 10);
			// 20% for a certain event to occur 
			if(num == 0 || num == 9) {
				Pitfall();
			} else if(num == 1 || num == 5 || num == 7) {
				
				Chest_Mimic();
			} else if(num == 2 || num == 6 || num == 8) {
				
				Unkown_Fruit();
			} else if(num == 3) {
				
				Fire_Trap();
			} else if(num == 4) {
				
				Arrow_Trap();
				
			}
		}
		
		public static void Pitfall()
		{
			Console.Clear();
		Here:
			Console.WriteLine("PITFALL");
			Thread.Sleep(1000);
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|             There is a pitfall in front of you.              |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	Console.WriteLine("");
		  	check_stats();
			Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			string userInput = Console.ReadLine();
			
			if(userInput == "n" || userInput == "N") {
				Random rnd = new Random();
				int num = rnd.Next(0, 3); // 33.3% chance to survive
				
				if(num == 0) {
					Console.Clear();
					short_loading("PITFALL");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|    You quickly noticed it and didn't fell into the abyss.    |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
					check_stats();
					Thread.Sleep(3000);
					//dunno
				} else {
					Console.Clear();
					short_loading("PITFALL");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|              You fell and you lost some health.              |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
			  		Data.Base_HP -= 15;
					check_stats();
					Thread.Sleep(3000);
					//dunno
				}
			} else {
				Console.Clear();
				goto Here;
			}
		}
		
		public static void Chest_Mimic()
		{
			Console.Clear();
			Console.WriteLine("[CHEST]");
			Thread.Sleep(1000);
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|               There is a chest in front of you.              |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
			check_stats();
		  	Console.WriteLine("\n\nWhat will you do?");
			Console.WriteLine("1: Open");
			Console.WriteLine("2: Walk Away");
			Console.Write("\n>> ");
		  	
			Loading();
			Console.Clear();
			Console.WriteLine("[CHEST]");
			Console.WriteLine("================================================================");
		    Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|               Would you like to open the chest?              |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	check_stats();
		  	Console.WriteLine("\n\nWhat will you do?");
			Console.WriteLine("1: Open");
			Console.WriteLine("2: Walk Away");
			Console.Write("\n>> ");
			int userInput = Convert.ToInt32(Console.ReadLine());
			
			if(userInput == 1) {
				Random rnd = new Random();
				int num = rnd.Next(0, 2); // 50|50 chest or mimic
				
				if(num == 0) {
					Console.Clear();
					short_loading("CHEST");
					Console.WriteLine("================================================================");       
					Console.WriteLine("|                                                              |");      					
					Console.WriteLine("|                 The chest is full of riches,                 |");
					Console.WriteLine("|                some armor, and weaponries too!               |");                  
					Console.WriteLine("|                 Some of your stats increased.                |");            
					Console.WriteLine("|                                                              |");    
		  			Console.WriteLine("================================================================");
		  			Data.Strength += 5;
		  			Data.Endurance += 10;
		  			Data.potions += 5;
					check_stats();
				//dunno
				} else { 
					Console.Clear();
					short_loading("CHEST");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|      The chest is a trap and you suffered some injury.       |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
		  			Console.WriteLine("================================================================");
		  			Data.Base_HP -= 15;
					check_stats(); 
				//dunno
				}
			} else if(userInput == 2) {
				Random rnd = new Random();
				int num = rnd.Next(0, 2); // 50|50 chest or mimic
				
				if(num == 0) {
				Console.Clear();
				short_loading("CHEST");
				Console.WriteLine("================================================================");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|   You walked away from it and didn't bother to open at all.  |");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");
		  		Console.WriteLine("================================================================");
				check_stats();
				//dunno
				} else {
				Console.Clear();
				short_loading("CHEST");
				Console.WriteLine("================================================================");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|     Good thing you didn't open the chest. It was a trap      |");                  
				Console.WriteLine("|                          after all.                          |");
				Console.WriteLine("|                                                              |");                  
				Console.WriteLine("|                                                              |");
		  		Console.WriteLine("================================================================");
				check_stats();
				//dunno
				}
			}
			
		}
		
		public static void Arrow_Trap()
		{
			Console.Clear();
			Console.WriteLine("[ARROW TRAP]");
			Thread.Sleep(1000);
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                 Today isn't your lucky day.                  |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	check_stats();
			Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			Loading();
			Console.Clear();
		Here:
			Console.WriteLine("[ARROW TRAP]");
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                     You triggered a trap.                    |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	check_stats();
			Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			
			string userInput = Console.ReadLine();
			
			if(userInput == "n" || userInput == "N") {
				Random rnd = new Random();
				int num = rnd.Next(0, 3); // 33.3% chance to dodge 
				
				if(num == 0) {
					Console.Clear();
					short_loading("ARROW TRAP");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                     You dodged the arrow.                    |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
					check_stats();
					//dunno
				} else {
					Console.Clear();
					short_loading("ARROW TRAP");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                                    
					Console.WriteLine("|                   You got hit by the arrow.                  |");
					Console.WriteLine("|                     You got hurt by 15 HP                    |");   
					Console.WriteLine("|                                                              |");					
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
			  	    Data.Base_HP -= 15;
					check_stats();
					//dunno
				} 
			} else {
				Console.Clear();
				goto Here;
			}
		}
		
		public static void Fire_Trap()
		{
			Console.Clear();
			Console.WriteLine("[FIRE TRAP]");
			Thread.Sleep(1000);
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                 Today isn't your lucky day.                  |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
			Console.WriteLine("");
		  	check_stats();
		  	Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			Loading();
			Console.Clear();
		Here:
			Console.WriteLine("[FIRE TRAP]");
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                     You triggered a trap.                    |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
		  	Console.WriteLine("");
		  	check_stats();
		  	Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			
			string userInput = Console.ReadLine();
			
			if(userInput == "n" || userInput == "N") {
				Random rnd = new Random();
				int num = rnd.Next(0, 3); // 33.3% chance to dodge 
				
				if(num == 0) {
					Console.Clear();
					short_loading("FIRE TRAP");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|          You rolled away quickly from the fire trap.         |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
					check_stats();
					//dunno
				} else {
					Console.Clear();
					short_loading("FIRE TRAP");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                                 
					Console.WriteLine("|        You're so slow you got burns from the fire trap.      |");
					Console.WriteLine("|                 Causing you to lose 20 HP                    |"); 
					Console.WriteLine("|                                                              |");   					
					Console.WriteLine("|                                                              |");
			  		Console.WriteLine("================================================================");
			  		Data.Base_HP -= 15;
					check_stats();
					//dunno
				} 
			} else {
				Console.Clear();
				goto Here;
			}
		}
		
		public static void Unkown_Fruit()
		{
			Console.Clear();
		Here:
			Console.WriteLine("[UNKOWN FRUIT]");
			Thread.Sleep(1000);
			Console.WriteLine("================================================================");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|            You found a fruit laying on the ground.           |");
			Console.WriteLine("|                                                              |");                  
			Console.WriteLine("|                                                              |");
		  	Console.WriteLine("================================================================");
			Console.WriteLine("");
		  	check_stats();
		  	Console.WriteLine("\n\n[N]ext");
			Console.Write(">> ");
			
			string userInput = Console.ReadLine();
			
			if(userInput == "n" || userInput == "N") {
		  	
				for(int i = 0; i < 2; i++) {
					switch(i) {
						case 0:
							Console.Clear();
							Console.WriteLine("[UNKNOWN FRUIT]");
							Console.WriteLine("================================================================");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|        You've never seen this kind of a fruit before.        |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("================================================================");
							check_stats();
							Console.WriteLine("\n\nWhat will you do?");
							Console.WriteLine("1: Eat");
							Console.WriteLine("2: Leave it behind");
							Console.Write("\n>> ");
							break;
						case 1: 
							Console.Clear();
							Console.WriteLine("[UNKOWN FRUIT]");
							Console.WriteLine("================================================================");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|            Would you like to eat the unkown fruit?           |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("|                                                              |");
							Console.WriteLine("================================================================");
							check_stats();
							Console.WriteLine("\n\nWhat will you do?");
							Console.WriteLine("1: Eat");
							Console.WriteLine("2: Leave it behind");
							Console.Write("\n>> ");
							break;
					}
					Loading();
				}
				
				
				int userInput1 = Convert.ToInt32(Console.ReadLine());
				
				if(userInput1 == 1) {
					Console.Clear();
					Random rnd = new Random();
					int num = rnd.Next(0, 2); // 50|50 extra potion or damage
				
					if(num == 0) {
						Console.Clear();
						short_loading("UNKOWN FRUIT");
						Console.WriteLine("================================================================");
						Console.WriteLine("|                                                              |");                  
						Console.WriteLine("|       The unknown fruit is a good one. You gained health     |");                  
						Console.WriteLine("|                        from eating it.                       |");
						Console.WriteLine("|                                                              |");                  
						Console.WriteLine("|                                                              |");
			  			Console.WriteLine("================================================================");
			  			Data.Base_HP = Data.Endurance;
						check_stats();
						//dunno
					} else {
						Console.Clear();
						short_loading("UNKOWN FRUIT");
						Console.WriteLine("================================================================");
						Console.WriteLine("|                                                              |");                                   
						Console.WriteLine("|    The unknown fruit is a poison. You suffered health loss   |");
						Console.WriteLine("|                        from eating it.                       |");    
						Console.WriteLine("|                                                              |"); 				
						Console.WriteLine("|                                                              |");
			  			Console.WriteLine("================================================================");
			  			Data.Base_HP -= 20;
						check_stats();
						//dunno
					} 
				} else if(userInput1 == 2) {
					Console.Clear();
					Console.WriteLine("[UNKOWN FRUIT]");
					Console.WriteLine("================================================================");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                    Better safe than sorry.                   |");
					Console.WriteLine("|                                                              |");                  
					Console.WriteLine("|                                                              |");
				  	Console.WriteLine("================================================================");
					check_stats();
				}
			} else {
				Console.Clear();
				goto Here;
			}
		}		
		
		
		// fight with enemy 
		public static void agility_check(){
			if(Data.Agility > Enemy.Enemy_Agility){
			choice();
			}else{
			battle_phase();
			}
		}
		
		public static int a {get; set;}
		
		public static void battle_phase() 
		{
			// 1ST FLOOR ENEMIES
			if(Enemy.Enemy_Name == "Treant") 
			{
				Random rnd = new Random();
					
				int num = rnd.Next(1,11);
					
				if(num % 2 == 0 || num % 3 == 0) {
					Enemy.Enemy_atk = 36; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used Claw Strike Attack]");
					UI2();
					Loading();
					Console.Clear();
						
					Animation.treant_claw_strike_atk();
					
				} else {
					Enemy.Enemy_atk = 42; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used Uproot Attack]");
					UI2();
					Loading();
					Console.Clear();
						
					Animation.treant_uproot_atk();
				}
				
			} else if(Enemy.Enemy_Name == "Goblin" || Enemy.Enemy_Name == "Kobold" || Enemy.Enemy_Name == "Goblin Shaman" || Enemy.Enemy_Name == "Orc") {
				UI("[" + Enemy.Enemy_Name + " attacks]");
				UI2();
				Loading();
				Console.Clear();
				
				if(Enemy.Enemy_Name == "Goblin") {
					Animation.goblin_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Kobold") {
					Animation.kobold_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Goblin Shaman") {
					Animation.goblin_shaman_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Orc") {
					Animation.orc_atk();
					Console.Clear();
				}
			}
			
			// 2ND FLOOR ENEMIES
			if(Enemy.Enemy_Name == "Wyvern") 
			{
				Random rnd = new Random();
				int num = rnd.Next(1,11);
					
				if(num % 2 == 0 || num == 6) {
				    Enemy.Enemy_atk = 36; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used Crunch Attack]");
					UI2();
					Loading();
					Console.Clear();
						
					Animation.wyvern_crunch_atk();
					
				} else if(num % 3 == 0 || num == 7) {
					Enemy.Enemy_atk = 53; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used Breath Fire Attack]");
					UI2();
					Loading();
					Console.Clear();
						
					Animation.wyvern_breathe_fire_atk();
					
				} else {
					Enemy.Enemy_atk = 61; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used Tail Spike Attack]");
					UI2();
					Loading();
					Console.Clear();
					Animation.wyvern_tail_spike_atk();
				}
				
			}else if(Enemy.Enemy_Name == "Apophis")
			{
				a += 1;
				
				if(a == 1 || a == 2) {
					Random rnd = new Random();
					int num = rnd.Next(1,3);
					
					if(num == 1) {
						Enemy.Enemy_atk = 60; // pagpalagay na yan ang damage
						UI("[" + Enemy.Enemy_Name + " used Root Rush]");
						UI2();
						Loading();
						Console.Clear();
						
						Animation.treant_uproot_atk();
					
					} else if(num == 2) {
						Enemy.Enemy_atk = 70; // pagpalagay na yan ang damage
						UI("[" + Enemy.Enemy_Name + " used Holy Fire]");
						UI2();
						Loading();
						Console.Clear();
						
						Animation.apophis_holy_fire();
					}
					
				} else {
					a = 0;
					Enemy.Enemy_atk = 80; // pagpalagay na yan ang damage
					UI("[" + Enemy.Enemy_Name + " used CURSE OF RA]");
					UI2();
					Loading();
					Console.Clear();
					
					Animation.apophisBurn();
				}	
				
			}else if(Enemy.Enemy_Name == "Swarm of Rats" || Enemy.Enemy_Name == "Pack of Wolves" || Enemy.Enemy_Name == "Rabid Wolf" || Enemy.Enemy_Name == "Werewolf"){
				UI("[" + Enemy.Enemy_Name + " Attacks]");
				UI2();
				Loading();
				Console.Clear();
				
				if(Enemy.Enemy_Name == "Swarm of Rats") {
					Animation.swarm_rats_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Pack of Wolves") {
					Animation.pack_of_wolves_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Rabid Wolf") {
					Animation.rabid_wolf_atk();
					Console.Clear();
				} else if(Enemy.Enemy_Name == "Werewolf") {
					Animation.werewolf_atk();
					Console.Clear();
				}
			}
			
			
			if(protection > 0){
				Enemy.Enemy_atk = 0;
				protection -= 1;
			}else if(defense > 0){
				Enemy.Enemy_atk = Enemy.Enemy_atk / 2;
				defense -= 1;
			}
			
			Data.Base_HP -= Enemy.Enemy_atk;
			player_stat_checker();
			
			Console.Clear();
			UI("Enemy " + Enemy.Enemy_Name + " dealt " + Enemy.Enemy_atk + " damage to you");
			UI2();
			
			Loading();
			
			if(Enemy.Enemy_Name == "Goblin") {
				Enemy.Enemy_atk = 8;
			} else if(Enemy.Enemy_Name == "Goblin Shaman") {
				Enemy.Enemy_atk = 20;
			} else if(Enemy.Enemy_Name == "Kobold") {
				Enemy.Enemy_atk = 15;
			} else if(Enemy.Enemy_Name == "Orc") {
				Enemy.Enemy_atk = 24;
			} else if(Enemy.Enemy_Name == "Swarm of Rats") {
				Enemy.Enemy_atk = 20;
			} else if(Enemy.Enemy_Name == "Pack of Wolves") {
				Enemy.Enemy_atk = 20;
			} else if(Enemy.Enemy_Name == "Rabid Wolf") {
				Enemy.Enemy_atk = 26;
			} else if(Enemy.Enemy_Name == "Werewolf") {
				Enemy.Enemy_atk = 34;
			} 
			
			Console.Clear();
			choice();
		}
	
		static void DisplayColoredString(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor)
    	{
	        // Save the current console colors
	        ConsoleColor originalForegroundColor = Console.ForegroundColor;
	        ConsoleColor originalBackgroundColor = Console.BackgroundColor;
	
	        // Set the new colors
	        Console.ForegroundColor = foregroundColor;
	        Console.BackgroundColor = backgroundColor;
	
	        // Display the string
	        Console.Write(text);
	
	        // Restore the original colors
	        Console.ForegroundColor = originalForegroundColor;
	        Console.BackgroundColor = originalBackgroundColor;
	        
	        
    	}
			public static void hp_check(){
			percentage = (double)(Data.Base_HP / Data.Endurance) * 100;
			
			if(percentage == 100){
				Console.Write("HP: ");
				DisplayColoredString("██████ ", ConsoleColor.Green, ConsoleColor.Black); 
				Console.Write("{0}",Data.Base_HP + "/ " + Data.Endurance);
			
			}else if(percentage >= 80){
				Console.Write("HP: ");
				DisplayColoredString("██████ ", ConsoleColor.Green, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
				
			}else if(percentage >= 60){
				Console.Write("HP: ");
				DisplayColoredString("█████  ", ConsoleColor.Yellow, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
			
			}else if(percentage >= 40){
				Console.Write("HP: ");
				DisplayColoredString("████   ", ConsoleColor.DarkYellow, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
			
			}else if(percentage >= 20){
				Console.Write("HP: ");
				DisplayColoredString("███    ", ConsoleColor.Red, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
			
			}else if(percentage >= 10){
				Console.Write("HP: ");
				DisplayColoredString("██     ", ConsoleColor.DarkRed, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
			}else {
				Console.Write("HP:        " + String.Format("{0:0}",Data.Base_HP + "/ " + Data.Endurance));
			}
		}
		
		public static void mp_check(){
			percentage1 = (double)(Data.Base_MP / Data.MP) * 100;
			
			if(percentage1 == 100){
				Console.Write("\n\nMP: ");
				DisplayColoredString("██████ ", ConsoleColor.Blue, ConsoleColor.Black); 
				Console.Write("{0:0}             ",Data.Base_MP + "/ " + Data.MP);
				
			}else if(percentage1 >= 80){
				Console.Write("\n\nMP: ");
				DisplayColoredString("██████  ", ConsoleColor.Blue, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}           ",Data.Base_MP + "/ " + Data.MP));
				
			}else if(percentage1 >= 60){
				Console.Write("\n\nMP: ");
				DisplayColoredString("█████   ", ConsoleColor.Blue, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}          ",Data.Base_MP + "/ " + Data.MP));
			
			}else if(percentage1 >= 40){
				Console.Write("\n\nMP: ");
				DisplayColoredString("████    ", ConsoleColor.Blue, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}          ",Data.Base_MP + "/ " + Data.MP));
			 
			}else if(percentage1 >= 20){
				Console.Write("\n\nMP: ");
				DisplayColoredString("███     ", ConsoleColor.Blue, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}          ",Data.Base_MP + "/ " + Data.MP));
			
			}else if(percentage >= 10){
				Console.Write("\n\nMP: ");
				DisplayColoredString("██       ", ConsoleColor.Blue, ConsoleColor.Black);
				Console.Write(String.Format("{0:0}          ",Data.Base_MP + "/ " + Data.MP));
			}else {
				Console.Write("\n\nMP:        " + String.Format("{0:0}          ",Data.Base_MP + "/ " + Data.MP));
			}
		}
		
		public static void enemy_HP_check() { // ewan ko sala yung logic ata rito
			percentage2 = (double)(Enemy.Enemy_HP / Enemy.Enemy_MaxHP) * 100;
			
			if(percentage2 == 100){
				Console.Write("HP: ");
				DisplayColoredString("██████ ", ConsoleColor.Green, ConsoleColor.Black); 
				Console.Write("{0}", Enemy.Enemy_HP); // dito ko ilalagay yon
				
			}else if(percentage2 >= 80){
				Console.Write("HP: ");
				DisplayColoredString("██████ ", ConsoleColor.Green, ConsoleColor.Black);
				Console.Write(String.Format("{0}", Enemy.Enemy_HP));
				
			}else if(percentage2 >= 60){
				Console.Write("HP: ");
				DisplayColoredString("█████  ", ConsoleColor.Yellow, ConsoleColor.Black);
				Console.Write(String.Format("{0}", Enemy.Enemy_HP));
			
			}else if(percentage2 >= 40){
				Console.Write("HP: ");
				DisplayColoredString("████   ", ConsoleColor.DarkYellow, ConsoleColor.Black);
				Console.Write(String.Format("{0}", Enemy.Enemy_HP));
			
			}else if(percentage2 >= 20){
				Console.Write("HP: ");
				DisplayColoredString("███    ", ConsoleColor.Red, ConsoleColor.Black);
				Console.Write(String.Format("{0}", Enemy.Enemy_HP));
			
			}else if(percentage2 > 0){
				Console.Write("HP: ");
				DisplayColoredString("██     ", ConsoleColor.DarkRed, ConsoleColor.Black);
				Console.Write(String.Format("{0}", Enemy.Enemy_HP));
			}else {
				Console.Write("HP:        " + String.Format("{0}", Enemy.Enemy_HP));
			}
		}
		
		public static void check_stats() {
			Console.Write("\n[{0}] ", Data.Name);
			Console.WriteLine("LVL - {0}", Data.Player_Level);
			Console.WriteLine("EXP: {0} | {1}", Data.Player_Exp, Data.Max_Exp);
			Console.WriteLine("");
		  	hp_check();
		  	Console.Write("            Strength: " + Data.Strength);
			Console.Write("              Potions: " + Data.potions);
			mp_check();
			Console.Write("Magic: " + Data.Magic);
		}
		
		public static void UI(string a)
		{
			if(Enemy.Enemy_Name == "Goblin" || Enemy.Enemy_Name == "Kobold" || Enemy.Enemy_Name == "Goblin Shaman" || Enemy.Enemy_Name == "Orc" || Enemy.Enemy_Name == "Treant") {
				Floor("1ST");
			} else if(Enemy.Enemy_Name == "Apophis") {
				Floor("LAST");
			} else {
				Floor("2ND");
			}
			
			Console.WriteLine("[{0}]", Enemy.Enemy_Name);
			enemy_HP_check(); 
			Console.WriteLine("\n================================================================");
		  	Console.Write(Enemy.Enemy_Art);
		  	Console.WriteLine("\n================================================================");
		  	Console.WriteLine("Text : " + a);
		  	check_stats();
		}
		
		public static void UI2()
		{
			Console.WriteLine("\n\nWhat will you do");
			Console.WriteLine("1: Attack");
			Console.WriteLine("\b2: Magic");  
			Console.WriteLine("3: Heal");
			Console.WriteLine("4: Defend");
			
			Console.WriteLine("\nYour action");
			Console.Write(">> ");
		}
		
		public static void Floor(string a) {
			Console.WriteLine("[{0} FLOOR]\n", a);
		}
		
		public static void choice() {
			if(Data.Base_HP <= 0) {
				check();
			}
			UI("");
			UI2();
			
			var choice_battle = Console.ReadLine();
			
			switch(choice_battle){
				case "1":
					swing();
					break;
				case "2":
					magic();
					break;
				case "3":
					healing();
					break;
				case "4":
					defend();
					break;
				default:
					Console.Clear();
					choice();
					break;
			}
		}
		
		public static void swing(){
			Enemy.Enemy_HP -= Data.Strength;
			enemy_hp_checker();
			Console.Clear();
			UI("You have dealt " + Data.Strength + " damage to it");
			UI2();
			Loading();
			Console.Clear();
			
			if(Enemy.Enemy_HP > 0) {
				battle_phase();
			} else {
				check();
			}
		}
		
		// puntang battle phase, kulang
		public static void magic(){
			Console.Clear();
			UI("");
		  	Console.WriteLine("\n\nWhat Magic: ");
			Console.WriteLine("1. Fireball 25 MP");
			Console.WriteLine("2. Ice Barrier 50 MP");
			Console.WriteLine("3. Heal 75 MP");
			Console.WriteLine("4. Go back");
			Console.WriteLine("\nYour action");
			Console.Write(">> ");
			
			var magic_choice = Console.ReadLine();
			Console.Clear();
			
			if(magic_choice == "1" && Data.Base_MP >= 25){
				Enemy.Enemy_HP -= Data.Magic * 2;
				enemy_hp_checker();
				Data.Base_MP -= 25;
				UI("You have dealt " + Data.Magic * 2 + " damage to it.");
				UI2();
				Loading();
				Console.Clear();

				if(Enemy.Enemy_HP > 0) {
					battle_phase();
				} else {
					check();
				}
				
			} else if (magic_choice == "1" && Data.Base_MP <= 25){
				UI("You don't have any enough mana.");
				UI2();
				Loading();
				Console.Clear();
				choice();
				
			} else if(magic_choice == "2" && Data.Base_MP >= 50){
				protection += 1;
				UI("You have gained protection. You are protected for one turn");
				UI2();
				Data.Base_MP -= 50;
				Loading();
				Console.Clear();
				choice();
				
			} else if (magic_choice == "2" && Data.Base_MP <= 50){
				UI("You don't have enough mana.");
				UI2();
				Loading();
				Console.Clear();
				choice();
				
			} else if(magic_choice == "2" && protection == 1){
				UI("You are already protected");
				UI2();
				Loading();
				Console.Clear();
				choice();
			
			} else if(magic_choice == "3" && Data.Base_MP >= 80){
				Console.Clear();
				UI("You tried healing yourself");
				percentage = (double)(Data.Base_HP / Data.Endurance) * 100;
				if(percentage == 100){
					Console.Clear();
					UI("You are at full health.");
					UI2();
					Loading();
					Console.Clear();
					choice();
				}else if(percentage >= 40){
					Console.Clear();	
					UI("You have healed yourself");
					UI2();
					Data.Base_HP = Data.Endurance;
					Data.Base_MP -= 80;
					Loading();
					Console.Clear();
					battle_phase();
		    	}else{
				    Console.Clear();
					UI("You have healed yourself");	
					UI2();						
			    	double healing1 = (double)Data.Endurance * 0.6;
			    	Data.Base_HP += healing1;
			    	Data.Base_MP -= 80;
			    	Loading();
					Console.Clear();		    	
			    	battle_phase();
		    	}
				
			} else if (magic_choice == "3" && Data.Base_MP <= 75){
				Console.Clear();
				UI("You don't have any enough mana");
				UI2();
				Loading();
				Console.Clear();
				choice();	
			
			} else if(magic_choice == "4"){
				Console.Clear(); 
				choice();
			}
		}
		
		public static void healing(){
			percentage = (double)(Data.Base_HP / Data.Endurance) * 100;
			if(Data.potions == 0) {
				Console.Clear();
				UI("You don't have any potions left.");
				UI2();
				Loading();
				Console.Clear();
				choice();
		    }else if(percentage == 100){
				Console.Clear();
				UI("You are at full health.");
				UI2();
				Loading();
				Console.Clear();		    	
		    	choice();
		    }else if(percentage >= 60){
				Console.Clear();
				UI("Your Health is restored");
				UI2();
				Data.Base_HP = Data.Endurance;
				Data.potions -= 1;
				Loading();
				Console.Clear();		    	
		    	choice();
		    }else{
				Console.Clear();
				UI("Your Health is restored");
				UI2();
				double healing1 = (double)Data.Endurance * 0.4;
			    Data.Base_HP += healing1;
				Data.potions -= 1;
				Loading();
				Console.Clear();		    	
		    	choice();
		    }
		}
		
		public static void defend(){
			Console.Clear();
			UI("You held your shield and braced for the attack");
			UI2();
			defense += 1;
			percentage = (double)(Data.Base_MP / Data.MP) * 100;
			
			if(Data.Base_MP <= 100){
			if(percentage >= 75){
				Data.Base_MP = Data.MP;
			}else{                                                                        
				double regen = (double)Data.MP * 0.25;
		    	Data.Base_MP += regen;
		    }
				
			}else if(Data.Base_MP >= 101 && Data.Base_MP <= 199){
			if(percentage >= 80){
				Data.Base_MP = Data.MP;
			}else{                                                                        
				double regen = (double)Data.MP * 0.20;
		    	Data.Base_MP += regen;
		    }
				
			}else if(Data.Base_MP <= 200){
			if(percentage >= 85){
				Data.Base_MP = Data.MP;
			}else{                                                                        
				double regen = (double)Data.MP * 0.15;
		    	Data.Base_MP += regen;
		    }
				
			}
			Thread.Sleep(2000);
			Console.Clear();
			battle_phase();
			choice();
			if(Data.Base_HP <= 0){
				Console.WriteLine("You lost");
				Console.WriteLine("Would you like to try again?");
				Console.Write(">> ");
				Retry();
			}else{
				Thread.Sleep(2000);
				Console.Clear();
				choice();
			}
		}
		

		
		public static void player_stat_checker()
		{
			if(Data.Base_HP <= 0) {
				Data.Base_HP = 0;
			}
		}
		
		public static void enemy_hp_checker()
		{
			if(Enemy.Enemy_HP <= 0) {
				Enemy.Enemy_HP = 0;
			}
		}
		
		
		public static void check(){
			player_stat_checker();
			enemy_hp_checker();
			if (Enemy.Enemy_HP <= 0) {
				Console.Clear();
				Level_Checker();
			} else if (Data.Base_HP <= 0) {
				Console.Clear();
    			Console.WriteLine("You lost.");
    			Console.WriteLine("Would you like to try again?");
    			Console.WriteLine("[Y]es or [N]o");
    			Console.Write(">> ");
    			Retry();
			} else {
    			Console.Clear();
    			choice();
			}
		}
		
		public static void Level_Checker()
		{	
			if(Data.Player_Exp == 0 || Data.Player_Exp == 59){
				Data.Player_Exp += 40;
			} else if(Data.Player_Exp == 40 || Data.Player_Exp == 99) {
				Data.Player_Exp += 44;
			} else if(Data.Player_Exp == 84 || Data.Player_Exp == 37) {
				Data.Player_Exp += 48;
			} else if(Data.Player_Exp == 30 || Data.Player_Exp == 85) {
				Data.Player_Exp += 52;
			} else if(Data.Player_Exp == 82 || Data.Player_Exp == 29) {
				Data.Player_Exp += 81;
			} // this is fixed 
					
			
			if(Data.Player_Exp >= Data.Max_Exp)
			{
				Data.Player_Level+= 1;
				
				Data.Player_Exp -= Data.Max_Exp; // bago mapalitan yung value ng max exp 
				
				Data.Max_Exp += 2; // fixed
				Data.Endurance += 10;
				Data.MP += 10;
				Data.Magic += 2;
				Data.Strength += 4;
				Data.Agility += 5 ;
				
				Data.Base_HP = Data.Endurance;
				Data.Base_MP = Data.MP;
			Here:
				Console.Clear();
				Console.WriteLine("<<YOU LEVELED UP>>");
				Thread.Sleep(1500);
				Console.Write("\n[{0}] ", Data.Name);
				Console.WriteLine("LVL {0}", Data.Player_Level);
				Console.WriteLine("EXP: {0} | {1}", Data.Player_Exp, Data.Max_Exp);
				
				Console.WriteLine("\nCURRENT STATS");
				Thread.Sleep(1000);
				Console.WriteLine("Strength   : " + Data.Strength);
				Thread.Sleep(1000);
				Console.WriteLine("Endurance  : " + Data.Endurance);
				Thread.Sleep(1000);
				Console.WriteLine("Magic      : " +  Data.Magic);
				Thread.Sleep(1000);
				Console.WriteLine("Agility    : " +  Data.Agility);
				Thread.Sleep(1000);
				
				Console.WriteLine("\n[C]ontinue");
				Console.Write(">> ");
				string userInput = Console.ReadLine();
				
				if(userInput == "C" || userInput == "c") {
					// end of code
					Console.Clear();
				} else {
					goto Here;
				}
			} else {
				
			}
		}
			
		public static void Retry(){
			string userInput = Console.ReadLine();
			
			if(userInput == "Y" || userInput == "y") {
				Console.Clear();
				Data.Player_Level = 0;
				Data.Player_Exp = 0;
				Data.Max_Exp = 102;
				Introduction.Introduction1();
			} else if(userInput == "N" || userInput == "n") {
				do {
					Console.WriteLine("You died.");
					Console.Write("Press [enter] to exit.");
					
				} while(Console.ReadKey().Key != ConsoleKey.Enter);
				Environment.Exit(0);
			}
		}
	}
}
		
		
		
		
		
		
		
		
		
		
		
		
	