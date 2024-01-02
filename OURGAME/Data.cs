using System;
using System.Threading;

namespace OURGAME
{
	/// <summary>
	/// Description of Data.
	/// </summary>
	public class Data
	{
		public static string Name {get; set;}
		public static double Strength {get; set;}
		public static double Endurance {get; set;}
		public static double Base_HP {get; set;}
		public static double Magic {get; set;}
		public static double MP {get; set;}
		public static double Base_MP {get; set;}
		public static double Agility {get; set;}
		public static int Experience_Points {get; set;}
		public static int Experience_cap {get; set;}
		public static int Base_Points {get; set;}
		public static int potions {get; set;}
		public static int Double_Input { get; set; }
		public static int Player_Exp { get; set;}
		public static int Max_Exp { get; set;}
		public static int Player_Level { get;set;}
		
		public static void Statement()
		{			
			Console.WriteLine("You have " + Base_Points + " left");
			Console.Write("How many points will you allocate for ");
		}
		
		public static void Strength_stat()
		{   
			Statement(); Console.Write("[Strength]  : ");
			Strength = 2; //base (pagpalagay lang na ito yung base)
			
			try {
				Double_Input = Convert.ToInt32(Console.ReadLine());
				if(Double_Input > Base_Points || Double_Input == Base_Points){
					Console.WriteLine("\nYou don't have any points to allocate. \nPlease try again");
					Thread.Sleep(2000);
					Console.Clear();
					Introduction.Start();	
				} 
				
				Strength *= Double_Input;
				while(!(Double_Input > 0 && Double_Input <= 20))
				{
					if(Double_Input <= 0) {
						Console.WriteLine("\nThat isn't the minimum requirement. \nPlease try again.");
					} else {
						Console.WriteLine("\nYou went over the limit. \nPlease try again");
					}
					Thread.Sleep(2000);
					Console.Clear();
					Introduction.Start();
					Strength_stat();
				}
				
				Base_Points -= Double_Input;
			} catch(Exception) {
				Console.WriteLine("\n[TRY AGAIN]");
				Strength_stat();
			}
			
			
		}
		
		public static void Endurance_stat()
		{
			Statement(); Console.Write("[Endurance] : ");
			Endurance = 10; //base (pagpalagay lang na ito yung base)
			
			try{ 
				Double_Input = Convert.ToInt32(Console.ReadLine());
				if(Double_Input > Base_Points || Double_Input == Base_Points){
					Console.WriteLine("\nYou don't have any points to allocate. \nPlease try again");
					Thread.Sleep(3000);
					Console.Clear();
					Introduction.Start();
				} 
				
				Endurance *= Double_Input;
				Base_HP = Endurance;

				while(!(Double_Input > 0 && Double_Input <= 20))
				{
					if(Double_Input <= 0) {
						Console.WriteLine("\nThat isn't the minimum requirement. \nPlease try again.");
					} else {
						Console.WriteLine("\nYou went over the limit. \nPlease try again");
					}
					Thread.Sleep(2000);
					Console.Clear();
					Introduction.Start();
					Endurance_stat();
				}
				
				Base_Points -= Double_Input;
				
			} catch(Exception) {
				Console.WriteLine("\n[TRY AGAIN]");
				Endurance_stat();
			}
		}
		
		public static void Magic_stat()
		{
			Statement(); Console.Write("[Magic]     : ");
			Magic = 3; //base (pagpalagay lang na ito yung base)

			
			try {
				Double_Input = int.Parse((Console.ReadLine()));
				if(Double_Input > Base_Points || Double_Input == Base_Points){
					Console.WriteLine("\nYou don't have any points to allocate. \nPlease try again");
					Thread.Sleep(3000);
					Console.Clear();
					Introduction.Start();
				} 
				double mp_calculation = Double_Input * 5;
				MP  = 80 + mp_calculation;				
				Magic *= Double_Input;
				Base_MP = MP;
				
				while(!(Double_Input > 0 && Double_Input <= 20))
				{
					if(Double_Input <= 0) {
						Console.WriteLine("\nThat isn't the minimum requirement. \nPlease try again.");
					} else {
						Console.WriteLine("\nYou went over the limit. \nPlease try again");
					}
					Thread.Sleep(2000);
					Console.Clear();
					Introduction.Start();
					Endurance_stat();
				}
				
				Base_Points -= Double_Input;
				
			} catch(Exception) {
				Console.WriteLine("\n[Try Again]");
				Magic_stat();
			}
		}
		
		public static void Agility_stat()
		{
		    Statement(); Console.Write("[Agility]   : ");
			Agility = 3; //base (pagpalagay lang na ito yung base)
			
			try {
				Double_Input = Convert.ToInt32(Console.ReadLine());
				if(Double_Input == Base_Points) {
					Agility *= Double_Input;
					Base_Points -= Double_Input;
				} else if(Double_Input < Base_Points) {
					Console.WriteLine("\nYou have points left. Please use all of them.");
					Thread.Sleep(3000);
					Console.Clear();
					Introduction.Start();
				} else if(Double_Input <= 20) {
					Console.WriteLine("\nYou went over the limit. \nPlease try again");
					Thread.Sleep(2000);
					Console.Clear();
					Introduction.Start();
					Strength_stat();
				}
			
			} catch(Exception) {
				Console.WriteLine("\n[Try Again]");
				Agility_stat();
			}
		}
	}
}
