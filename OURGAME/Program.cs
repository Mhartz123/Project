using System;

namespace OURGAME
{
	class Program
	{
		public static void Main()
		{
Console.WriteLine("Type anything then press enter to start playing");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("");
Console.WriteLine("Stretch the window till you see both text from above and below and until this text doesn't go into the next paragraph thanks");
string input = Console.ReadLine();
			RunMainMenu();
		}
		
		public static void RunMainMenu()
		{				
			Console.Clear();
			string prompt = @"

_________ _______           _______  _______    _______  _       _________ _______  ______   _______  _______ 
\__   __/(  ___  )|\     /|(  ____ \(  ____ )  (  ____ \( \      \__   __/(       )(  ___ \ (  ____ \(  ____ )
   ) (   | (   ) || )   ( || (    \/| (    )|  | (    \/| (         ) (   | () () || (   ) )| (    \/| (    )|
   | |   | |   | || | _ | || (__    | (____)|  | |      | |         | |   | || || || (__/ / | (__    | (____)|
   | |   | |   | || |( )| ||  __)   |     __)  | |      | |         | |   | |(_)| ||  __ (  |  __)   |     __)
   | |   | |   | || || || || (      | (\ (     | |      | |         | |   | |   | || (  \ \ | (      | (\ (   
   | |   | (___) || () () || (____/\| ) \ \__  | (____/\| (____/\___) (___| )   ( || )___) )| (____/\| ) \ \__
   )_(   (_______)(_______)(_______/|/   \__/  (_______/(_______/\_______/|/     \||/ \___/ (_______/|/   \__/
                                                                                                             
                                                                                           

";
			string[] options = {"Play", "Credits", "Exit"};
			Menu mainMenu = new Menu(prompt, options);
			
			int selectedIndex = mainMenu.Run();
			
			switch(selectedIndex)
			{
				case 0:
					Play();
					break;
				case 1:
					Credits();
					break;
				case 2:
					Exit();
					break;
			}
		}
		
		public static void SecondMenu(string text)
		{
			string[] options = {"Go Back", "Exit"};
			Menu mainMenu = new Menu(text, options);
			
			int selectedIndex = mainMenu.Run();
			
			switch(selectedIndex)
			{
				case 0:
					RunMainMenu();
					break;
				case 1: 
					Exit();
					break;
					
			}
		}
		
		public static void Play()
		{	
			Console.Clear();
			Introduction.Introduction1();
		}
		
		
		public static void Credits()
		{
			string text = 
@"<<Lead Director>>                : [Mhartin Jhamal E. Tolentino]
<<Lead Programmer>>              : [Raymund Yanni M. Hernandez]
<<Lead Artist and Art Director>> : [Ricci Zasha S. Gandia]";
			SecondMenu(text);
		}
		
		public static void Exit()
		{
			Environment.Exit(0);
		}
		
		
	}
}