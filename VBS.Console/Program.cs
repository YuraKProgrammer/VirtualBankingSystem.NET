using VBS.Models;


Bank CUBEBank = new Bank();
int corpId = CUBEBank.CreateCard("Yura K.", Currency.Rubles);
int userId = CUBEBank.CreateCard("User 12345", Currency.Rubles);
output();
CUBEBank.EmptyEnrollment(corpId, 1000);
CUBEBank.EmptyEnrollment(userId, 150);
output();
Payment payment1 = new Payment(corpId, 100, "Внутриигровая покупка");
CUBEBank.MakeDomesticPayment(userId, payment1);
output();

void output()
{
    Console.WriteLine("CUBE Corp: "+CUBEBank.KnowBalance(corpId));
    Console.WriteLine("User: "+CUBEBank.KnowBalance(userId));
}