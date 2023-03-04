using Telephony;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] webAdresses = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Smartphone smartphone = new Smartphone();
StationaryPhone stationaryPhone = new StationaryPhone();

try
{
    foreach (string phoneNumber in phoneNumbers)
    {
        if (phoneNumber.Length == 10)
        {
            Console.WriteLine(smartphone.Calling(phoneNumber)); 
        }
        else if (phoneNumber.Length == 7)
        {
            Console.WriteLine(stationaryPhone.Calling(phoneNumber)); 
        }
    }

    foreach (string webAdress in webAdresses)
    {
        Console.WriteLine(smartphone.Browsing(webAdress)); 
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
