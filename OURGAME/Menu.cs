using System;

namespace OURGAME
{
	
	public class Menu
	{
		private int SelectedIndex;
		private string[] Options; 
		private string Prompt;
				
		public Menu(string prompt, string[] options)
		{
			this.Prompt = prompt;
			this.Options = options;
			SelectedIndex = 0;
		}
		

		
		private void DisplayOptions()
		{
			Console.WriteLine(Prompt);
			Console.WriteLine("");
			for(int i = 0; i < Options.Length; i++)
			{
				string currentOption = Options[i];
				string prefix;
				
				if(i == SelectedIndex)
				{
					prefix = ">>";
					Console.ForegroundColor = ConsoleColor.Black;
					Console.BackgroundColor = ConsoleColor.White;
				} 
				else
				{
					prefix = "  ";
					Console.ForegroundColor = ConsoleColor.White;
					Console.BackgroundColor = ConsoleColor.Black;
				}
				
				Console.WriteLine("{0} [{1}]",prefix, currentOption);
			}
			Console.ResetColor();
		}
		
		public int Run()
		{
			ConsoleKey keyPressed; 
			do
			{
				Console.Clear();
				DisplayOptions();
				
				ConsoleKeyInfo keyInfo = Console.ReadKey();
				keyPressed = keyInfo.Key;
				
				// Update SelectedIndex based on arrow keys.
				
				if(keyPressed == ConsoleKey.UpArrow)
				{
					SelectedIndex--; //tataas yung highlight don sa text
					
					if(SelectedIndex == -1)
					{
						SelectedIndex  = Options.Length - 1;
					}
				}
				else if(keyPressed == ConsoleKey.DownArrow)
				{
					SelectedIndex++; //bababa yung parang highlight don sa text
					
					if(SelectedIndex == Options.Length) // ang kinukuha kasi ng .length ay elements at hindi index kaya 4 yung total elements nung array
					{
						SelectedIndex = 0; // kaya zero ang nakalagay rito
					}
				}
				
			} while(keyPressed != ConsoleKey.Enter);
			
			return SelectedIndex;
		}
		
	}
}
