using Telephony;

string[] phoneNumbers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
string[] webAdresses = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

ICallable phone;

foreach (string phoneNumber in phoneNumbers)
{
    try
    {
        if (phoneNumber.Length == 10)
        {
            phone = new Smartphone();
            Console.WriteLine(phone.Calling(phoneNumber));
        }
        else if (phoneNumber.Length == 7)
        {
            phone = new StationaryPhone();
            Console.WriteLine(phone.Calling(phoneNumber));
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        
    }
}

IBrowsable browsablePhone = new Smartphone();

foreach (string webAdress in webAdresses)
{
    try
    {
        Console.WriteLine(browsablePhone.Browsing(webAdress));
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
        
    }
}
    





