namespace BankProject
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Account account = null;

			bool isContinue = true;
			do
			{
				string menu = "0.Cixis\n" +
					"1.Hesab Yarat";
				if (account != null)
					menu =
						"0.Cixis\n"+
					"2.Pul yatir\n" +
				   "3.Pul cek\n" +
				   "4.Balansi goster\n" +
				   "5.Tarixceni goster";

				Console.WriteLine(menu);
				Console.Write("Enter operation number:");
				int.TryParse(Console.ReadLine(), out int operationNumber);
				Console.Clear();
				try
				{
					switch (operationNumber)
					{
						case 1:
							account = new Account("Nijat Soltanov", 500);
							break;
						case 2:
							if (account == null)
							{
								Console.WriteLine("First,you must create account");
								break;
							}
							Console.Write("Enter amount: ");
							double.TryParse(Console.ReadLine(), out double depositAmount);
							account.MakeDeposit(depositAmount);
							break;
						case 3:
							if (account == null)
							{
								Console.WriteLine("First,you must create account");
								break;
							}
							Console.Write("Enter amount: ");
							double.TryParse(Console.ReadLine(), out double withdrawAmount);
							account.MakeWithDraw(withdrawAmount);
							break;
						case 4:
							if (account == null)
							{
								Console.WriteLine("First,you must create account");
								break;
							}
							account.ShowBalance();
							break;
						case 5:
							if (account == null)
							{
								Console.WriteLine("First,you must create account");
								break;
							}
							account.ShowTransactions();
							break;
						case 0:
							isContinue = false;
							Console.ForegroundColor = ConsoleColor.Red;
							Console.Write("Exiting Program");
							for (int i = 0; i < 3; i++)
							{
								Thread.Sleep(1000);
								Console.Write(".");
							}
							break;
						default:
							Console.WriteLine("Enter valid operation number!!!");
							break;
					}
				}
				catch (Exception ex)
				{
					Console.ForegroundColor= ConsoleColor.Red;
					Console.WriteLine(ex.Message); 
				}

				Console.ResetColor();
			}
			while (isContinue);
		}
	}
}
